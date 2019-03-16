using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Materialium
{
    public abstract class MaterialComponentBase : ComponentBase
    {
        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        [Parameter]
        protected string Class { get; set; }

        [Parameter]
        protected string Style { get; set; }

        [Parameter]
        protected bool? Draggable { get; set; }

        [Parameter] protected EventCallback<UIDragEventArgs> OnDragEnd { get; set; }

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
    }
}