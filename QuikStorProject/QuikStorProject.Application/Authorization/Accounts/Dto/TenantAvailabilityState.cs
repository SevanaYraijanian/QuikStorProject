using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuikStorProject.Application.Authorization.Accounts.Dto
{
    public enum TenantAvailabilityState
    {
        Available = 1,
        InActive,
        NotFound
    }    
}
