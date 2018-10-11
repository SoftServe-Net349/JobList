using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.Errors;
using JobList.Common.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        private readonly ITokensService tokensService;

        public TokensController(ITokensService _tokensService)
        {
            tokensService = _tokensService;
        }

        [AllowAnonymous]
        [HttpPost()]
        public async Task<IActionResult> Token([FromBody] UserLoginRequest request)
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

            var tokenResponse = await tokensService.RefreshTokenAsync(request);

            if (tokenResponse == null)
            {
                return BadRequest("User with such Id not registered yet!");
            }

            return Ok(tokenResponse);
        }

    }
}