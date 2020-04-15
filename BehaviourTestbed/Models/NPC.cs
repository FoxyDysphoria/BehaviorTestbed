using System;
using System.Collections.Generic;
using System.Text;

namespace BehaviourTestbed.Models
{
	class NPC
	{

		//Internal props, used to drive behavior
		/// <summary>
		/// Float from 0 to 100 determining how aroused an NPC is.
		/// This affects things like erection amount, pre dripping, and more.
		/// Arousal is NOT hard capped at 100, and values at 90 or above cause
		/// an increase in Aggressiveness the longer it’s been since last climax.
		/// </summary>
		public float Arousal { get; private set; }

		/// <summary>
		/// Float from 0 to 100. Starts increasing once arousal is above 90 if not currently 
		/// being sexually pleased, and keeps increasing to 100 if no sexual relief is achieved. 
		/// Calculated by <c>Frustration = (Climax.TimeSinceLast - Refactory)/60</c>
		/// </summary>
		public float Frustration { get; private set; }

		/// <summary>
		/// Float, no clamps on value. Affected by things like Arousal, time 
		/// since last climax, and personality traits.
		/// Calculated by PersonalityMult * Frustration
		/// </summary>
		public float Aggressiveness { get; private set; }

		/// <summary>
		/// Affects how long it takes an NPC to reach climax
		/// </summary>
		public float Sensitivity { get; private set; }

		/// <summary>
		/// Time in seconds it takes before an NPC is ready to climax again.
		/// </summary>
		public int Refractory { get; private set; }

		public ClimaxInfo Climax { get; private set; }

		public Personalities Personality { get; private set; }

		//Props dictating appearance, species, etc
		public float Height { get; private set; }
		public float Length { get; private set; }
		public string Species { get; private set; }


		public NPC(string species, float length, float height, Personalities personality, int refractory, float sensitivity)
		{
			Species = species;
			Length = Length;
			Height = Height;
			Personality = personality;
			Refractory = refractory;
			Sensitivity = sensitivity;


			Climax.Length = 300f;
			Climax.PulseLength = 4f;
			Climax.OutputPerPulse = 100;
			Climax.TimeSinceLast = 1800;
		}
	
		public void SetArousalTo(float newArousal)
		{
			if (newArousal < 0) newArousal = 0;

			Arousal = newArousal;
		}

		public void SetFrustrationTo(float newFrustration)
		{
			if (newFrustration < 0f)
			{
				newFrustration = 0f;
			}
			else if (newFrustration > 100f)
			{
				newFrustration = 100f;
			}
			Frustration = newFrustration;
		}

		public void SetAggressivenessTo(float newAggro)
		{
			Aggressiveness = newAggro;
		}

		public void SetSensitivityTo(float newSensitivity)
		{
			if (newSensitivity < 0)
			{
				newSensitivity = 0;
			}
			else if (newSensitivity > 100)
			{
				newSensitivity = 100;
			}
			Sensitivity = newSensitivity;
		}

		public void SetRefractoryTo(int newRefractory)
		{
			if (newRefractory < 0)
			{
				newRefractory = 0;
			}
			else if (newRefractory > 300)
			{
				newRefractory = 300;
			}
			Refractory = newRefractory;
		}

		private void UpdateNPC()
		{
			if (Climax.TimeSinceLast - Refractory >= 0)
			{
				if (Climax.TimeSinceLast % 5 == 0)
				{
					if (Arousal < 100)
					{
						Arousal++;
					}
					else if (Climax.TimeSinceLast % 10 == 0)
					{
						Arousal++;
					}
				}
			}
			Frustration = ((float) Climax.TimeSinceLast - (float) Refractory) / 60;
			if (Frustration > 100)
			{
				Frustration = 100;
			}
			else if (Frustration < 0)
			{
				Frustration = 0;
			}
			Aggressiveness = (int) Personality * Frustration;
		}

		public void PassTime(int secondsToPass)
		{
			UpdateNPC();
			for (int i = 0; i < secondsToPass; i++)
			{
				Climax.TimeSinceLast++;
				UpdateNPC();
			}
		}

		public override string ToString()
		{
			string objectString = "";

			objectString += String.Format("NAME:\t\t{0}\nHEIGHT:\t\t{1}\nLENGTH:\t\t{2}\n====================================\n", Species, Height, Length);
			objectString += String.Format("AROUSAL:\t{0}\tFRUSTRATION:\t{1}\nAGRESSIVENESS:\t{2}\tSENSITIVITY:\t{3}\nREFRACTORY:\t{4}\tPERSONALITY:\t{5}\n====================================\n", Arousal, Frustration, Aggressiveness, Sensitivity, Refractory, Personality);
			objectString += String.Format("CLIMAX INFO:\n\tLENGTH: {0}\n\tPULSE LENGTH: {1}\n\tPULSE SIZE: {2}mL\n\tTIME SINCE LAST: {3}", Climax.Length, Climax.PulseLength, Climax.OutputPerPulse, Climax.TimeSinceLast);

			return objectString;
		}
	}

}
