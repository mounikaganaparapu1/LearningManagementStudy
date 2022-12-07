

namespace com.lms.service
{
    using MediatR;
    using System.Collections.Generic;
    public class GetCoursesByDurationRangeModel : IRequest<ValidatableResponse<List<CourseInfoView>>>
    {
        public int DurationFrom { get; set; }
        public int DurationTo { get; set; }
    }
}
