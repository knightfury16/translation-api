using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using translation.application;
using translation.application.Common.Interfaces;
using translation.application.Common.Models;
using translation.infrastructure;
using translation.infrastructure.TranslatorServices;

namespace translation.console;

class Program
{
    static void Main(string[] args)
    {

        var serviceCollection = new ServiceCollection();

        serviceCollection.AddConfiguration();
        serviceCollection.AddMyServices();

        var serviceProvider = serviceCollection.BuildServiceProvider();

        var tranlatorRequestDto = new TranslateRequestDto
        {
            message = "when is the meeting?",
            fromLanguage = "english",
            toLanguage = "spanish",
        };

        var translatorService = serviceProvider.GetRequiredService<ITranslator>();

        var translation = translatorService?.Translate(tranlatorRequestDto);

        Console.WriteLine(translation?._translatedText.ToString());

    }
}
