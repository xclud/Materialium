using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class CardActions : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "div");
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter]
        public bool FullBleed { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-card__actions";

            if (FullBleed)
            {
                yield return "mdc-card__actions--full-bleed";
            }
        }
    }
}