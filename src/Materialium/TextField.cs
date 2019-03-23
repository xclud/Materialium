using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Materialium
{
    public class TextField : MaterialComponentBase
    {
        [Inject] private IJSRuntime JsRuntime { get; set; }
        bool isFirstRender = true;

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
            yield return "mdc-text-field";

            if (TextArea)
            {
                yield return "mdc-text-field--textarea";
            }

            if (Outlined)
            {
                yield return "mdc-text-field--outlined";
            }

            if (FullWidth)
            {
                yield return "mdc-text-field--fullwidth";
            }

            if (WithLeadingIcon)
            {
                yield return "mdc-text-field--with-leading-icon";
            }

            if (WithTrailingIcon)
            {
                yield return "mdc-text-field--with-trailing-icon";
            }

#pragma warning disable CS0618
            if (Dense)
            {
                yield return "mdc-text-field--dense";
            }
#pragma warning enable CS0618

            if (Focused)
            {
                yield return "mdc-text-field--focused";
            }
            if (NoLabel)
            {
                yield return "mdc-text-field--no-label";
            }
            if (Disabled)
            {
                yield return "mdc-text-field--disabled";
            }
        }

        [Parameter] bool Outlined { get; set; } = true;

        [Parameter] bool FullWidth { get; set; }

        [Parameter] bool WithLeadingIcon { get; set; }

        [Parameter] bool WithTrailingIcon { get; set; }

        [Parameter] bool TextArea { get; set; }

        [Parameter] bool Disabled { get; set; }

        [Obsolete("The --dense variant of the text field will be removed in an upcoming release. See https://github.com/material-components/material-components-web/issues/4142 for details.")]
        [Parameter] bool Dense { get; set; }

        [Parameter] bool Focused { get; set; }

        [Parameter] bool NoLabel { get; set; }

        protected override async Task OnAfterRenderAsync()
        {
            if (isFirstRender)
            {
                try
                {
                    await JsRuntime.InvokeAsync<object>("Materialium.textField.init", element);
                    isFirstRender = false;
                }
                catch { }
            }
        }

        public static class Classes
        {
            public const string Input = "mdc-text-field__input";
        }
    }
}