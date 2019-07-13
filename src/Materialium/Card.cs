using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class Card : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "div");
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter]
        public bool Outlined { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return Classes.Main;

            if (Outlined)
            {
                yield return Classes.Outlined;
            }
        }

        public static class Classes
        {
            public const string Main = "mdc-card";
            public const string Outlined = "mdc-card--outlined";
            public const string PrimaryAction = "mdc-card__primary-action";
            public const string Media = "mdc-card__media";
            public const string MediaSquare = "mdc-card__media--square";
            public const string Media16by9 = "mdc-card__media--16-9";
            public const string MediaContent = "mdc-card__media-content";
            public const string Actions = "mdc-card__actions";
            public const string ActionsFullBleed = "mdc-card__actions--full-bleed";
            public const string ActionButtons = "mdc-card__action-buttons";
            public const string ActionIcons = "mdc-card__action-icons";
            public const string Action = "mdc-card__action";
            public const string ActionButton = "mdc-card__action--button";
            public const string ActionIcon = "mdc-card__action--icon";
        }
    }
}