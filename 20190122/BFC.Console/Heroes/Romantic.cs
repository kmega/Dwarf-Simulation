using System;
using System.Collections.Generic;
using BFC.Console.Animals;
using BFC.Console.AppLogic;

namespace BFC.Console.Heroes
{
    public class Romantic : Person
    {
        private bool _isBird;
        private bool _isCat;
        private bool _isChild;
        private TimeOfDay time;

        public Romantic()
        {

        }

        public Romantic(bool isBird, bool isCat, bool isChild, TimeOfDay time)
        {
            _isBird = isBird;
            _isCat = isCat;
            _isChild = isChild;
            this.time = time;
        }

        public void RescuAnimals(IList<Animal> branch)
        {
            for (int i = 0; i < branch.Count; i++)
            {
                if (branch[i].AnimalType == AnimalTypes.Child)
                {
                    branch.RemoveAt(i);
                }
            }

            if (_isChild == true && time == TimeOfDay.Fire)
                System.Console.WriteLine("Child will be rescued by Romantic.");
        }
    }
}
