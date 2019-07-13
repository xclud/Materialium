using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class FloatingLabel : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "label");

            if(!string.IsNullOrWhiteSpace(For))
            {
                builder.AddAttribute(n++, "for", For);
            }

            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter] public bool FloatAbove { get; set; }

        [Parameter] public bool Shake { get; set; }

        [Parameter] public string For { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-floating-label";

            if (FloatAbove)
            {
                yield return Classes.FloatAbove;
            }

            if (Shake)
            {
                yield return Classes.Shake;
            }
        }

        public static class Classes
        {
            public const string FloatAbove = "mdc-floating-label--float-above";
            public const string Shake = "mdc-floating-label--shake";
        }
    }
}