using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BFC.Console.Animals;
using BFC.Console.Presentation;

namespace BFC.Console.Heroes
{
    public class Fireman: Person
    {
        private IOutputWritter _presenter;
        public Fireman()
        {
            _presenter = new WindowsConsole();
        }
        public Fireman(IOutputWritter presenter)
        {
            _presenter = presenter ?? new WindowsConsole();
        }
        public void RescueAnimals(IList<Animal> branch)
        {
            DisplayActionInformation(branch);
            for (int i = branch.Count; i > 0; i--)
            {
                switch (branch[i - 1].AnimalType)
                {
                    case AnimalTypes.Child:
                    case AnimalTypes.Cat:
                        branch.RemoveAt(i - 1);
                        break;
                }
            }
        }

        public void DisplayActionInformation(IList<Animal> branch)
        {
            if (branch.Where(x => x.AnimalType == AnimalTypes.Cat).Any()
           || branch.Where(x => x.AnimalType == AnimalTypes.Child).Any())
            {
                StringBuilder stringBuilder = new StringBuilder();
                if(branch.Where(x => x.AnimalType == AnimalTypes.Child).Any())
                {
                    stringBuilder.Append(AnimalTypes.Child.ToString());
                    if (branch.Where(x => x.AnimalType == AnimalTypes.Cat).Any())
                    {
                        stringBuilder.Append(", " + AnimalTypes.Cat.ToString() + " ");                        
                    }
                    else
                    {
                        stringBuilder.Append(" ");
                    }
                    stringBuilder.Append("will be rescued by Fireman.");
                }
                _presenter.WriteLine(stringBuilder.ToString());
            }
            else
            {
                _presenter.WriteLine("Nobody will be rescued by Fireman.");
            }
        }
    }
}
