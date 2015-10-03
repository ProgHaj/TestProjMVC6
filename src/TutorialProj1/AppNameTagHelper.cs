using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace TutorialProj1
{
    [TargetElement("app-name")]
    [TargetElement(Attributes = "app-name")]
    public class AppNameTagHelper : TagHelper
    {
        private MyConfig _config;

        public AppNameTagHelper(MyConfig config)
        {
            _config = config;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetContent("This is my taghelper" + _config.SiteName);
        }
    }

}
