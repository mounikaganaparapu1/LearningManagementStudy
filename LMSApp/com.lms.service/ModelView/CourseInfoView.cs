

namespace com.lms.service
{
    using System;
    public class CourseInfoView
    {
        public Guid Id { get; set; }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDuration { get; set; }
        public string CourseDescription { get; set; }
        public string CourseTechnology { get; set; }
        public string CourseLaunchURL { get; set; }
    }
}
