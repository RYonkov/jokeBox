
namespace Restaurant
{
    public class Fish : MainDish
    {
        public Fish(string name, decimal price) : base(name, price, fishGrams)
        {
        }

        private const double fishGrams = 22; 
    }
}
