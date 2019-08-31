using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class Switch : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "div");
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter] public bool Checked { get; set; }
        [Parameter] public bool Disabled { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return Classes.Switch;

            if (Checked)
            {
                yield return Classes.Checked;
            }

            if (Disabled)
            {
                yield return Classes.Disabled;
            }
        }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeAsync<object>("Materialium.switch.init", new object[] { element });

            }
        }

        public static class Classes
        {
            public const string Switch = "mdc-switch";
            public const string Checked = "mdc-switch--checked";
            public const string Disabled = "mdc-switch--disabled";
            public const string Track = "mdc-switch__track";
            public const string ThumbOverlay = "mdc-switch__thumb-underlay";
            public const string Thumb = "mdc-switch__thumb";
            public const string NativeControl = "mdc-switch__native-control";
        }
    }
}