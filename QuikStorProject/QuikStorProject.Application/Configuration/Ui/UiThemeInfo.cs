using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuikStorProject.Application.Configuration.Ui
{
    public class UiThemeInfo
    {
        public string Name { get; }
        public string CssClass { get; }

        public UiThemeInfo(string name, string cssClass)
        {
            Name = name;
            CssClass = cssClass;
        }

    }
}
