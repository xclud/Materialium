using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class ListItem : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
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
        string Href { get; set; }

        [Parameter]
        string Title { get; set; }

        [Parameter]
        string Target { get; set; }

        [Parameter]
        bool Activated { get; set; }

        [Parameter]
        bool Disabled { get; set; }

        [Parameter]
        bool Selected { get; set; }

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