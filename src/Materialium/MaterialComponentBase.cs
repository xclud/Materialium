using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;

namespace Materialium
{
    public abstract class MaterialComponentBase : ComponentBase
    {
        internal ElementRef element;
        [Inject] internal IJSRuntime JSRuntime { get; set; }
        [Inject] internal IComponentContext ComponentContext { get; set; }

        internal MaterialComponentBase()
        {

        }

        [Parameter] public RenderFragment ChildContent { get; set; }

        [Parameter] public string Id { get; set; }
        [Parameter] public string Name { get; set; }

        [Parameter] public string Class { get; set; }

        [Parameter] public string Style { get; set; }

        [Parameter] public bool? Draggable { get; set; }

        [Parameter] public EventCallback<UIDragEventArgs> OnDrop { get; set; }
        [Parameter] public EventCallback<UIDragEventArgs> OnDragEnter { get; set; }
        [Parameter] public EventCallback<UIDragEventArgs> OnDragLeave { get; set; }
        [Parameter] public EventCallback<UIDragEventArgs> OnDragOver { get; set; }
        [Parameter] public EventCallback<UIDragEventArgs> OnDragStart { get; set; }
        [Parameter] public EventCallback<UIDragEventArgs> OnDragEnd { get; set; }
        [Parameter] public EventCallback<UIMouseEventArgs> OnClick { get; set; }
        [Parameter]
        public EventCallback<UIMouseEventArgs> OnMouseUp { get; set; }
        [Parameter]
        public EventCallback<UIMouseEventArgs> OnMouseDown { get; set; }
        [Parameter]
        public EventCallback<UIKeyboardEventArgs> OnKeyPress { get; set; }
        [Parameter]
        public EventCallback<UIKeyboardEventArgs> OnKeyDown { get; set; }
        [Parameter]
        public EventCallback<UIKeyboardEventArgs> OnKeyUp { get; set; }

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

            if (!string.IsNullOrWhiteSpace(Name))
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
            if (OnMouseDown.HasDelegate) builder.AddAttribute(n++, "onmousedown", OnMouseDown);

            if (OnKeyPress.HasDelegate) builder.AddAttribute(n++, "onkeypress", OnKeyPress);
            if (OnKeyUp.HasDelegate) builder.AddAttribute(n++, "onkeyup", OnKeyUp);
            if (OnKeyDown.HasDelegate) builder.AddAttribute(n++, "onkeydown", OnKeyDown);


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