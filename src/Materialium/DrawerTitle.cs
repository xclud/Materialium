﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class DrawerTitle : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "h3");
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-drawer__title";
        }
    }
}