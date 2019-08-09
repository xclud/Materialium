using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class FloatingActionButtonIcon : MaterialComponentBase
    {
        public FloatingActionButtonIcon()
        {
            Class = "material-icons";
        }

        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            //NOTE: The floating action button icon can be used with a span, i, img, or svg element.
            var n = OpenElementWithCommonAttributes(builder, "span");
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-fab__icon";
        }
    }
}