using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class LayoutGridCell : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "div");
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-layout-grid__cell";

            if (Desktop != null && Desktop > 0)
            {
                yield return $"mdc-layout-grid__cell--span-{Desktop}-desktop";
            }

            if (Tablet != null && Tablet > 0)
            {
                yield return $"mdc-layout-grid__cell--span-{Tablet}-tablet";
            }

            if (Phone != null && Phone > 0)
            {
                yield return $"mdc-layout-grid__cell--span-{Phone}-phone";
            }
        }

        [Parameter]
        public int? Desktop { get; set; }

        [Parameter]
        public int? Tablet { get; set; }

        [Parameter]
        public int? Phone { get; set; }
    }
}