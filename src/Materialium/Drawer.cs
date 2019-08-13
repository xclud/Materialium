using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Materialium
{
    public class Drawer : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "aside");
            CaptureElementReference(builder, ref n);
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter]
        public bool Modal { get; set; }

        [Parameter]
        public bool Dismissible { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-drawer";

            if (Modal)
            {
                yield return "mdc-drawer--modal";
            }

            if (Dismissible)
            {
                yield return "mdc-drawer--dismissible";
            }
        }

        bool isFirstRender = true;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (isFirstRender && ComponentContext.IsConnected)
            {
                await JSRuntime.InvokeAsync<object>("Materialium.drawer.init", element);
                isFirstRender = false;
            }
        }
    }
}