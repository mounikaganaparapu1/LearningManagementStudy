

namespace com.lms.service
{
    using AutoMapper;
    using com.lms.DAO;
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    public class GetAllCourseHandler : IRequestHandler<GetAllCourseModel, ValidatableResponse<List<CourseInfoView>>>
    {
        private IConfiguration _configuration;

        public GetAllCourseHandler(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [Obsolete]
        public async Task<ValidatableResponse<List<CourseInfoView>>> Handle(GetAllCourseModel request, CancellationToken cancellationToken)
        {
            ValidatableResponse<List<CourseInfoView>> validatableResponse;

            try
            {
                MongoDbCourseHelper mongoDbCourseHelper = new MongoDbCourseHelper(_configuration);
                List<Course> dbCourses;

                dbCourses = mongoDbCourseHelper.LoadAllDocuments<Course>("Courses");

                if (dbCourses.Count > 0)
                {
                    MapperConfiguration config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Course, CourseInfoView>()
                           .ForMember(destination => destination.Id, map => map.MapFrom(source => source.Id))
                           .ForMember(destination => destination.CourseName, map => map.MapFrom(source => source.CourseName))
                           .ForMember(destination => destination.CourseDescription, map => map.MapFrom(source => source.CourseDescription))
                           .ForMember(destination => destination.CourseLaunchURL, map => map.MapFrom(source => source.CourseLaunchURL))
                           .ForMember(destination => destination.CourseTechnology, map => map.MapFrom(source => source.CourseTechnology));
                    });

                    var unSortedlistCourses = config.CreateMapper().Map<List<Course>, List<CourseInfoView>>(dbCourses);

                    var listCourses = unSortedlistCourses;
                    validatableResponse = new ValidatableResponse<List<CourseInfoView>>("Courses", null, listCourses);
                    validatableResponse.StatusCode = (int)HttpStatusCode.OK;
                }
                else
                {
                    validatableResponse = new ValidatableResponse<List<CourseInfoView>>("No Course Found", null, new List<CourseInfoView>());
                    validatableResponse.StatusCode = (int)HttpStatusCode.OK;
                }
            }
            catch (Exception)
            {
                validatableResponse = new ValidatableResponse<List<CourseInfoView>>("We are experiencing an internal server error. Contact your site administrator.", (int)HttpStatusCode.InternalServerError);
                validatableResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            return await Task.FromResult(validatableResponse);

        }

    }
}
