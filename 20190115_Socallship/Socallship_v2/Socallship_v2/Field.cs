namespace Socallship_v2
{
	public class Field
	{
		public int X { get; set; }
		public int Y { get; set; }
		public FieldType Type { get; set; }


		public Field(int row, int column, FieldType type)
		{
			X = row;
			Y = column;
			Type = type;
		}
	}
}