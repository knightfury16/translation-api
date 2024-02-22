using translation.domain;
using translation.domain.Entity;
using translation.domain.Enum;
using translation.domain.Translation;

namespace translation.application;

public interface ITranslator
{
    Translation Translate(OriginalMessage originalText, TranslationServiceType translationServiceType);
    Translation AutoTranslate(Message originalText);
}
