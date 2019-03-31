using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class TabIndicator : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "div");
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter]
        bool Active { get; set; }

        [Parameter]
        bool Fade { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            List<string> classes = new List<string> { "mdc-tab-indicator" };

            if (Active)
            {
                classes.Add("mdc-tab-indicator--active");
            }

            if (Fade)
            {
                classes.Add("mdc-tab-indicator--fade");
            }

            return classes;
        }
    }
}