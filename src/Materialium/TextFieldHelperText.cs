using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class TextFieldHelperText : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "div");
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter]
        public bool Persistent { get; set; }

        [Parameter]
        public bool ValidationMessage { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-text-field-helper-text";

            if (ValidationMessage)
            {
                yield return "mdc-text-field-helper-text--validation-msg";
            }

            if (Persistent)
            {
                yield return "mdc-text-field-helper-text--persistent";
            }

        }
    }
}