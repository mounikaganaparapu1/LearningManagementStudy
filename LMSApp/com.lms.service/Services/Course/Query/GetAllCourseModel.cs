

namespace com.lms.service
{
    using MediatR;
    using System.Collections.Generic;
    public class GetAllCourseModel : IRequest<ValidatableResponse<List<CourseInfoView>>>
    {
        public string CourseName { get; set; }
        public string CourseDuration { get; set; }
        public string CourseDescription { get; set; }
        public string CourseTechnology { get; set; }
        public string CourseLaunchURL { get; set; }
    }
}
