using System.Threading.Tasks;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Errors;
using JobList.Common.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobList.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecruiterTokensController : ControllerBase
    {
        private readonly ITokensService<RecruiterDTO> tokensService;

        public RecruiterTokensController(ITokensService<RecruiterDTO> _tokensService)
        {
            tokensService = _tokensService;
        }

        [AllowAnonymous]
        [HttpPost("token")]
        public async Task<IActionResult> Token([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var tokenResponse = await tokensService.CreateTokenAsync(request);
                return Ok(tokenResponse);

            }
            catch (HttpStatusCodeException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var tokenResponse = await tokensService.RefreshTokenAsync(request);

                if (tokenResponse == null)
                {
                    return BadRequest("Recruiter with such Id not registered yet!");
                }

                return Ok(tokenResponse);
            }
            catch (HttpStatusCodeException ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}