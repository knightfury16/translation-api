using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using translation.application.Common.Interfaces;
using translation.domain;
using translation.domain.Entity;
using translation.domain.Enum;
using translation.domain.Translation;
using translation.infrastructure.Models;

namespace translation.infrastructure.TranslatorServices
{
    public class TranslatorService : ITranslatorService
    {
        private readonly IConfiguration _configuration;
        private readonly IAvailableLanguage _availableLanguage;

        public TranslatorService(IConfiguration configuration, IAvailableLanguage availableLanguage )
        {
            _configuration = configuration;
            _availableLanguage = availableLanguage;
        }

        public Translation Translate(string message, string fromLanguage, string toLanguage)
        {
            var originalLan = _availableLanguage.CheckLanguageAvailability(fromLanguage);
            var translatedLan = _availableLanguage.CheckLanguageAvailability(toLanguage);

            if(originalLan == null || translatedLan == null)
            {
                throw new Exception($"From {fromLanguage} to {toLanguage} service is not available.");
            }

            var apiUrl = GetRequestUrl(message, originalLan, translatedLan) ?? throw new Exception("Could not find URL");
            
            MyMemoryApiResponse apiResponse = CallMyMemoryApi(apiUrl);


            // Map the API response to the Translation object
            OriginalMessage originalMsg = new(message, originalLan);
            TranslatedMessage translatedMessage = new(apiResponse.responseData.TranslatedText, translatedLan);
            Translation translation = new(originalMsg, translatedMessage);


            return translation;
        }

        private string? GetRequestUrl(string message, Language orginalLanguage, Language translatedLanguage)
        {
            var baseUrl = _configuration["ApiUrl"];

            if( baseUrl == null )
            {
                return null;
            }

            string requestUrl = $"{baseUrl}/get?q={Uri.EscapeDataString(message)}&langpair={orginalLanguage.Code}|{translatedLanguage.Code}";

            return requestUrl;
        }

        private MyMemoryApiResponse CallMyMemoryApi(string apiUrl)
        {
            using (WebClient webClient = new WebClient())
            {
                string jsonResponse = webClient.DownloadString(apiUrl);
                return JsonConvert.DeserializeObject<MyMemoryApiResponse>(jsonResponse) ?? 
                    throw new Exception("Could not deserialize MyMemory Api response!!");
            }
        }

        public Translation AutoTranslate(string message, string toLanguage)
        {
            throw new NotImplementedException();
        }
    }
}
