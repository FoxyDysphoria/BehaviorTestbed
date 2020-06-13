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

			NPC TestWolf = new NPC("Wolf", 70f, 60f, Personalities.EXTREMELY_DOMINANT, 30, 50f);


			string[] choices = { "Pass Time", "Check NPC", "Make NPC Climax" };
			bool finished = false;
			while (!finished)
			{
				switch (ConsoleIO.Input.PromptMenu(choices, "Pick an option", true)){
					case 0:
						finished = true;
						break;
					case 1:
						TestWolf.PassTime(PassTimeMenu());
						break;
					case 2:
						Console.WriteLine(TestWolf);
						break;
					case 3:
						TestWolf.Climax.TimeSinceLast = 0;
						TestWolf.SetArousalTo(0);
						TestWolf.SetFrustrationTo(0);
						TestWolf.UpdateNPC();
						break;
				}
			}
		}

		private static int PassTimeMenu()
		{
			return ConsoleIO.Input.PromptInt("By how many seconds?", 1, 9999);
		}
	}
}
