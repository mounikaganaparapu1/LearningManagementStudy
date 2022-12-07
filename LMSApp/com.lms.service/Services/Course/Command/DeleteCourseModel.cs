

namespace com.lms.service
{
    using MediatR;
    public class DeleteCourseModel: IRequest<ValidatableResponse<object>>
    {
        public string CourseId { get; set; }
    }
}
