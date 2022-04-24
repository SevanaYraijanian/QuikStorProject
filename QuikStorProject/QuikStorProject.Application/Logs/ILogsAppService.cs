using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuikStorProject.Application.Logs.Dto;

namespace QuikStorProject.Application.Logs
{
    public interface ILogsAppService
    {
        Task<bool> Create(LogsCreator input);
    }
}
