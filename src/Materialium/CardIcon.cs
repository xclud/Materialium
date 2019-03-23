using System.Collections.Generic;

namespace Materialium
{
    public class CardIcon : IconButton
    {
        public CardIcon()
        {
            Class = "material-icons";
        }

        protected override IEnumerable<string> GetClasses()
        {
            var b = base.GetClasses();

            foreach (var c in b)
            {
                yield return c;
            }

            yield return "mdc-card__action";
            yield return "mdc-card__action--icon";
        }
    }
}