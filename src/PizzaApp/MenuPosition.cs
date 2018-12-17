namespace PizzaApp
{
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
}