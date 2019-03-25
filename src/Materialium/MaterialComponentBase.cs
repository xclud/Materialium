using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Materialium
{
    public abstract class MaterialComponentBase : ComponentBase
    {
        internal ElementRef element;

        [Parameter] internal RenderFragment ChildContent { get; set; }

        [Parameter] string Id { get; set; }
        [Parameter] string Name { get; set; }

        [Parameter] internal string Class { get; set; }

        [Parameter] string Style { get; set; }

        [Parameter] bool? Draggable { get; set; }

        [Parameter] EventCallback<UIDragEventArgs> OnDrop { get; set; }
        [Parameter] EventCallback<UIDragEventArgs> OnDragEnter { get; set; }
        [Parameter] EventCallback<UIDragEventArgs> OnDragLeave { get; set; }
        [Parameter] EventCallback<UIDragEventArgs> OnDragOver { get; set; }
        [Parameter] EventCallback<UIDragEventArgs> OnDragStart { get; set; }
        [Parameter] EventCallback<UIDragEventArgs> OnDragEnd { get; set; }
        [Parameter] EventCallback<UIMouseEventArgs> OnClick { get; set; }
        [Parameter]
        EventCallback<UIMouseEventArgs> OnMouseUp { get; set; }
        [Parameter]
        EventCallback<UIMouseEventArgs> OnMouseDown { get; set; }
        [Parameter]
        EventCallback<UIKeyboardEventArgs> OnKeyPress { get; set; }
        [Parameter]
        EventCallback<UIKeyboardEventArgs> OnKeyDown { get; set; }
        [Parameter]
        EventCallback<UIKeyboardEventArgs> OnKeyUp { get; set; }

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

            if (!string.IsNullOrWhiteSpace(Id))
            {
                builder.AddAttribute(n++, "id", Id);
            }

            if(!string.IsNullOrWhiteSpace(Name))
            {
                builder.AddAttribute(n++, "name", Name);
            }

            builder.AddAttribute(n++, "class", InternalClasses);

            if (HasStyle)
            {
                builder.AddAttribute(n++, "style", Style);
            }

            if (Draggable != null)
            {
                builder.AddAttribute(n++, "draggable", Draggable.Value.ToString().ToLower());
            }

            if (OnDragStart.HasDelegate)
            {
                builder.AddAttribute(n++, "ondragstart", OnDragStart);
            }

            if (OnDragEnd.HasDelegate)
            {
                builder.AddAttribute(n++, "ondragend", OnDragEnd);
            }

            if (OnDragEnter.HasDelegate) builder.AddAttribute(n++, "ondragenter", OnDragEnter);
            if (OnDragLeave.HasDelegate) builder.AddAttribute(n++, "ondragleave", OnDragLeave);
            if (OnDragOver.HasDelegate) builder.AddAttribute(n++, "ondragover", OnDragOver);
            if (OnDrop.HasDelegate) builder.AddAttribute(n++, "ondrop", OnDrop);


            if (OnClick.HasDelegate) builder.AddAttribute(n++, "onclick", OnClick);
            if (OnMouseUp.HasDelegate) builder.AddAttribute(n++, "onmouseup", OnMouseUp);


            return n;
        }

        internal void CaptureElementReference(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder, ref int n)
        {
            builder.AddElementReferenceCapture(n++, (__value) =>
            {
                this.element = __value;
            });
        }
    }
}