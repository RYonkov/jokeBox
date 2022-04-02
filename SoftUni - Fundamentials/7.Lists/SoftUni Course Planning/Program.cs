using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;


namespace Lists.P4
{
	class Program
	{
		static void Main(string[] args)
		{
			List<string> courses = Console.ReadLine()
							   .Split(", ", StringSplitOptions.RemoveEmptyEntries)
							   .ToList();




			string command = Console.ReadLine();
			while (command != "course start")
			{
				string[] cmdArgs = command.Split(':', StringSplitOptions.RemoveEmptyEntries).ToArray();

				string action = cmdArgs[0];

				if (action == "Add")
				{
					string lessonTitle = cmdArgs[1].Trim();
					if (!courses.Contains(lessonTitle))
					{
						courses.Add(lessonTitle);
					}

				}
				else if (action == "Insert")
				{
					string lessonTitle = cmdArgs[1].Trim();
					int index = int.Parse(cmdArgs[2]);
					if (!courses.Contains(lessonTitle) && index>=0 && index<=courses.Count)
					{
						courses.Insert(index, lessonTitle);
					}
				}
				else if (action == "Remove")
				{
					string lessonTitle = cmdArgs[1].Trim();
                    //while (courses.Contains(lessonTitle))
                    //               {
                    //	courses.Remove(lessonTitle);
                    //	courses.Remove(lessonTitle + "-Exercises");
                    //               }

                    //courses.RemoveAll(x => x ==lessonTitle);
                    //courses.RemoveAll(x=>x==lessonTitle+"-Exercise");

                    if (courses.Contains(lessonTitle))
                    {
                        courses.Remove(lessonTitle);
                    }
                    lessonTitle = lessonTitle + "-Exercise";
                    if (courses.Contains(lessonTitle))
                    {
                        courses.Remove(lessonTitle);
                    }
                }
				else if (action == "Swap")
				{
					string lessonTitle1 = cmdArgs[1].Trim();
					string lessonTitle2 = cmdArgs[2].Trim();
					courses = SwapElements(courses, lessonTitle1, lessonTitle2);

					string lessonTitle1e = lessonTitle1 + "-Exercise";
					string lessonTitle2e = lessonTitle2 + "-Exercise";

					if (courses.Contains(lessonTitle1e))
					{
						courses.Remove(lessonTitle1e);
						int index = courses.IndexOf(lessonTitle1);
						courses.Insert(index + 1, lessonTitle1e);
					}

					if (courses.Contains(lessonTitle2e))
					{
						courses.Remove(lessonTitle2e);
						int index = courses.IndexOf(lessonTitle2);
						courses.Insert(index + 1, lessonTitle2e);
					}
				}
				else if (action == "Exercise")
				{
					string lessonTitle = cmdArgs[1].Trim();
					if (!courses.Contains(lessonTitle))
					{
						courses.Add(lessonTitle);
                        courses.Add(lessonTitle + "-Exercise");                        						
					}
                    else if (!courses.Contains(lessonTitle + "-Exercise"))
					{						                
						int index = courses.IndexOf(lessonTitle);						
						courses.Insert(index + 1, lessonTitle + "-Exercise");
					}
				}
				command = Console.ReadLine();
			}



			for (int i = 0; i < courses.Count; i++)
			{
				Console.WriteLine($"{i + 1}.{courses[i]}");
			}
		}

		public static List<string> SwapElements(List<string> myList, string element1, string element2)
		{

			int indexElement1 = -1;
			int indexLessonTitle2 = -1;

			if (myList.Contains(element1))
			{
				indexElement1 = myList.IndexOf(element1);
			}

			if (myList.Contains(element2))
			{
				indexLessonTitle2 = myList.IndexOf(element2);
			}
			if (indexElement1 != -1 && indexLessonTitle2 != -1)
			{
				if (indexElement1 > indexLessonTitle2)
				{
					int current = indexElement1;
					indexElement1 = indexLessonTitle2;
					indexLessonTitle2 = current;
				}

				myList.RemoveAt(indexLessonTitle2);
				myList.Insert(indexLessonTitle2, element1);

				myList.RemoveAt(indexElement1);
				myList.Insert(indexElement1, element2);
			
			}
			return myList;
		}
	}
}