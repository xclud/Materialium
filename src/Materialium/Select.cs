using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Materialium
{
    public class Select : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "div");
            CaptureElementReference(builder, ref n);
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter]
        bool Outlined { get; set; }

        [Parameter]
        bool Disabled { get; set; }

        [Parameter]
        bool WithLeadingIcon { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-select";

            if (Outlined)
            {
                yield return Classes.Outlined;
            }

            if (Disabled)
            {
                yield return Classes.Disabled;
            }

            if (WithLeadingIcon)
            {
                yield return Classes.WithLeadingIcon;
            }
        }


        bool isFirstRender = true;

        protected override async Task OnAfterRenderAsync()
        {
            if (isFirstRender && ComponentContext.IsConnected)
            {
                await JSRuntime.InvokeAsync<object>("Materialium.select.init", element);
                isFirstRender = false;
            }
        }

        public static class Classes
        {
            public const string WithLeadingIcon = "mdc-select--with-leading-icon";
            public const string Disabled = "mdc-select--disabled";
            public const string Outlined = "mdc-select--outlined";
            public const string NativeControl = "mdc-select__native-control";
            public const string SelectedText = "mdc-select__selected-text";
            public const string DropdownIcon = "mdc-select__dropdown-icon";
            public const string Menu = "mdc-select__menu";
        }
    }
}