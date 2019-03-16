using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    [Accepts(typeof(CardMedia), typeof(CardContent), typeof(CardPrimaryAction), typeof(CardActions))]
    public class Card : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            int n = 0;

            builder.OpenElement(n++, "div");
            AddCommonAttributes(builder, ref n);
            builder.CloseElement();
        }

        [Parameter]
        bool Outlined { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-card";

            if (Outlined)
            {
                yield return "mdc-card--outlined";
            }
        }
    }
}