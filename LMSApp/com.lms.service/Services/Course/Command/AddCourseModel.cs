
namespace com.lms.service
{
    using MediatR;
    using System;
    public class AddCourseModel : IRequest<ValidatableResponse<object>>
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int CourseDuration { get; set; }
        public string CourseDescription { get; set; }
        public string CourseTechnology { get; set; }
        public string CourseLaunchURL { get; set; }
    }
}
