using System;
using System.Collections.Generic;
using System.Text;

namespace Socallship
{
	public class Game
	{
		public Player Player1 { get; set; }
		public Player Player2 { get; set; }
		public Game()

		{
			Player1 = new Player("Janek");
			Player2 = new Player("Piotrek");

			Player1.PlaceShips();
			Player2.PlaceShips();

		}

		public void PlayOneRound()
		{

			int[] coordinates = getCoordinatesForHit();
			Player1.Hit(Player2, coordinates);
				
			if(!Player2.CheckIfLose())
			{
				int[] coordinates2 = getCoordinatesForHit();
				Player2.Hit(Player1, coordinates2);
			}
		}

		public void PlayingUntilSomeoneLose()
		{
			while(!Player1.CheckIfLose() && !Player2.CheckIfLose())
			{
				PlayOneRound();
			}
		}

		public int[] getCoordinatesForHit()
		{
			Console.WriteLine("Podaj koordynaty do strzału po przecinku: ");
			int[] coordinates = Array.ConvertAll(Console.ReadLine().Split(","),
		              delegate (string s) { return int.Parse(s); });

			return coordinates;
		}

	}
}
