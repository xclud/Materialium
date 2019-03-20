using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
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
                yield return "mdc-button--outlined";
            }

            if (Raised)
            {
                yield return "mdc-button--raised";
            }

            if (Unelevated)
            {
                yield return "mdc-button--unelevated";
            }

            if (Dense)
            {
                yield return "mdc-button--dense";
            }
        }
    }
}