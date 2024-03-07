using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.CommandLine;
using translation.application;
using translation.application.Common.Interfaces;
using translation.application.Common.Models;
using translation.infrastructure;
using translation.infrastructure.TranslatorServices;

namespace translation.console;

class Program
{
    private static ServiceCollection _serviceCollection;
    private static ServiceProvider? _serviceProvider;

    static Program()
    {
        _serviceCollection = new ServiceCollection();
        _serviceCollection.AddConfiguration();
        _serviceCollection.AddMyServices();

        _serviceProvider = _serviceCollection.BuildServiceProvider();
    }


    static int Main(string[] args)
    {
        var textOption = new Option<string>(name: "--text", description: "Text to translate"){ IsRequired = true };
        var fromLanguageOption = new Option<string>(name: "--from", description: "Laanguage to translate from") { IsRequired = true };
        var toLanguageOption = new Option<string>(name:"--to",description:"Language to translate to") { IsRequired= true };

        var rootCommand = new RootCommand("A console app to translate language");

        var translateCommand = new Command("translate", "Translate language")
        {
            textOption,
            fromLanguageOption,
            toLanguageOption,
        };

        rootCommand.AddCommand(translateCommand);

        translateCommand.SetHandler((text, fromLanguage, toLanguage) =>
        {
            translate(text, fromLanguage, toLanguage);

        }, textOption, fromLanguageOption, toLanguageOption);


        return rootCommand.Invoke(args);
    }

    private static void translate(string text, string fromLanguage, string toLanguage)
    {


        var tranlatorRequestDto = new TranslateRequestDto
        {
            message = text,
            fromLanguage = fromLanguage,
            toLanguage = toLanguage,
        };

        var translatorService = _serviceProvider.GetRequiredService<ITranslator>();

        var translation = translatorService?.Translate(tranlatorRequestDto);

        Console.WriteLine(translation?.TranslatedText.ToString());
    }
}
