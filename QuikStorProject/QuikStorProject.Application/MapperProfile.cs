using QuikStorProject.Application.Registration;
using arbQuikStorProject.Applicationidh.Registration.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace QuikStorProject
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region Registration Mapping

            CreateMap<RegistrationEntity, RegistrationFull>().ReverseMap();

            #endregion

        }
    }
}