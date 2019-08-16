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

        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder builder)
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
        public bool Scrollable { get; set; }

        [Parameter]
        public bool Stacked { get; set; }

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

        public async Task<string> ShowAsync()
        {
            var result = await JSRuntime.InvokeAsync<string>("Materialium.dialog.show", reference);
            return result;
        }

        public async Task CloseAsync(string action)
        {
            await JSRuntime.InvokeAsync<object>("Materialium.dialog.close", reference, action);
        }

        public Task CloseAsync()
        {
            return CloseAsync(null);
        }

        public async Task LayoutAsync()
        {
            await JSRuntime.InvokeAsync<object>("Materialium.dialog.layout", reference);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                reference = await JSRuntime.InvokeAsync<object>("Materialium.dialog.init", element);
            }
        }
    }
}