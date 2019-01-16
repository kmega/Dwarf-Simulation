using System;
using System.Collections.Generic;
using System.Text;

namespace Socallship_v2
{
	public class Ship : IField
	{
		
		public Direction direction { get; private set; }
		public Field[] Deck;

		public List<Field> GetFields()
		{
			throw new NotImplementedException();
		}
	}
}
