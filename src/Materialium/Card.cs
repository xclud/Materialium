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
            var n = OpenElementWithCommonAttributes(builder, "div");
            builder.AddContent(n++, ChildContent);
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