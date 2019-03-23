using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Materialium
{
    public class Dialog : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "div");
            builder.AddAttribute(n++, "role", "alertdialog");
            builder.AddAttribute(n++, "aria-modal", "true");
            CaptureElementReference(builder, ref n);
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter]
        bool Scrollable { get; set; }

        [Parameter]
        bool Stacked { get; set; }

        [Parameter]
        Action Opening { get; set; }

        [Parameter]
        Action Opened { get; set; }

        [Parameter]
        Action Closing { get; set; }

        [Parameter]
        Action Closed { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-dialog";

            if (Scrollable)
            {
                yield return "mdc-dialog--scrollable";
            }

            if (Stacked)
            {
                yield return "mdc-dialog--stacked";
            }
        }

        protected override async Task OnAfterRenderAsync()
        {
            try
            {
                await jsRuntime.InvokeAsync<object>("Materialium.dialog.show", element, Opening, Opened, Closing, Closed);
            }
            catch { }
        }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime jsRuntime { get; set; }
    }
}