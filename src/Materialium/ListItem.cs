using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    [Accepts(typeof(ListItemGraphic), typeof(ListItemText))]
    public class ListItem : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            int n = 0;

            builder.OpenElement(n++, string.IsNullOrWhiteSpace(Href) ? "li" : "a");
            builder.AddAttribute(n++, "class", InternalClasses);

            if (HasStyle)
            {
                builder.AddAttribute(n++, "style", Style);
            }

            if (Draggable != null)
            {
                builder.AddAttribute(n++, "draggable", Draggable.Value.ToString().ToLower());
                builder.AddAttribute(n++, "ondragstart", "event.preventDefault();");
                builder.AddAttribute(n++, "ondragend", OnDragEnd);
            }

            if (!string.IsNullOrWhiteSpace(Href))
            {
                builder.AddAttribute(n++, "href", Href);
                builder.AddAttribute(n++, "title", Title);
            }

            builder.AddContent(n++, ChildContent);
            builder.CloseElement();

        }

        [Parameter]
        string Href { get; set; }

        [Parameter]
        string Title { get; set; }

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