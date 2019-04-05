using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class CardButton : MaterialButton
    {
        protected override IEnumerable<string> GetClasses()
        {
            var b = base.GetClasses();

            foreach (var c in b)
            {
                yield return c;
            }

            yield return "mdc-card__action";
            yield return "mdc-card__action--button";
        }
    }
}