using Xunit;

namespace PizzaApp
{
    public class OrderCalculatorTests
    {
        [Fact]
        public void Returns_sum_of_all_pieces_based_on_menu_prices()
        {
            Menu menu = ExampleMenu();
            Order order = ExampleOrder();

            var calculator = new OrderCalculator(menu);

            var result = calculator.Calculate(order);
            Assert.Equal(70, result.Value);
        }

        private static Order ExampleOrder()
        {
            var order = new Order();
            order.Add(new OrderPosition("Arek", 4, "Kebabowa"));
            order.Add(new OrderPosition("Jarek", 4, "Hawajska"));
            order.Add(new OrderPosition("Darek", 8, "Pepperoni"));
            return order;
        }

        private static Menu ExampleMenu()
        {
            var menu = new Menu();
            menu.Add(new MenuPosition("Kebabowa", 45));
            menu.Add(new MenuPosition("Hawajska", 35));
            menu.Add(new MenuPosition("Pepperoni", 30));
            return menu;
        }
    }
}