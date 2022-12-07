
namespace com.lms.DAO
{
    using MongoDB.Bson.Serialization.Attributes;
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// User Model cLass
    /// </summary>
    public class User
    {
        [BsonId]
        [BsonElement("_id")]
        public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
