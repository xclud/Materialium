using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class LinearProgressBar : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "div");
            builder.AddAttribute(n++, "role", "progressbar");
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter]
        public bool Primary { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return LinearProgress.Classes.Bar;

            if (Primary)
            {
                yield return LinearProgress.Classes.PrimaryBar;
            }
            else
            {
                yield return LinearProgress.Classes.SecondaryBar;
            }
        }
    }
}