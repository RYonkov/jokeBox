using System;
using WarCroft.Core;
using WarCroft.Core.IO;
using WarCroft.Core.IO.Contracts;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
            //var item1 = new FirePotion();
            //var item2 = new FirePotion();
            //var item3 = new FirePotion();
            //var Rado = new Priest("Rado");
            //Rado.Bag.AddItem(item1);

            //var Ivan = new Warrior("Ivan");

            //Ivan.Attack(Rado);

            //Rado.Heal(Ivan);

            //Console.WriteLine($"{Rado.Name} - {Rado.BaseHealth} - {Rado.BaseArmor} - {Rado.AbilityPoints}");

            //if (Rado.Bag.GetType().Name==nameof(Backpack))
            //{
            //    Console.WriteLine("Backpack");
            //}
            //else if (Rado.Bag.GetType().Name == nameof(Satchel))
            //{
            //    Console.WriteLine("Satchel");
            //}

            //Rado.UseItem(item1);

            //////var item4 = new FirePotion();
            //////var item5 = new FirePotion();
            //////var item6 = new FirePotion();
            ////var bag = new Backpack();
            ////bag.AddItem(item1);
            ////bag.AddItem(item2);
            ////bag.AddItem(item3);
            ////bag.GetItem("FirePotion");
            ////bag.GetItem("FirePotion");
            ////bag.GetItem("HealthPotion");


            ////bag2.AddItem(item3);
            ////bag2.AddItem(item2);
            ////bag2.AddItem(item1);
            ////bag2.AddItem(item4);
            ////bag2.AddItem(item5);


            ////Console.WriteLine(String.Join(", ", bag.Items.GetType().Name));





            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            var engine = new Engine(reader, writer);
            engine.Run();





            /* Use the below configuration instead of the usual one if you wish to print all output messages together after the inputs for easier comparison with the example output. */

            //IReader reader = new ConsoleReader();
            //var sbWriter = new StringBuilderWriter();

            //var engine = new Engine(reader, sbWriter);
            //engine.Run();

            //Console.WriteLine(sbWriter.sb.ToString().Trim());
        }
	}
}