using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;

namespace Materialium
{
    public class DialogButton : Button
    {
        [Parameter] string Action { get; set; }
        [Parameter] bool Default { get; set; }

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

        internal override void BuildAttributes(RenderTreeBuilder builder, ref int n)
        {
            if (!string.IsNullOrWhiteSpace(Action))
            {
                builder.AddAttribute(n++, "data-mdc-dialog-action", Action);
            }
        }
    }
}