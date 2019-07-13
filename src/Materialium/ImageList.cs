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
        public bool Masonry { get; set; }

        [Parameter]
        public bool WithTextProtection { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return Classes.ImageList;

            if (Masonry)
            {
                yield return Classes.Masonry;
            }

            if (WithTextProtection)
            {
                yield return Classes.WithTextProtection;
            }
        }

        public static class Classes
        {
            /// <summary>
            /// Mandatory. Indicates the root Image List element.
            /// </summary>
            public const string ImageList = "mdc-image-list";

            /// <summary>
            /// Optional. Indicates that this Image List should use the Masonry variant.
            /// </summary>
            public const string Masonry = "mdc-image-list--masonry";

            /// <summary>
            /// Optional. Indicates that supporting content should be positioned in a scrim overlaying each image (instead of positioned separately under each image).
            /// </summary>
            public const string WithTextProtection = "mdc-image-list--with-text-protection";

            /// <summary>
            /// Mandatory. Indicates each item in an Image List.
            /// </summary>
            public const string Item = "mdc-image-list__item";

            /// <summary>
            /// Optional. Parent of each item's image element, responsible for constraining aspect ratio. This element may be omitted entirely if images are already sized to the correct aspect ratio.
            /// </summary>
            public const string ImageAspectContainer = "mdc-image-list__image-aspect-container";

            /// <summary>
            /// Mandatory. Indicates the image element in each item.
            /// </summary>
            public const string Image = "mdc-image-list__image";

            /// <summary>
            /// Optional. Indicates the area within each item containing the supporting text label, if the Image List contains text labels.
            /// </summary>
            public const string Supporting = "mdc-image-list__supporting";

            /// <summary>
            /// Optional. Indicates the text label in each item, if the Image List contains text labels.
            /// </summary>
            public const string Label = "mdc-image-list__label";
        }
    }
}