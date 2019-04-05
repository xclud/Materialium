using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class MaterialButton : ButtonBase
    {
        protected override IEnumerable<string> GetClasses()
        {
            yield return Classes.Button;

            var b = base.GetClasses();

            foreach (var c in b)
            {
                yield return c;
            }
        }
    }
}