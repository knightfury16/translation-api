using Microsoft.AspNetCore.Mvc;
using translation.api.Models;
using translation.application.Common.Interfaces;
using translation.application.Common.Models;
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
        [HttpPost]
        public Translation GetTranslation([FromBody] RequestDto requestDto)
        {
            TranslateRequestDto translateReqDto = new TranslateRequestDto{
                message = requestDto.message,
                fromLanguage = requestDto.fromLanguage,
                toLanguage = requestDto.toLanguage,
            };
            return _translator.Translate(translateReqDto);
        }
    }
}
