using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Materialium
{
    public class TopAppBar : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "header");
            CaptureElementReference(builder, ref n);
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter]
        public bool Fixed { get; set; }

        [Parameter]
        public bool Short { get; set; }

        [Parameter]
        public bool Collapsed { get; set; }

        [Parameter]
        public bool Prominent { get; set; }

        [Parameter]
        public bool Dense { get; set; }

        [Parameter]
        public string ScrollTarget { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-top-app-bar";

            if (Fixed)
            {
                yield return "mdc-top-app-bar--fixed";
            }

            if (Short)
            {
                yield return "mdc-top-app-bar--short";
            }

            if (Collapsed)
            {
                yield return "mdc-top-app-bar--short-collapsed";
            }

            if (Prominent)
            {
                yield return "mdc-top-app-bar--prominent";
            }

            if (Dense)
            {
                yield return "mdc-top-app-bar--dense";
            }
        }

        bool isFirstRender = true;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (isFirstRender && ComponentContext.IsConnected)
            {
                await JSRuntime.InvokeAsync<object>("Materialium.topAppBar.init", element, ScrollTarget);
                isFirstRender = false;

            }
        }
    }
}