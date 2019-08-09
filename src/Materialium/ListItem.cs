using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class ListItem : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            var n = OpenElementWithCommonAttributes(builder, string.IsNullOrWhiteSpace(Href) ? "li" : "a");

            if (!string.IsNullOrWhiteSpace(Href))
            {
                builder.AddAttribute(n++, "href", Href);

                if (!string.IsNullOrWhiteSpace(Title))
                {
                    builder.AddAttribute(n++, "title", Title);
                }

                if (!string.IsNullOrWhiteSpace(Target))
                {
                    builder.AddAttribute(n++, "target", Target);
                }
            }

            CaptureElementReference(builder, ref n);

            builder.AddContent(n++, ChildContent);
            builder.CloseElement();

        }

        [Parameter]
        public string Href { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string Target { get; set; }

        [Parameter]
        public bool Activated { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public bool Selected { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-list-item";

            if (Activated)
            {
                yield return "mdc-list-item--activated";
            }

            if (Selected)
            {
                yield return "mdc-list-item--selected";
            }

            if (Disabled)
            {
                yield return "mdc-list-item--disabled";
            }
        }
    }
}