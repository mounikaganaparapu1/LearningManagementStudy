

namespace com.lms.service
{
    using MediatR;
    using System.Collections.Generic;
    public class GetCoursesByTechnologyModel : IRequest<ValidatableResponse<List<CourseInfoView>>>
    {
        public string Technology { get; set; }
    }
}
