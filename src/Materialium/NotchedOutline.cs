using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Materialium
{
    public class NotchedOutline : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "div");
            CaptureElementReference(builder, ref n);
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-notched-outline";
        }

        bool isFirstRender = true;

        protected override async Task OnAfterRenderAsync()
        {
            if (isFirstRender && ComponentContext.IsConnected)
            {
                await JSRuntime.InvokeAsync<object>("Materialium.notchedOutline.init", element);
                isFirstRender = false;
            }
        }
    }
}
