using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using QuikStorProject.Application.Registration.Dto;

namespace QuikStorProject.Application.Registration
{
    public interface IRegistrationAppService : IApplicationService
    {
        Task<Guid> Create(RegistrationCreator input);
        Task<RegistrationFull> FindBySecretKey(Guid key);
        Task<List<DistinctSchoolNames>> GetDistinctSchoolNamesWithCount();
        Task<List<RegistrationFull>> GetAllList();
    }
}
