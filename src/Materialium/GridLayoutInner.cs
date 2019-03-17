using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    [Accepts(typeof(GridLayoutCell))]
    public class GridLayoutInner : MaterialComponentBase
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
            yield return "mdc-layout-grid__inner";
        }
    }
}