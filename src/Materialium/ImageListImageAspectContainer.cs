﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class ImageListImageAspectContainer : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "div");
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-image-list__image-aspect-container";
        }
    }
}