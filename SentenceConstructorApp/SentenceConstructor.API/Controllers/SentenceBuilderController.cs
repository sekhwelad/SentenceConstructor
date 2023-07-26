using Microsoft.AspNetCore.Mvc;
using SentenceConstructor.Core.Entities;
using SentenceConstructor.Core.Services;

namespace SentenceConstructor.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SentenceBuilderController : ControllerBase
    {

        private readonly IWordService _wordService;
        private readonly ISentenceService _sentenceService;

        public SentenceBuilderController(IWordService wordService, ISentenceService sentenceService)
        {
            _wordService = wordService;
            _sentenceService = sentenceService;
        }

        [HttpGet(nameof(GetWords))]
        public async Task<ActionResult> GetWords()
        {
            var data = await _wordService.GetWords();
            if (data == null) return NoContent();

            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult> SaveSentence([FromBody] Sentence sentence)
        {
            if (string.IsNullOrEmpty(sentence.Expression))
                return BadRequest();

          await _sentenceService.SaveSentence(sentence);
            return Ok(sentence);
        }

        [HttpGet("{id}", Name = "GetSentence")]
        public async Task<ActionResult<Sentence>> GetSentence(int id)
        {
            var data = await _sentenceService.GetSentence(id);
            if(data == null) return NoContent();

            return Ok(data);
        }

        [HttpGet(nameof(GetAllSentences))]
        public async Task<ActionResult<Sentence[]>> GetAllSentences()
        {
            var data = await _sentenceService.GetAllSentences();
            if (data == null) return NoContent();
            return Ok(data);
        }

    }
}
