using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class Chip : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "div");
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter] bool Selected { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-chip";

            if (Selected)
            {
                yield return "mdc-chip--selected";
            }
        }
    }
}