using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class TextFieldHelperText : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "div");
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter]
        bool Persistent { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-text-field-helper-text";

            if (Persistent)
            {
                yield return "mdc-text-field-helper-text--persistent";
            }

        }
    }
}