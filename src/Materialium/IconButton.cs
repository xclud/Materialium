using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class IconButton : ButtonBase
    {
        [Parameter]
        bool On { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return Classes.IconButton;

            var b = base.GetClasses();

            foreach (var c in b)
            {
                yield return c;
            }

            if (On)
            {
                yield return "mdc-icon-button--on";
            }
        }
    }
}