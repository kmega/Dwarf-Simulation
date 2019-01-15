namespace Socallship_v2
{
	public class Field
	{
		public int X { get; set; }
		public int Y { get; set; }


		public Field(int row, int column)
		{
			X = row;
			Y = column;
		}
	}
}