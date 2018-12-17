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
}