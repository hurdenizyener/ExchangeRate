using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IFirstExchangeRateService _dovizKuruService;

        public TestController(IFirstExchangeRateService dovizKuruService)
        {
            _dovizKuruService = dovizKuruService;
        }

        //[HttpGet("GetAll")]
        //public async Task<IActionResult> GetAllAsync()
        //{
        //    var result = await _dovizKuruService.GetAllAsync();

        //    return Ok(result);

        //}

    }
}
