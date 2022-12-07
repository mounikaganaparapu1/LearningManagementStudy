

namespace com.lms.service.Services
{
    using FluentValidation;
    using System;
    using System.Text.RegularExpressions;
    public class RegisterUserValidation : AbstractValidator<RegisterUserModel>
    {
        public RegisterUserValidation()
        {
            RuleFor(x => x.Email).NotEmpty().NotNull().Must(ValidateEmail).WithMessage("Invalid email-ID. ");
            RuleFor(x => x.Password).NotEmpty().NotNull().Must(ValidatePassword).WithMessage("Invalid password (length must be at least 8 alphanumeric charactes). ");
            RuleFor(x => x.FirstName).NotEmpty().NotNull().Must(ValidateFirstName).WithMessage("Invalid First Name. ");
            RuleFor(x => x.LastName).NotEmpty().NotNull().Must(ValidateLastName).WithMessage("Invalid Last Name. ");
        }

        private bool ValidateFirstName(string firstName)
        {
            if (firstName != null && firstName.Length > 0)
            {
                return true;
            }
            return false;
        }

        private bool ValidateLastName(string firstName)
        {
            if (firstName != null && firstName.Length > 0)
            {
                return true;
            }
            return false;
        }

        private bool ValidateEmail(string email)
        {
            bool isValidEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            return isValidEmail;
        }

        private bool ValidatePassword(string pass)
        {
            Regex regexObj = new Regex(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{2,})$");
            bool foundMatch = regexObj.IsMatch(pass);
            if (pass.Length >= 8 && foundMatch)
            {
                return true;
            }
            return false;
        }
    }
}
