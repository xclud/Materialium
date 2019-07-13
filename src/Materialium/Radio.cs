using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class Radio : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "div");
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter]
        public bool Disabled { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-radio";
            if (Disabled)
            {
                yield return " mdc-radio--disabled";
            }

        }
    }
}