

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
    /// 
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;
        /// <summary>
        /// Injecting Mediator
        /// </summary>
        /// <param name="mediator"></param>
        public CourseController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        /// <summary>
        /// Add course endpoint to add new course
        /// </summary>
        [HttpPost("/api/v{version:apiVersion}/lms/courses/add")]
        [MapToApiVersion("1.0")]
        [Authorize]
        public async Task<ActionResult> AddCourse([FromBody] AddCourseModel course)
        {
            var response = await this._mediator.Send(course);
            return response.HttpResponseCommandResult;
        }

        /// <summary>
        /// get endpoint for getting all Courses
        /// </summary>
        [HttpGet("/api/v{version:apiVersion}/lms/courses/getall")]
        [MapToApiVersion("1.0")]
        [Authorize]
        public async Task<ActionResult> GetAllCourses()
        {
            var response = await this._mediator.Send(new GetAllCourseModel());
            return response.HttpResponseQueryResult;
        }

        /// <summary>
        /// Delete Course with CourseId by valid user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("/api/v{version:apiVersion}/lms/courses/delete")]
        [MapToApiVersion("1.0")]
        [Authorize]
        public async Task<ActionResult> DeleteCourse(string id)
        {
           // string user = this.User.FindFirst(s => s.Type == "userid")?.Value;
            var response = await this._mediator.Send(new DeleteCourseModel() { CourseId = id });
            return response.HttpResponseCommandResult;
        }

        /// <summary>
        /// Get Course Details Based on Duration range
        /// </summary>
        /// <param name="durationFrom"></param>
        /// <param name="durationTo"></param>
        /// <returns></returns>
        [HttpGet("/api/v{version:apiVersion}/lms/courses/getcoursesbyduration")]
        [MapToApiVersion("1.0")]
        [Authorize]
        public async Task<ActionResult> GetCoursesByDurationRange(int durationFrom,int durationTo)
        {
            // string user = this.User.FindFirst(s => s.Type == "userid")?.Value;
            var response = await this._mediator.Send(new GetCoursesByDurationRangeModel() { DurationFrom = durationFrom, DurationTo = durationTo });
            return response.HttpResponseQueryResult;
        }

        /// <summary>
        /// Get Course Details Based on Technology
        /// </summary>
        /// <param name="technology"></param>
        /// <returns></returns>
        [HttpGet("/api/v{version:apiVersion}/lms/courses/getcoursesbytechnology")]
        [MapToApiVersion("1.0")]
        [Authorize]
        public async Task<ActionResult> GetCoursesByTechnology(string technology)
        {
            var response = await this._mediator.Send(new GetCoursesByTechnologyModel() { Technology = technology });
            return response.HttpResponseQueryResult;
        }
    }
}
