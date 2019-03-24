using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;

namespace Materialium
{
    [Accepts(typeof(ButtonIcon), typeof(ButtonLabel))]
    public class DialogButton : Button
    {
        [Parameter] string Action { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            var b = base.GetClasses();

            foreach (var c in b)
            {
                yield return c;
            }

            yield return "mdc-dialog__button";
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