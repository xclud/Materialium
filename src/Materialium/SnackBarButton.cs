using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;

namespace Materialium
{
    public class SnackBarButton : MaterialButton
    {
        [Parameter] bool Dismiss { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            var b = base.GetClasses();

            foreach (var c in b)
            {
                yield return c;
            }


            if (Dismiss)
            {
                yield return "mdc-snackbar__dismiss";
            }
            else
            {

                yield return "mdc-snackbar__action";
            }
        }
    }
}