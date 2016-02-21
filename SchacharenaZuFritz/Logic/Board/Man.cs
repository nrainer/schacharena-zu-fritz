using System;

namespace SchacharenaZuFritz.Logic.Board
{
	public class Man
	{
		private readonly Player player;
		private readonly ManType manType;
		
		public Man(Player player, ManType manType)
		{
			this.player = player;
			this.manType = manType;
		}
		
		public ManType ManType
		{
			get { return manType; }
		}
		
		public Player Player
		{
			get { return player; }
		}
		
		public override string ToString()
		{
			return player + " " + manType;
		}

	}
}
