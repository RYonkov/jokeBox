//using System;
//using System.Collections.Generic;           //For Dictionaries, stacks and queues
//using System.Diagnostics;                   //For clock, stopwatch
//using System.Globalization;                 //For regional specifics
//using System.Linq;                          //For lambda expressions
//using System.Numerics;                      //For BigInteger
//using System.Text;                          //For StringBuilder
//using System.Text.RegularExpressions;       //For Regex

//namespace _01._Tiles_Master
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            //Using stack for the white tiles
//            int[] input1 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
//            Stack<int> white = new Stack<int>(input1);

//            //Using queue for the grey tiles
//            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
//            Queue<int> grey = new Queue<int>(input);

//            //Using Dictionary for storing the locations
//            Dictionary<string, int> location = new Dictionary<string, int>();



//            while ((grey.Count > 0 && white.Count > 0))
//            {
//                //Initializing of major variables to process before each iteration
//                int currentGrey = grey.Dequeue();
//                int currentWhite = white.Pop();

//                //Adding location depending on the exact area
//                switch (currentGrey + currentWhite)
//                {
//                    case 40:
//                        {
//                            AddLocation(location, "Sink");
//                            break;
//                        }
//                    case 50:
//                        {
//                            AddLocation(location, "Oven");
//                            break;
//                        }
//                    case 60:
//                        {
//                            AddLocation(location, "Countertop");
//                            break;
//                        }
//                    case 70:
//                        {
//                            AddLocation(location, "Wall");
//                            break;
//                        }
//                    default:
//                        {
//                            if (currentWhite == currentGrey)
//                            {
//                                AddLocation(location, "Floor");
//                                break;
//                            }
//                            else 
//                            {
//                                currentWhite /= 2;
//                                white.Push(currentWhite);
//                                grey.Enqueue(currentGrey);
//                                break;
//                            }

//                        }
//                }
//            }

//            if (white.Count == 0)
//            {
//                Console.WriteLine("White tiles left: none");
//            }
//            else
//            {
//                Console.WriteLine($"White tiles left: {String.Join(", ", white)}");
//            }


//            if (grey.Count == 0)
//            {
//                Console.WriteLine("Grey tiles left: none");
//            }
//            else
//            {
//                Console.WriteLine($"Grey tiles left: {String.Join(", ", grey)}");
//            }

//            var output = location.OrderByDescending(x => x.Value).ThenBy(x => x.Key);
//            foreach (var element in output)
//            {
//                Console.WriteLine($"{element.Key}: {element.Value}");
//            }
//        }

//        public static void AddLocation(Dictionary<string, int> location, string place)
//        {
//            if (!location.ContainsKey(place))
//            {
//                location.Add(place, 1);
//            }
//            else
//            {
//                location[place] += 1;
//            }
//        }

//    }
//}





using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> tilesPut = new Dictionary<string, int>()
            {
                {"Countertop", 0},
                {"Floor", 0},
                {"Oven", 0},
                {"Sink", 0},
                {"Wall", 0}
            };

            int[] whiteInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> whiteTiles = new Stack<int>(whiteInput);
            int[] greyInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> greyTiles = new Queue<int>(greyInput);

            while (true)
            {
                if (whiteTiles.Count == 0 || greyTiles.Count == 0)
                {
                    break;
                }

                int curWhite = whiteTiles.Pop();
                int curGrey = greyTiles.Dequeue();

                if (curWhite == curGrey)
                {
                    int tileSize = curWhite + curGrey;

                    if (tileSize == 40)
                    {
                        tilesPut["Sink"]++;
                    }
                    else if (tileSize == 50)
                    {
                        tilesPut["Oven"]++;
                    }
                    else if (tileSize == 60)
                    {
                        tilesPut["Countertop"]++;
                    }
                    else if (tileSize == 70)
                    {
                        tilesPut["Wall"]++;
                    }
                    else
                    {
                        tilesPut["Floor"]++;
                    }
                }
                else
                {
                    curWhite /= 2;
                    whiteTiles.Push(curWhite);
                    greyTiles.Enqueue(curGrey);
                }
            }

            if (whiteTiles.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }

            if (greyTiles.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
            }

            foreach (var pair in tilesPut.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Where(x => x.Value != 0))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
    }
}
