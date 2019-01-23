using BFC.Console.Animals;
using BFC.Console.Heroes;
using BFC.Console.Presentation;
using System.Collections.Generic;

namespace BFC.Console.AppLogic
{
    public class RescueMission
    {
        public void Help(IOutputWritter iow, Person helper, List<Animal> branch,bool SpeakerActivator)
        {
            if (helper is Fireman)
            {
                FiremanWay(iow, helper, branch, SpeakerActivator);
            }
            else
            {
                RomanticWay(iow, helper, branch);

            }

        }

        private void SpeakerWork (List<Animal> branch)
        {
            branch.Clear();

        }

        private void FiremanWay (IOutputWritter iow, Person helper, List<Animal> branch, bool SpeakerActivator)
        {
           
            List<string> rescuedanimals  = new List<string>();
           

            if (branch.Exists(x => x.AnimalType == AnimalTypes.Child))
            {
                string child = "Child";
                rescuedanimals.Add(child);

            }

            if ((branch.Exists(x => x.AnimalType == AnimalTypes.Cat)))

            {
               string cat = "Cat";
                rescuedanimals.Add(cat);
                
              
            }

            if (rescuedanimals.Count > 0)
            {
                iow.WriteLine(string.Join(", ", rescuedanimals) + " will be rescued by Fireman.");
            }
            else
            {
                iow.WriteLine("Nobody will be rescued by Fireman.");
            }

            if (branch.Exists(x => x.AnimalType == AnimalTypes.Bird))
            {
            
                iow.WriteLine("Fireman generated alarm sound.");
                SpeakerActivator = true;
               
            }

            helper.RescuAnimals(branch);

            

            if (SpeakerActivator)
            {
                SpeakerWork(branch);
            }

        }



        private void RomanticWay(IOutputWritter iow, Person helper, List<Animal> branch)
        {
         

             if (branch.Exists(x => x.AnimalType == AnimalTypes.Child))
            {

                iow.WriteLine("Child will be rescued by Romantic.");

            }
            else  
            {
               
                iow.WriteLine("Nobody will be rescued by Romantic.");
            }
            helper.RescuAnimals(branch);

        }
    }
}