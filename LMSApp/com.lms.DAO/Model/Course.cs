

namespace com.lms.DAO
{
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson.Serialization.IdGenerators;
    using System;
    public class Course
    {
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public Guid Id { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int CourseDuration { get; set; }
        public string CourseDescription { get; set; }
        public string CourseTechnology { get; set; }
        public string CourseLaunchURL { get; set; }
    }
}
