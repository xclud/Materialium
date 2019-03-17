using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Materialium
{
    public abstract class MaterialComponentBase : ComponentBase
    {
        [Parameter] internal RenderFragment ChildContent { get; set; }

        [Parameter] string Class { get; set; }

        [Parameter] string Style { get; set; }

        [Parameter] bool? Draggable { get; set; }

        [Parameter] bool? Droppable { get; set; }

        [Parameter] EventCallback<UIDragEventArgs> OnDragStart { get; set; }
        [Parameter] EventCallback<UIDragEventArgs> OnDragEnd { get; set; }
        [Parameter] EventCallback<UIMouseEventArgs> OnClick { get; set; }

        [Parameter] string OnDragOver { get; set; } = "event.preventDefault();";

        protected abstract IEnumerable<string> GetClasses();

        internal string InternalClasses
        {
            get
            {
                List<string> classes = new List<string>(GetClasses());

                if (!string.IsNullOrWhiteSpace(Class))
                {
                    classes.Add(Class.Trim());
                }

                return string.Join(" ", classes).Trim();
            }
        }

        internal bool HasStyle
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Style);
            }
        }

        internal int OpenElementWithCommonAttributes(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder, string elementName)
        {
            int n = 0;
            builder.OpenElement(n++, elementName);

            builder.AddAttribute(n++, "class", InternalClasses);

            if (HasStyle)
            {
                builder.AddAttribute(n++, "style", Style);
            }

            if (Draggable != null)
            {
                builder.AddAttribute(n++, "draggable", Draggable.Value.ToString().ToLower());
                builder.AddAttribute(n++, "ondragstart", OnDragStart);
                builder.AddAttribute(n++, "ondragend", OnDragEnd);
            }

            if (Droppable != null)
            {
                builder.AddAttribute(n++, "ondragover", OnDragOver);
            }

            if (OnClick.HasDelegate)
            {
                builder.AddAttribute(n++, "onclick", OnClick);
            }

            return n;
        }
    }
}