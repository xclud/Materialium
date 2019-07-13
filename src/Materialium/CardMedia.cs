using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class CardMedia : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "div");
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter]
        public CardMediaRatio Ratio { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-card__media";

            if (Ratio == CardMediaRatio.Square)
            {
                yield return "mdc-card__media--square";
            }
            else if (Ratio == CardMediaRatio.SixteenByNine)
            {
                yield return "mdc-card__media--16-9";
            }
        }
    }

    public enum CardMediaRatio
    {
        None,
        Square,
        SixteenByNine
    }
}