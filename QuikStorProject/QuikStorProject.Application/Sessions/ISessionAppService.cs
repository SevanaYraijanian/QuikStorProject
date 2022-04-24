using System.Threading.Tasks;
using Abp.Application.Services;
using QuikStorProject.Application.Sessions.Dto;

namespace QuikStorProject.Application.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
