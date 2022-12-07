

namespace com.lms.service
{
    using FluentValidation;
    public class DeleteCourseValidation : AbstractValidator<DeleteCourseModel>
    {
        public DeleteCourseValidation()
        {
            RuleFor(x => x.CourseId).NotEmpty().NotNull().WithMessage("Course id Must not be null or empty.  ");
        }
    }
}
