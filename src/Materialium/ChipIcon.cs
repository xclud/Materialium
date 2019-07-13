using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class ChipIcon : MaterialComponentBase
    {
        public ChipIcon()
        {
            Class = "material-icons";
        }
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "i");
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter] public bool Leading { get; set; }
        [Parameter] public bool LeadingHidden { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-chip__icon";

            if (Leading)
            {
                yield return "mdc-chip__icon--leading";

                if(LeadingHidden)
                {
                    yield return "mdc-chip__icon--leading-hidden";
                }
            }
            else
            {
                yield return "mdc-chip__icon--trailing";
            }
        }
    }
}