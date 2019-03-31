using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class TabIndicatorContent : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "div");
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter]
        bool UseIcon { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            List<string> classes = new List<string> { "mdc-tab-indicator__content" };

            if (!UseIcon)
            {
                classes.Add("mdc-tab-indicator__content--underline");
            }
            else
            {
                classes.Add("mdc-tab-indicator__content--icon");
            }

            return classes;
        }
    }
}