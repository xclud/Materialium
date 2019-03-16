﻿using System;
using System.Collections.Generic;

namespace Materialium
{
    public class ListItemText : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            int n = 0;
            builder.OpenElement(n++, "span");
            AddCommonAttributes(builder, ref n);

            builder.CloseElement();
        }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-list-item__text";
        }
    }
}