using System.Collections.Generic;
using System.Linq;

namespace PizzaApp
{
    public class Menu
    {
        private IList<MenuPosition> _positions = new List<MenuPosition>();

        internal void Add(MenuPosition menuPosition)
        {
            _positions.Add(menuPosition);
        }

        internal Price GetPizzaPrice(string pizzaName)
        {
            return _positions.Single(x => x.PizzaName == pizzaName).Price;
        }
    }
}