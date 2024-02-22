using Microsoft.AspNetCore.Mvc;
using translation.application;
using translation.domain.Entity;
using translation.domain.Enum;
using translation.domain.Translation;

namespace translation.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TranslationController : ControllerBase
    {

        public ITranslator _translator;

        public TranslationController(ITranslator translator)
        {
            _translator = translator;
        }
        [HttpGet]
        public Translation GetTranslation()
        {
            OriginalMessage originalMessage = new OriginalMessage("Hello there my friend");
            return _translator.Translate(originalMessage, TranslationServiceType.Shakespear);
        }
    }
}
