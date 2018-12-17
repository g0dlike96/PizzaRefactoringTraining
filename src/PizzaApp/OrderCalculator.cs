using System.Linq;

namespace PizzaApp
{
    public class OrderCalculator
    {
        private Menu menu;

        public OrderCalculator(Menu menu)
        {
            this.menu = menu;
        }

        public Price Calculate(Order order)
        {
            var sumOfPositions = order.Items.Select(ResolvePrice).Sum();
            return new Price(sumOfPositions);
        }

        private double ResolvePrice(OrderPosition orderItem)
        {
            var price = menu.GetPizzaPrice(orderItem.PizzaName);
            var pricePerPiece = price.Value / 8.0;
            return orderItem.Pieces * pricePerPiece;
        }
    }
}