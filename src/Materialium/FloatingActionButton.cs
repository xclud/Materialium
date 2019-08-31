using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class FloatingActionButton : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, string.IsNullOrWhiteSpace(Href) ? "button" : "a");

            if (!string.IsNullOrWhiteSpace(Href))
            {
                builder.AddAttribute(n++, "href", Href);
            }

            CaptureElementReference(builder, ref n);
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter] public string Href { get; set; }
        [Parameter] public bool Mini { get; set; }
        [Parameter] public bool Extended { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-fab";

            if (Extended)
            {
                yield return "mdc-fab--extended";
            }

            if (Mini)
            {
                yield return "mdc-fab--mini";
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeAsync<object>("Materialium.ripple.init", new object[] { element });
            }
        }
    }
}