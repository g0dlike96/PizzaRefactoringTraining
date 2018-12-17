using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaApp
{
    public class Order
    {
        private List<OrderPosition> _items = new List<OrderPosition>();

        public IEnumerable<OrderPosition> Items => _items;

        internal void Add(OrderPosition orderPosition)
        {
            _items.Add(orderPosition);
        }

        internal bool IsValid()
        {
            return _items.Sum(p => p.Pieces) % 8 == 0 &&
                    _items.GroupBy(o => o.PizzaName)
                .Select(g => new
                {
                    PizzaName = g.Key,
                    Pieces = g.Sum(x => x.Pieces)
                })
                .All(x => x.Pieces % 4 == 0);
        }
    }
}