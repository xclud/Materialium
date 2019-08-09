using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class SliderThumbCircle : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "circle");
            builder.AddAttribute(n++, "cx", "10.5");
            builder.AddAttribute(n++, "cy", "10.5");
            builder.AddAttribute(n++, "r", "7.875");
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        protected override IEnumerable<string> GetClasses()
        {
            yield return Slider.Classes.Thumb;
        }
    }
}