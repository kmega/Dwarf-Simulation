using System;
using System.Collections.Generic;
using System.Linq;
using BFC.Console.Animals;
using BFC.Console.Presentation;

namespace BFC.Console.Heroes
{
    public class Romantic : Person
    {
        private IOutputWritter _presenter;
        public Romantic()
        {
            _presenter = new WindowsConsole();
        }
        public Romantic(IOutputWritter presenter)
        {
            _presenter = presenter ?? new WindowsConsole();
        }

        public void DisplayActionInformation(IList<Animal> branch)
        {
            if (branch.Where(x => x.AnimalType == AnimalTypes.Child).Any())
            {
                _presenter.WriteLine("Child will be rescued by Romantic.");
            }
            else
            {
                _presenter.WriteLine("Nobody will be rescued by Romantic.");
            }
        }

        public void RescueAnimals(IList<Animal> branch)
        {
            var children = branch.Where(x => x.AnimalType == AnimalTypes.Child).ToList();
            if (children.Any())
            {
                for(int i = children.Count; i > 0; i--)
                {
                    branch.Remove(children[i-1]);
                }
                _presenter.WriteLine("Child will be rescued by Romantic.");
            }
            else
            {

            }
        }
    }
}
