using System;
using System.Collections.Generic;
using System.Text;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Market;
using MiningSimulatorByKPMM.Locations.Bank;
using MiningSimulatorByKPMM.PersonalItems;
using NUnit.Framework;
using MiningSimulatorByKPMM.DwarfsTypes;

namespace SimulationTests.Market_Tests
{
	public class FakeDwarfsListForTest
	{
		public List<Dwarf> FakeList()
		{
			List<Dwarf> dwarfsListTest = new List<Dwarf>();
			Dwarf Andrzej = new Dwarf(E_DwarfType.Dwarf_Father);
			Dwarf Andrzej2 = new Dwarf(E_DwarfType.Dwarf_Father);
			Dwarf Andrzej3 = new Dwarf(E_DwarfType.Dwarf_Father);
			Dwarf Andrzej4 = new Dwarf(E_DwarfType.Dwarf_Single);
			Dwarf Andrzej5 = new Dwarf(E_DwarfType.Dwarf_Single);
			Dwarf Andrzej6 = new Dwarf(E_DwarfType.Dwarf_Single);
			Dwarf Andrzej7 = new Dwarf(E_DwarfType.Dwarf_Sluggard);
			Dwarf Andrzej8 = new Dwarf(E_DwarfType.Dwarf_Sluggard);
			Dwarf Andrzej9 = new Dwarf(E_DwarfType.Dwarf_Suicide);

			Andrzej.BankAccount.ReceivedMoney(200);
			Andrzej2.BankAccount.ReceivedMoney(200);
			Andrzej3.BankAccount.ReceivedMoney(200);
			Andrzej4.BankAccount.ReceivedMoney(200);
			Andrzej5.BankAccount.ReceivedMoney(200);
			Andrzej6.BankAccount.ReceivedMoney(200);
			Andrzej7.BankAccount.ReceivedMoney(100);
			Andrzej8.BankAccount.ReceivedMoney(100);
			Andrzej9.BankAccount.ReceivedMoney(0);

			dwarfsListTest.Add(Andrzej);
			dwarfsListTest.Add(Andrzej2);
			dwarfsListTest.Add(Andrzej3);
			dwarfsListTest.Add(Andrzej4);
			dwarfsListTest.Add(Andrzej5);
			dwarfsListTest.Add(Andrzej6);
			dwarfsListTest.Add(Andrzej7);
			dwarfsListTest.Add(Andrzej8);
			dwarfsListTest.Add(Andrzej9);

			return dwarfsListTest;
		}
	}
}
