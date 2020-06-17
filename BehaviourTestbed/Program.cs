using System;
using BehaviourTestbed.Models;
using ConsoleIO;

namespace BehaviourTestbed
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Testing of Behviors.");
			Console.WriteLine("v0.1");

			NPC TestWolf = new NPC("Wolf", 70, 60, Personalities.EXTREMELY_DOMINANT, 30, 50);
			NPC TestFox = new NPC("Fox", 50, 35, Personalities.SLIGHTLY_DOMINANT, 15, 70);


			string[] choices = { "Pass Time", "Check NPCs", "Make NPC Climax" };
			bool finished = false;
			while (!finished)
			{
				switch (ConsoleIO.Input.PromptMenu(choices, "Pick an option", true)) {
					case 0:
						finished = true;
						break;
					case 1:
						int timeToPass = PassTimeMenu();
						TestWolf.PassTime(timeToPass);
						TestFox.PassTime(timeToPass);
						break;
					case 2:
						Console.WriteLine(TestWolf);
						Console.WriteLine(TestFox);
						break;
					case 3:
						string[] NPCs = { "Wolf", "Fox" };
						switch (ConsoleIO.Input.PromptMenu(NPCs, "Which NPC do you want to climax?", false))
						{
							case 1:
								TestWolf.CauseClimax();
								break;
							case 2:
								TestFox.CauseClimax();
								break;
							default:
								break;
						}
						break;
				}
			}
		}

		private static int PassTimeMenu()
		{
			return ConsoleIO.Input.PromptInt("By how many seconds? (1, 9999)", 1, 9999);
		}
	}
}
