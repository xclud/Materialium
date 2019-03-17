using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class FormField : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "div");
            builder.CloseElement();
        }

        [Parameter]
        bool AlignEnd { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-form-field";

            if (AlignEnd)
            {
                yield return "mdc-form-field--align-end";
            }
        }
    }
}