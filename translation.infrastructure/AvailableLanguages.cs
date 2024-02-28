using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using translation.domain.Entity;

namespace translation.infrastructure
{

    public class LangugeData
    {
        public List<Language> Languages { get; set; }
    }

    public class AvailableLanguage : IAvailableLanguage
    {
        private readonly IConfiguration _configuration;
        private LangugeData? _languageData;
        private string? languageLocation;

        public AvailableLanguage(IConfiguration configuration)
        {
            _configuration = configuration;
            //Handle null here
            languageLocation = _configuration["LanguageLocation"];
            LoadLanguage(languageLocation);
        }

        private void LoadLanguage(string? languageLocation)
        {
            try
            {
                string jsonString = File.ReadAllText(languageLocation);

                _languageData = JsonConvert.DeserializeObject<LangugeData>(jsonString);

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error reading JSON file: {ex.Message}");
            }
        }


        public Language? CheckLanguageAvailability(string language)
        {
            if(language != null && _languageData != null && _languageData.Languages != null)
            {
                Language foundLanguage = _languageData.Languages
                    .FirstOrDefault(lang => lang.Name.Equals(language, StringComparison.OrdinalIgnoreCase));

                return foundLanguage;
            }

            return null;
        }
    }
}
