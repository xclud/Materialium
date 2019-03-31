using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class TabScroller : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "div");
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter] bool AlignStart { get; set; }

        [Parameter] bool AlignEnd { get; set; }

        [Parameter] bool AlignCenter { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            List<string> classes = new List<string> { "mdc-tab-scroller" };

            if (AlignStart)
            {
                classes.Add("mdc-tab-scroller--align-start");
            }

            if (AlignCenter)
            {
                classes.Add("mdc-tab-scroller--align-center");
            }

            if (AlignEnd)
            {
                classes.Add("mdc-tab-scroller--align-end");
            }

            return classes;
        }
    }
}