

namespace com.lms.service
{
    using FluentValidation;
    public class AddCourseValidation : AbstractValidator<AddCourseModel>
    {
        public AddCourseValidation()
        {
            RuleFor(x => x.CourseName).NotEmpty().NotNull().Must(ValidateCourseName).WithMessage("Course Name should not be null and at least contains 20 characters.");
            RuleFor(x => x.CourseDescription).NotEmpty().NotNull().Must(ValidateCourseDescription).WithMessage("Course Name should not be null and at least contains 100 characters.");
        }
        private bool ValidateCourseName(string courseName)
        {
            if (courseName != null && courseName.Length >= 20)
            {
                return true;
            }
            return false;
        }

        private bool ValidateCourseDescription(string courseDescription)
        {
            if (courseDescription != null && courseDescription.Length >= 100)
            {
                return true;
            }
            return false;
        }
    }
}
