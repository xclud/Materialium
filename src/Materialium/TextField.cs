using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Materialium
{
    /// <summary>
    /// Text fields allow users to input, edit, and select text.
    /// </summary>
    public class TextField : MaterialComponentBase
    {


        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder builder)
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

        [Parameter] public bool Outlined { get; set; } = true;

        /// <summary>
        /// Full width text fields are useful for in-depth tasks or entering complex information.
        /// </summary>
        /// <remarks>
        /// <para>Do not use <see cref="Outlined"/> to style a full width text field.</para>
        /// <para>Do not use <see cref="FloatingLabel"/> within <see cref="FullWidth"/>. Labels should not be included as part of the DOM structure of a full width text field.</para>
        /// </remarks>
        [Parameter] public bool FullWidth { get; set; }

        [Parameter] public bool WithLeadingIcon { get; set; }

        [Parameter] public bool WithTrailingIcon { get; set; }

        [Parameter] public bool TextArea { get; set; }

        [Parameter] public bool Disabled { get; set; }

        [Obsolete("The --dense variant of the text field will be removed in an upcoming release. See https://github.com/material-components/material-components-web/issues/4142 for details.")]
        [Parameter] public bool Dense { get; set; }

        [Parameter] public bool Focused { get; set; }

        [Parameter] public bool NoLabel { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeAsync<object>("Materialium.textField.init", element);

            }
        }

        public static class Classes
        {
            public const string Input = "mdc-text-field__input";
        }
    }
}