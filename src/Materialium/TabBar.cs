﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Materialium
{
    public class TabBar : MaterialComponentBase
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
            yield return "mdc-tab-bar";
        }

        bool isFirstRender = true;
        protected override async Task OnAfterRenderAsync()
        {
            if (isFirstRender)
            {
                try
                {
                    await jsRuntime.InvokeAsync<object>("Materialium.tabBar.init", element);
                    isFirstRender = false;
                }
                catch { }
            }
        }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime jsRuntime { get; set; }
    }
}
