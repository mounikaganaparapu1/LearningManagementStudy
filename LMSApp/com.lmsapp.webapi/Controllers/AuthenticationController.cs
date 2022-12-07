
namespace com.lmsapp.webapi.Controllers
{
    using com.lms.service;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    /// <summary>
    /// Authentication endpoints
    /// </summary>

    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        /// <summary>
        /// Injecting Mediator
        /// </summary>
        /// <param name="mediator"></param>
        public AuthenticationController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        /// <summary>
        /// login endpoint returns token for valid users
        /// </summary>
        [HttpPost("/api/v{version:apiVersion}/lms/user/login")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Login([FromBody] GetTokenModel user)
        {
            var response = await this._mediator.Send(user);
            return response.HttpResponseQueryResult;
        }

        /// <summary>
        /// register endpoint to register new user
        /// </summary>
        [HttpPost("/api/v{version:apiVersion}/lms/user/register")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterUserModel user)
        {
            var response = await this._mediator.Send(user);
            return response.HttpResponseCommandResult;
        }
    }
}
