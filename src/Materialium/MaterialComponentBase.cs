using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;

namespace Materialium
{
    public abstract class MaterialComponentBase : ComponentBase
    {
        internal ElementReference element;
        [Inject] internal IJSRuntime JSRuntime { get; set; }

        internal MaterialComponentBase()
        {

        }

        [Parameter] public RenderFragment ChildContent { get; set; }

        [Parameter] public string Id { get; set; }
        [Parameter] public string Name { get; set; }

        [Parameter] public string Class { get; set; }

        [Parameter] public string Style { get; set; }

        [Parameter] public bool? Draggable { get; set; }

        [Parameter] public EventCallback OnDrop { get; set; }
        [Parameter] public EventCallback OnDragEnter { get; set; }
        [Parameter] public EventCallback OnDragLeave { get; set; }
        [Parameter] public EventCallback OnDragOver { get; set; }
        [Parameter] public EventCallback OnDragStart { get; set; }
        [Parameter] public EventCallback OnDragEnd { get; set; }
        [Parameter] public EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs> OnClick { get; set; }
        [Parameter]
        public EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs> OnMouseUp { get; set; }
        [Parameter]
        public EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs> OnMouseDown { get; set; }
        [Parameter]
        public EventCallback OnKeyPress { get; set; }
        [Parameter]
        public EventCallback OnKeyDown { get; set; }
        [Parameter]
        public EventCallback OnKeyUp { get; set; }

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

        internal int OpenElementWithCommonAttributes(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder builder, string elementName)
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

        internal void CaptureElementReference(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder builder, ref int n)
        {
            builder.AddElementReferenceCapture(n++, (__value) =>
            {
                this.element = __value;
            });
        }
    }
}