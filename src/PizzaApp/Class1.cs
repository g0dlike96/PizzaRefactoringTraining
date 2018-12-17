using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PizzaApp
{
    public class PizzaTests
    {
        [Fact]
        public void Can_order_a_whole_pizza()
        {
            var order = new Order();
            order.Add(new OrderPosition("Arek", 8, "Kebabowa"));

            Assert.True(order.IsValid());
        }

        [Fact]
        public void When_order_has_not_8_pieces_it_should_not_validate()
        {
            var order = new Order();
            order.Add(new OrderPosition("Arek", 4, "Kebabowa"));
            order.Add(new OrderPosition("Marke", 3, "Kebabowa"));

            Assert.False(order.IsValid());
        }

        [Fact]
        public void When_order_has_8_pieces_of_4_different_kinds_it_should_not_validate()
        {
            var order = new Order();
            order.Add(new OrderPosition("Arek", 2, "Kebabowa"));
            order.Add(new OrderPosition("Marke", 2, "Pepperoni"));
            order.Add(new OrderPosition("Jarke", 2, "Fungi"));
            order.Add(new OrderPosition("Darke", 2, "Hawajska"));

            Assert.False(order.IsValid());
        }

        [Fact]
        public void When_ordering_two_kinds_of_pizza_4_pieces_each_should_validate()
        {
            var order = new Order();
            order.Add(new OrderPosition("Arek", 2, "Kebabowa"));
            order.Add(new OrderPosition("Jarek", 2, "Kebabowa"));
            order.Add(new OrderPosition("Darek", 2, "Pepperoni"));
            order.Add(new OrderPosition("Marek", 2, "Pepperoni"));

            Assert.True(order.IsValid());
        }

        [Fact]
        public void When_sum_of_pieces_is_not_divisible_by_8_should_not_order()
        {
            var order = new Order();
            order.Add(new OrderPosition("Arek", 4, "Kebabowa"));
            order.Add(new OrderPosition("Jarek", 4, "Hawajska"));
            order.Add(new OrderPosition("Darek", 4, "Pepperoni"));

            Assert.False(order.IsValid());
        }

        [Fact]
        public void When_ordering_two_halves_and_one_full_pizza_should_validate()
        {
            var order = new Order();
            order.Add(new OrderPosition("Arek", 4, "Kebabowa"));
            order.Add(new OrderPosition("Jarek", 4, "Hawajska"));
            order.Add(new OrderPosition("Darek", 8, "Pepperoni"));

            Assert.True(order.IsValid());
        }
    }

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

    internal class MenuPosition
    {
        public MenuPosition(string pizzaName, double price)
        {
            PizzaName = pizzaName;
            Price = new Price(price);
        }

        public string PizzaName { get; }
        public Price Price { get; }
    }

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
    public class Price
    {
        public Price(double value)
        {
            Value = value;
        }

        public double Value { get; }
    }

    public class OrderPosition
    {
        public OrderPosition(string name, int pieces, string pizzaName)
        {
            Name = name;
            Pieces = pieces;
            PizzaName = pizzaName;
        }

        public string Name { get; }
        public int Pieces { get; }
        public string PizzaName { get; }
    }

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