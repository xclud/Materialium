using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class ButtonIcon : MaterialComponentBase
    {
        public ButtonIcon()
        {
            Class = "material-icons";
        }

        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "i");
            builder.AddAttribute(n++, "aria-hidden", "true");
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-button__icon";
        }
    }
}