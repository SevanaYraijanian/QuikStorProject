using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuikStorProject.Application.Services;
using QuikStorProject.Application.MultiTenancy.Dto;

namespace QuikStorProject.Application.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
