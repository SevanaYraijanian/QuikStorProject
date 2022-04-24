using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuikStorProject.Application.Configuration.Dto;

namespace QuikStorProject.Application.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);

    }
}
