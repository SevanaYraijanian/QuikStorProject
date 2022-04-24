using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.UI;
using QuikStorProject.Application.Logs.Dto;

namespace QuikStorProject.Application.Logs
{
    public class LogsAppService : arbidhAppServiceBase, ILogsAppService
    {
        private readonly IRepository<LogsEntity, long> _logsRepository;

        // LogsEntity: QuickStorProject.Core.Logs
        public LogsAppService(IRepository<LogsEntity, long> logsRepository)
        {
            _logsRepository = logsRepository;
        }

        public async Task<bool> Create(LogsCreator input)
        {
            try
            {
                var entity = new LogsEntity
                {
                    HitDateTime = input.HitDateTime,
                    ApiName = input.ApiName
                };
                await _logsRepository.InsertAsync(entity);
                await CurrentUnitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new UserFriendlyException(e.Message);
            }
        }
    }
}
