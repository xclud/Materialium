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

        [Parameter] public bool AlignStart { get; set; }

        [Parameter] public bool AlignEnd { get; set; }

        [Parameter] public bool AlignCenter { get; set; }

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


        public static class Classes
        {
            public const string TabScroller = "mdc-tab-scroller";
            public const string AlignStart = "mdc-tab-scroller--align-start";
            public const string AlignEnd = "mdc-tab-scroller--align-end";
            public const string AlignCenter = "mdc-tab-scroller--align-center";
            public const string ScrollArea = "mdc-tab-scroller__scroll-area";
            public const string ScrollContent = "mdc-tab-scroller__scroll-content";
        }
    }
}