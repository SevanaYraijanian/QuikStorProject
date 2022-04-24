using Abp.Application.Services.Dto;

namespace QuikStorProject.Application.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

