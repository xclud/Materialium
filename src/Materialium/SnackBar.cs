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
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "div");
            CaptureElementReference(builder, ref n);
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter] bool Open { get; set; }
        [Parameter] bool Leading { get; set; }
        [Parameter] bool Stacked { get; set; }

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

        bool isFirstRender = true;
        protected override async Task OnAfterRenderAsync()
        {
            if (isFirstRender && ComponentContext.IsConnected)
            {
                await JSRuntime.InvokeAsync<object>("Materialium.snackbar.init", element);
                isFirstRender = false;
            }
        }
    }
}