﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    [Accepts(typeof(CardButtons), typeof(CardIcons), typeof(CardButton))]
    public class CardActions : MaterialComponentBase
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
        bool FullBleed { get; set; }

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