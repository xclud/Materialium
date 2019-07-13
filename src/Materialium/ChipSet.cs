using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class ChipSet : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "div");
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter] public bool Input { get; set; }
        [Parameter] public bool Choice { get; set; }
        [Parameter] public bool Filter { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-chip-set";

            if (Input)
            {
                yield return "mdc-chip-set--input";
            }

            if (Choice)
            {
                yield return "mdc-chip-set--choice";
            }

            if (Filter)
            {
                yield return "mdc-chip-set--filter";
            }
        }
    }
}