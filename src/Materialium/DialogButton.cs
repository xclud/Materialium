using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class DialogButton : MaterialButton
    {
        [Parameter] public string Action { get; set; }
        [Parameter] public bool Default { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            var b = base.GetClasses();

            foreach (var c in b)
            {
                yield return c;
            }

            yield return "mdc-dialog__button";

            if(Default)
            {
                yield return "mdc-dialog__button--default";
            }
        }

        internal override void BuildAttributes(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder builder, ref int n)
        {
            if (!string.IsNullOrWhiteSpace(Action))
            {
                builder.AddAttribute(n++, "data-mdc-dialog-action", Action);
            }
        }
    }
}