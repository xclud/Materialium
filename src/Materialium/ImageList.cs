using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class ImageList : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "ul");
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter]
        bool Masonry { get; set; }

        [Parameter]
        bool WithTextProtection { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-image-list";

            if (Masonry)
            {
                yield return "mdc-image-list--masonry";
            }

            if (WithTextProtection)
            {
                yield return "mdc-image-list--with-text-protection";
            }
        }
    }
}