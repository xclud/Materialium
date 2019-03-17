using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialium
{
    [Accepts(typeof(GridLayoutInner))]
    public class GridLayout : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "div");
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-grid-layout";
        }
    }
}