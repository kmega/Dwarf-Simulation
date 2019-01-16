using System;
using System.Collections.Generic;
using System.Text;

namespace Socallship_v2
{
	public enum FieldType
	{
		EMPTY = 'o',
		HIT = 'X',
		MISS = 'm',
		DECK = 'S'
	}
	public enum ShipType
	{
		CARRIER = 1,
		BATTLESHIP = 2
	}
	public enum Direction
	{
		UP,
		DOWN,
		LEFT,
		RIGHT
	}
}
