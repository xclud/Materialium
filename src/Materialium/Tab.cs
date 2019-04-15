using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class Tab : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "button");

            builder.AddAttribute(n++, "role", "tab");

            if (Active)
            {
                builder.AddAttribute(n++, "aria-selected", Active);
            }

            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter]
        bool Active { get; set; }

        [Parameter]
        bool Stacked { get; set; }

        [Parameter]
        bool MinWidth { get; set; }


        protected override IEnumerable<string> GetClasses()
        {
            yield return Classes.Tab;

            if (Active)
            {
                yield return Classes.Active;
            }
            if (Stacked)
            {
                yield return Classes.Stacked;
            }

            if (MinWidth)
            {
                yield return Classes.MinWidth;
            }
        }

        public static class Classes
        {
            /// <summary>
            /// Mandatory.
            /// </summary>
            public const string Tab = "mdc-tab";

            /// <summary>
            /// Optional. Indicates that the tab is active.
            /// </summary>
            public const string Active = "mdc-tab--active";

            /// <summary>
            /// Optional. Indicates that the tab icon and label should flow vertically instead of horizontally.
            /// </summary>
            public const string Stacked = "mdc-tab--stacked";

            /// <summary>
            /// Optional. Indicates that the tab should shrink in size to be as narrow as possible without causing text to wrap.
            /// </summary>
            public const string MinWidth = "mdc-tab--min-width";

            /// <summary>
            /// Mandatory. Denotes the ripple surface for the tab.
            /// </summary>
            public const string Ripple = "mdc-tab__ripple";

            /// <summary>
            /// Mandatory. Indicates the text label of the tab.
            /// </summary>
            public const string Content = "mdc-tab__content";

            /// <summary>
            /// Optional. Indicates a leading icon in the tab.
            /// </summary>
            public const string Icon = "mdc-tab__icon";

            /// <summary>
            /// Optional. Indicates an icon in the tab.
            /// </summary>
            public const string TextLabel = "mdc-tab__text-label";

            public const string TabBar = "mdc-tab-bar";
        }
    }
}