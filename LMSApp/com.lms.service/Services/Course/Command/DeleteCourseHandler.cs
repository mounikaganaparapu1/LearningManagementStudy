

namespace com.lms.service
{
    using com.lms.DAO;
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    public class DeleteCourseHandler : IRequestHandler<DeleteCourseModel, ValidatableResponse<object>>
    {
        private IConfiguration _configuration;

        public DeleteCourseHandler(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [Obsolete]
        public async Task<ValidatableResponse<object>> Handle(DeleteCourseModel request, CancellationToken cancellationToken)
        {
            ValidatableResponse<object> validatableResponse;
            DeleteCourseValidation validator = new DeleteCourseValidation();

            var result = validator.Validate(request);
            if (result.IsValid)
            {
                try
                {
                    MongoDbCourseHelper mongoDbCourseHelper = new MongoDbCourseHelper(_configuration);
                    mongoDbCourseHelper.DeleteDocument<Course>("Courses", request.CourseId);
                    validatableResponse = new ValidatableResponse<object>("Course Successfully Deleted", null, null);
                    validatableResponse.StatusCode = (int)HttpStatusCode.OK;
                }
                catch (Exception)
                {
                    validatableResponse = new ValidatableResponse<object>("We are experiencing an internal server error. Contact your site administrator.", (int)HttpStatusCode.InternalServerError);
                    validatableResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                }
            }
            else
            {
                validatableResponse = new ValidatableResponse<object>((result.ToString().Replace("\n", "")).Replace("\r", ""), (int)HttpStatusCode.BadRequest);
                validatableResponse.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            return await Task.FromResult(validatableResponse);

        }
    }
}
