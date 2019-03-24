using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Materialium
{
    public class Dialog : MaterialComponentBase
    {
        private object reference;

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

        public async Task<object> ShowAsync()
        {
            var result = await jsRuntime.InvokeAsync<object>("Materialium.dialog.show", reference);
            return result;
        }

        protected override async Task OnAfterRenderAsync()
        {
            try
            {
                reference = await jsRuntime.InvokeAsync<object>("Materialium.dialog.init", element);
            }
            catch(Exception exp) { }
        }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime jsRuntime { get; set; }
    }
}