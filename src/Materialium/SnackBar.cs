using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Materialium
{
    public class SnackBar : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "div");
            CaptureElementReference(builder, ref n);
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter] public bool Open { get; set; }
        [Parameter] public bool Leading { get; set; }
        [Parameter] public bool Stacked { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-snackbar";

            if (Open)
            {
                yield return "mdc-snackbar--open";
            }

            if (Leading)
            {
                yield return "mdc-snackbar--leading";
            }

            if (Stacked)
            {
                yield return "mdc-snackbar--stacked";
            }
        }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeAsync<object>("Materialium.snackbar.init", element);

            }
        }
    }
}