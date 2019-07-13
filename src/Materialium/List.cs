using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class List : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, Navigation ? "nav" : "ul");
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter]
        public bool TwoLine { get; set; }

        [Parameter]
        public bool Avatars { get; set; }

        [Parameter]
        public bool Dense { get; set; }

        [Parameter]
        public bool NonInteractive { get; set; }

        [Parameter]
        public bool Navigation { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            List<string> classes = new List<string> { "mdc-list" };

            if (NonInteractive)
            {
                classes.Add("mdc-list--non-interactive");
            }

            if (TwoLine)
            {
                classes.Add("mdc-list--two-line");
            }

            if (Avatars)
            {
                classes.Add("mdc-list--avatar-list");
            }

            if (Dense)
            {
                classes.Add("mdc-list--dense");
            }

            return classes;
        }
    }
}