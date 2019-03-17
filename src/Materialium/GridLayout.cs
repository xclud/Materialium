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
            int n = 0;
            base.BuildRenderTree(builder);
            builder.OpenElement(n++, "div");
            AddCommonAttributes(builder, ref n);
            builder.CloseElement();
        }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-grid-layout";
        }
    }
}