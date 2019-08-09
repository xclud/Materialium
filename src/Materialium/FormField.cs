using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    /// <summary>
    /// MDC Form Field aligns an MDC Web form field (for example, <see cref="Checkbox"/>) with its label and makes it RTL-aware. It also activates a ripple effect upon interacting with the label.
    /// </summary>
    public class FormField : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "div");
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter]
        public bool AlignEnd { get; set; }

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