using translation.domain;
using translation.domain.Entity;
using translation.domain.Enum;
using translation.domain.Translation;

namespace translation.application.Common.Interfaces
{
    public interface ITranslatorService
    {
        Translation Translate(string message, string fromLanguage, string toLanguage);
        Translation AutoTranslate(string message, string toLanguage);
    }
}