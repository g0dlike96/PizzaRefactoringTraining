namespace PizzaApp
{
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
}