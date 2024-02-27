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

namespace translation.infrastructure.TranslatorServices
{

    public class ResponseData
    {
        public string TranslatedText { get; set; }
        public double Match { get; set; }
    }

    public class Match
    {
        public string Id { get; set; }
        public string Segment { get; set; }
        public string Translation { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public string Quality { get; set; }
        public object Reference { get; set; }
        public int UsageCount { get; set; }
        public string Subject { get; set; }
        public string CreatedBy { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public double MatchValue { get; set; }
    }

    public class MyMemoryApiResponse
    {
        public ResponseData responseData { get; set; }
        public bool quotaFinished { get; set; }
        public object mtLangSupported { get; set; }
        public string responseDetails { get; set; }
        public int responseStatus { get; set; }
        public object responderId { get; set; }
        public object exception_code { get; set; }
        public List<Match> matches { get; set; }
    }

    public class TranslatorService : ITranslatorService
    {
        private readonly IConfiguration _configuration;

        public TranslatorService(IConfiguration configuration )
        {
            _configuration = configuration;
        }
        public Translation Translate(string message, string fromLanguage, string toLanguage)
        {
            //call the my-memory api in this format https://api.mymemory.translated.net/get?q=beautiful&langpair=en|bn

            var originalLan = CheckLanguageAvailability(fromLanguage);
            var translatedLan = CheckLanguageAvailability(toLanguage);




            //call the api here with the format
            // Call the MyMemory API
            string apiUrl = $"https://api.mymemory.translated.net/get?q={Uri.EscapeDataString(message)}&langpair={originalLan}|{translatedLan}";
            MyMemoryApiResponse apiResponse = CallMyMemoryApi(apiUrl);

            //map the response to translation obj

            // Map the API response to the Translation object
            OriginalMessage originalMsg = new OriginalMessage(message, new Language { Name = fromLanguage});
            TranslatedMessage translatedMessage = new TranslatedMessage(apiResponse.responseData.TranslatedText, new Language { Name = toLanguage});
            Translation translation = new Translation(originalMsg, translatedMessage);


            return translation;
        }

        private MyMemoryApiResponse CallMyMemoryApi(string apiUrl)
        {
            // Implement logic to make the API call and deserialize the response
            // You may use HttpClient or any other preferred method for making HTTP requests
            // Here, I'm using a simple WebClient for demonstration purposes
            using (WebClient webClient = new WebClient())
            {
                string jsonResponse = webClient.DownloadString(apiUrl);
                return JsonConvert.DeserializeObject<MyMemoryApiResponse>(jsonResponse);
            }
        }

        private string? CheckLanguageAvailability(string language)
        {
            Dictionary<string,string> supportedLanguages = GetSupportedLanguages(); // Implement this method
         
            return supportedLanguages.ContainsKey(language) ? supportedLanguages[language] : null;
        }
         

        private Dictionary<string, string> GetSupportedLanguages()
        {
            // Define your supported languages here
            Dictionary<string, string> supportedLanguages = new Dictionary<string, string>
            {
                { "English", "en" },
                { "Bangla", "bn" },
                // Add more languages as needed
            };

            return supportedLanguages;
        }

    }
}
