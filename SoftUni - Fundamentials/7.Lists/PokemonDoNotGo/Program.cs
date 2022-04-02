using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;


namespace PokemonDoNotGot
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> pokemons = Console.ReadLine()
							   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
							   .Select(int.Parse)
							   .ToList();

            int totalSum = 0; 
            while (pokemons.Count!=0)
            {
				int index = int.Parse(Console.ReadLine());
				int current = 0;

                if (index<0)
                {                    
                    current = pokemons[0];
					pokemons[0]=pokemons[pokemons.Count-1];
					//pokemons.RemoveAt(pokemons.Count-1); - Beware that the last element should not be removed. 
                    UpdateList(pokemons, current);
                }
                else if (index>=pokemons.Count)
                {
                    current = pokemons[pokemons.Count-1];
                    pokemons[pokemons.Count - 1] = pokemons[0];
                    //pokemons.RemoveAt(0); - Beware that the first element should not be removed.
                    UpdateList(pokemons, current);
                }
                else
                {
                    current = pokemons[index];
                    pokemons.RemoveAt(index);
                    UpdateList(pokemons, current);
                }
                totalSum += current;

            }
            Console.WriteLine(totalSum);

		}

        private static void UpdateList(List<int> pokemons, int current)
        {
            for (int i = 0; i < pokemons.Count; i++)
            {
                if (pokemons[i]<=current)
                {
                    pokemons[i] += current;
                }
                else
                {
                    pokemons[i] -= current;
                }
            }
        }
    }
}