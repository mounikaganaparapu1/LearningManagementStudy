

namespace com.lms.service
{
    using com.lms.DAO;
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    public class AddCourseHandler : IRequestHandler<AddCourseModel, ValidatableResponse<object>>
    {
        private IConfiguration _configuration;

        public AddCourseHandler(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [Obsolete]
        public async Task<ValidatableResponse<object>> Handle(AddCourseModel request, CancellationToken cancellationToken)
        {
            ValidatableResponse<object> validatableResponse;
            AddCourseValidation validator = new AddCourseValidation();

            var result = validator.Validate(request);
            if (result.IsValid)
            {
                try
                {
                    MongoDbCourseHelper mongoDbCourseHelper = new MongoDbCourseHelper(_configuration);

                    Course course = new Course();
                    course.CourseId = request.CourseId;
                    course.CourseName = request.CourseName;
                    course.CourseDuration = request.CourseDuration;
                    course.CourseDescription = request.CourseDescription;
                    course.CourseLaunchURL = request.CourseLaunchURL;
                    course.CourseTechnology = request.CourseTechnology;

                    mongoDbCourseHelper.InsertDocument<Course>("Courses", course);

                    validatableResponse = new ValidatableResponse<object>("Course Sucessfully Created", null, null);
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
