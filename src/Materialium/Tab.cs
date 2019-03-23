using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class Tab : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "button");

            builder.AddAttribute(n++, "role", "tab");

            if (Active)
            {
                builder.AddAttribute(n++, "aria-selected", Active);
            }

            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter]
        bool Active { get; set; }

        [Parameter]
        bool Stacked { get; set; }

        [Parameter]
        bool MinWidth { get; set; }


        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-tab";

            if (Active)
            {
                yield return "mdc-tab--active";
            }
            if (Stacked)
            {
                yield return "mdc-tab--stacked";
            }

            if (MinWidth)
            {
                yield return "mdc-tab--min-width";
            }
        }
    }
}