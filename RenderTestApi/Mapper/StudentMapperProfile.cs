using AutoMapper;
using RenderTestApi.Entity;
using RenderTestApi.Model;

namespace RenderTestApi.Mapper
{
    public class StudentMapperProfile : Profile
    {
        public StudentMapperProfile()
        {
            CreateMap<RegisterStudentModel, StudentEntity>()
                .ForMember(src => src.FirstName, otp => otp.MapFrom(x => x.FirstName))
                .ForMember(src => src.LastName, otp => otp.MapFrom(y => y.LastName))
                .ForMember(src => src.Email, otp => otp.MapFrom(z => z.Email))
                .ForMember(src => src.Id, otp => otp.MapFrom(_ => Guid.NewGuid()))
                .ForMember(src => src.Age, otp => otp.MapFrom(t => t.Age));
        }

    }
}
