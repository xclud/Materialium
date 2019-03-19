using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class IconButton : MaterialComponentBase
    {
        public const string Class = "mdc-icon-button";
        public const string Icon = "mdc-icon-button__icon";

        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, string.IsNullOrWhiteSpace(Href) ? "button" : "a");

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
        bool On { get; set; }

        [Parameter] string Href { get; set; }


        [Parameter]
        string Title { get; set; }

        [Parameter]
        string Target { get; set; }


        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-icon-button";

            if (On)
            {
                yield return "mdc-icon-button--on";
            }
        }
    }
}