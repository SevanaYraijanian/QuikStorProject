using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QuikStorProject.Application.Authorization;

namespace QuikStorProject
{
    [DependsOn(
        typeof(arbidhCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class arbidhApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<arbidhAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(arbidhApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
