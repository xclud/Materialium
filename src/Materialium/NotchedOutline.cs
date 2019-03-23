using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Materialium
{
    [Accepts(typeof(NotchedOutlineLeading), typeof(NotchedOutlineNotch), typeof(NotchedOutlineTrailing))]
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
            if (isFirstRender)
            {
                try
                {
                    await jsRuntime.InvokeAsync<object>("Materialium.notchedOutline.init", element);
                    isFirstRender = false;
                }
                catch { }
            }
        }

        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime jsRuntime { get; set; }
    }
}
