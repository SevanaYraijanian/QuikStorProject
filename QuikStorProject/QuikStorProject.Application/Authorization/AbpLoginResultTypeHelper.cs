using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp;
using Abp.Authorization;
using Abp.Dependency;
using Abp.UI;

namespace QuikStorProject.Authorization
{
    public class AbpLoginResultTypeHelper: AbpServiceBase, ITransientDependency
    {
    }
}
