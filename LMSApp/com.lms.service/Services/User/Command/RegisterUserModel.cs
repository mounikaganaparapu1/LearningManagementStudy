
namespace com.lms.service
{
    using MediatR;
    using System;
    public class RegisterUserModel: IRequest<ValidatableResponse<object>>
    {
        public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool IsAdmin { get; set; }

        public string Password { get; set; }
    }
}
