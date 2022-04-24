using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuikStorProject.Application.Services.Dto;

namespace QuikStorProject.Application.MultiTenancy.Dto
{
    public class PagedTenantResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
