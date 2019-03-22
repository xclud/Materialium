using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    [Accepts(typeof(ButtonIcon), typeof(ButtonLabel))]
    public class Button : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            var n = OpenElementWithCommonAttributes(builder, string.IsNullOrWhiteSpace(Href) ? "button" : "a");

            if (Disabled)
            {
                builder.AddAttribute(n++, "disabled", "true");
            }

            if (!string.IsNullOrWhiteSpace(Href))
            {
                builder.AddAttribute(n++, "href", Href);

                if (!string.IsNullOrWhiteSpace(Title))
                {
                    builder.AddAttribute(n++, "title", Title);
                }

                if (!string.IsNullOrWhiteSpace(Target))
                {
                    builder.AddAttribute(n++, "target", Target);
                }
            }

            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter]
        bool Outlined { get; set; }

        [Parameter]
        bool Unelevated { get; set; }

        [Parameter]
        bool Raised { get; set; }

        [Parameter]
        bool Dense { get; set; }

        [Parameter]
        bool Disabled { get; set; }

        [Parameter]
        string Title { get; set; }

        [Parameter]
        string Target { get; set; }

        [Parameter]
        string Href { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-button";

            if (Outlined)
            {
                yield return Classes.Outlined;
            }

            if (Raised)
            {
                yield return Classes.Raised;
            }

            if (Unelevated)
            {
                yield return Classes.Unelevated;
            }

            if (Dense)
            {
                yield return Classes.Dense;
            }
        }

        public static class Classes
        {
            public const string Outlined = "mdc-button--outlined";
            public const string Raised = "mdc-button--raised";
            public const string Unelevated = "mdc-button--unelevated";
            public const string Dense = "mdc-button--dense";
        }
    }
}