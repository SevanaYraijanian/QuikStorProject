using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Abp.Domain.Repositories;
using Abp.UI;
using QuikStorProject.Application.Logs;
using QuikStorProject.Application.Logs.Dto;
using QuikStorProject.Application.Registration.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace QuikStorProject.Application.Registration
{
    public class RegistrationAppService: arbidhAppServiceBase, IRegistrationAppService
    {
        private readonly IRepository<RegistrationEntity, long> _registrationRepository;
        private readonly ILogsAppService _iLogsAppService;

        public RegistrationAppService(IRepository<RegistrationEntity, long> registrationRepository, ILogsAppService _iLogsAppService)
        {
            _registrationRepository = registrationRepository;
            this._iLogsAppService = _iLogsAppService;
        }

        public async Task<Guid> Create(RegistrationCreator input)
        {
            try
            {
                var entity = new RegistrationEntity
                {
                    Name = input.Name,
                    SchoolName = input.SchoolName,
                    PhoneNumber = input.PhoneNumber,
                    ZipCode = input.ZipCode
                };
                await _registrationRepository.InsertAsync(entity);
                await CurrentUnitOfWork.SaveChangesAsync();

                var secretKey = new SecretKey
                {
                    key = Guid.NewGuid()
                };
                entity.SecretKey = secretKey.key;
                await _registrationRepository.UpdateAsync(entity);
                await CurrentUnitOfWork.SaveChangesAsync();

                var logsObj = new LogsCreator
                {
                    HitDateTime = entity.CreationTime,
                    ApiName = "Client_Registration"
                };
                await _iLogsAppService.Create(logsObj);
                return secretKey.key;
            }
            catch (Exception e)
            {
                throw new UserFriendlyException(e.Message);
            }
        }

        [HttpGet]
        public async Task<RegistrationFull> FindBySecretKey(Guid key)
        {
            try
            {
                var mapTo = await _registrationRepository.FirstOrDefaultAsync(m => m.SecretKey == key);
                var logsObj = new LogsCreator
                {
                    HitDateTime = mapTo.CreationTime,
                    ApiName = "Client_FindBySecretKey"
                };
                await _iLogsAppService.Create(logsObj);
                return ObjectMapper.Map<RegistrationFull>(mapTo);
            }
            catch (Exception e)
            {
                throw new UserFriendlyException(e.Message);
            }
        }

        [HttpGet]
        public async Task<List<DistinctSchoolNames>> GetDistinctSchoolNamesWithCount()
        {
            try
            {
                var mapTo = await _registrationRepository.GetAll().GroupBy(m => m.SchoolName)
                    .Select(m => new DistinctSchoolNames
                    {
                        SchoolName = m.Key,
                        NumberOfRegisteredStudents = m.Count()
                    }).ToListAsync();
                var logsObj = new LogsCreator
                {
                    HitDateTime = DateTime.Now,
                    ApiName = "Admin_GetDistinctSchoolNamesWithCount"
                };
                await _iLogsAppService.Create(logsObj);
                return mapTo;
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                throw new UserFriendlyException(e.Message);
            }
        }

        [HttpGet]
        public async Task<List<RegistrationFull>> GetAllList()
        {
            try
            {
                var mapTo = await _registrationRepository.GetAll().ToListAsync();
                var logsObj = new LogsCreator
                {
                    HitDateTime = mapTo.FirstOrDefault().CreationTime,
                    ApiName = "Admin_GetAllList"
                };
                await _iLogsAppService.Create(logsObj);
                return ObjectMapper.Map<List<RegistrationFull>>(mapTo);
            }
            catch (Exception e)
            {
                throw new UserFriendlyException(e.Message);
            }
        }
    }
}
