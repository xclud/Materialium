using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    /// <summary>
    /// The MDC Linear Progress component is a spec-aligned linear progress indicator component adhering to the Material Design progress & activity requirements.
    /// </summary>
    public class LinearProgress : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "div");
            builder.AddAttribute(n++, "role", "progressbar");
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter] bool Indeterminate { get; set; }
        [Parameter] bool Reversed { get; set; }
        [Parameter] bool Closed { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return Classes.LinearProgress;

            if (Indeterminate)
            {
                yield return Classes.Indeterminate;
            }

            if (Reversed)
            {
                yield return Classes.Reversed;
            }

            if (Closed)
            {
                yield return Classes.Closed;
            }
        }

        public static class Classes
        {
            public const string LinearProgress = "mdc-linear-progress";

            /// <summary>
            /// Puts the linear progress indicator in an indeterminate state.
            /// </summary>
            public const string Indeterminate = "mdc-linear-progress--indeterminate";

            /// <summary>
            /// Reverses the direction of the linear progress indicator.
            /// </summary>
            public const string Reversed = "mdc-linear-progress--reversed";

            /// <summary>
            /// Hides the linear progress indicator.
            /// </summary>
            public const string Closed = "mdc-linear-progress--closed";

            public const string BarInner = "mdc-linear-progress__bar-inner";

            public const string Bar = "mdc-linear-progress__bar";
            public const string PrimaryBar = "mdc-linear-progress__primary-bar";
            public const string SecondaryBar = "mdc-linear-progress__secondary-bar";
        }
    }
}