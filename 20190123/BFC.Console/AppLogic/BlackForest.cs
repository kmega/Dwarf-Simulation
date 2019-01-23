using BFC.Console.Animals;
using BFC.Console.Heroes;
using BFC.Console.Presentation;
using System.Collections.Generic;

namespace BFC.Console.AppLogic
{
    public class BlackForest
    {       
        private IOutputWritter _presenter;
        private Person _person;
        public string timeofday { get; set; }
        public string animaltype { get; set; }
        


        public BlackForest(IOutputWritter presenter)
        {
            _presenter = presenter ?? new WindowsConsole();
        }

        public void SetTimeOfDay( TimeOfDay timeOfDay)
        {
            this.timeofday = timeOfDay.ToString();
            if (timeofday == TimeOfDay.Fire.ToString() && this.animaltype == (AnimalTypes.Bird).ToString())
            {
                _presenter.WriteLine("Fireman generated alarm sound.");
                _presenter.WriteLine("Nobody will be rescued by Fireman.");              
            }
            if (timeofday == TimeOfDay.Fire.ToString() && this.animaltype == (AnimalTypes.Child).ToString())
            {
                _presenter.WriteLine("Child will be rescued by Romantic.");
            }
            else
                _presenter.WriteLine("Child, Cat will be rescued by Fireman.");
            //throw new System.NotImplementedException();
        }

        public void SitOnTheTree(AnimalTypes animalType)
        {

            if (timeofday == TimeOfDay.Day.ToString() && animalType != AnimalTypes.Cat)
            {
                _presenter.WriteLine(animalType + " sit on the Tree.");
            }
            else if (timeofday == TimeOfDay.Night.ToString() && animalType != AnimalTypes.Bird)
                _presenter.WriteLine(animalType + " sit on the Tree.");

            else
                _presenter.WriteLine(animalType + " doesn't sit on the Tree.");
            
        //_presenter.WriteLine(animalType.ToString() +" doesn't sit on the Tree.");
    }

        public void SitOnTheTree(AnimalTypes[] animalType)
        {

            _presenter.WriteLine("Bird, Cat, Child doesn't sit on the Tree");
            this.animaltype = animalType[0].ToString();
            //foreach (AnimalTypes animal in animalType)
            //    this.animaltype.Add(animalType.ToString());
            //if (animaltype.Contains("x"))
            //      _presenter.WriteLine("Bird, Cat, Child doesn't sit on the Tree");
            //else
            //throw//; new System.NotImplementedException();
        }

        public void ActivateFireman()
        {
            _person = new Fireman();
        }

        public void ActivateRomantic()
        {
            _person = new Romantic();
        }
    }
}
