using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Materialium
{
    public class ListItemNavLink : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(0);
            builder.AddAttribute(1, "href", Href);
            builder.AddAttribute(2, "class", InternalClasses);
            builder.AddAttribute(3, "Match", Microsoft.AspNetCore.Components.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.Routing.NavLinkMatch>(Match));
            builder.AddAttribute(4, "ActiveClass", "mdc-list-item--activated");
            builder.AddAttribute(5, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((builder2) => {
                builder2.AddContent(6, "\r\n    ");
                builder2.OpenElement(7, "i");
                builder2.AddAttribute(8, "class", "material-icons mdc-list-item__graphic");
                builder2.AddAttribute(9, "aria-hidden", "true");
                builder2.AddContent(10, Icon);
                builder2.CloseElement();
                builder2.AddContent(11, "\r\n    ");
                builder2.OpenElement(12, "span");
                builder2.AddAttribute(13, "class", "mdc-list-item__text");
                builder2.AddContent(14, Text);
                builder2.CloseElement();
                builder2.AddContent(15, "\r\n");
            }
            ));
            builder.CloseComponent();
        }

        [Parameter] NavLinkMatch Match { get; set; } = NavLinkMatch.Prefix;
        [Parameter] string Icon { get; set; }
        [Parameter] string Text { get; set; }
        [Parameter] string Href { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-list-item";
        }
    }
}