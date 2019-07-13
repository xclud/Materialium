using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class TabIndicator : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "div");
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter]
        public bool Active { get; set; }

        [Parameter]
        public bool Fade { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            List<string> classes = new List<string> { "mdc-tab-indicator" };

            if (Active)
            {
                classes.Add("mdc-tab-indicator--active");
            }

            if (Fade)
            {
                classes.Add("mdc-tab-indicator--fade");
            }

            return classes;
        }

        public static class Classes
        {
            /// <summary>
            /// Mandatory. Contains the tab indicator content.
            /// </summary>
            public const string TabIndicator = "mdc-tab-indicator";

            /// <summary>
            /// Mandatory. Denotes the tab indicator content.
            /// </summary>
            public const string Content = "mdc-tab-indicator__content";

            /// <summary>
            /// Optional. Visually activates the indicator.
            /// </summary>
            public const string Active = "mdc-tab-indicator--active";

            /// <summary>
            /// Optional. Sets up the tab indicator to fade in on activation and fade out on deactivation.
            /// </summary>
            public const string Fade = "mdc-tab-indicator--fade";

            /// <summary>
            /// Optional. Denotes an underline tab indicator.
            /// </summary>
            /// <remarks>
            /// Exactly one of the --underline or --icon content modifier classes should be present.
            /// </remarks>
            public const string ContentUnderline = "mdc-tab-indicator__content--underline";

            /// <summary>
            /// Optional. Denotes an icon tab indicator.
            /// </summary>
            /// <remarks>
            /// Exactly one of the --underline or --icon content modifier classes should be present.
            /// </remarks>
            public const string ContentIcon = "mdc-tab-indicator__content--icon";
        }
    }
}