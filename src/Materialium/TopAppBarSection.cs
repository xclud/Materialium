using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Materialium
{
    public class TopAppBarSection : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "section");
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter]
        bool AlignStart { get; set; }

        [Parameter]
        bool AlignEnd { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-top-app-bar__section";

            if (AlignStart)
            {
                yield return "mdc-top-app-bar__section--align-start";
            }

            if (AlignEnd)
            {
                yield return "mdc-top-app-bar__section--align-end";
            }
        }
    }
}