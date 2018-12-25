using System;
using System.Collections.Generic;
using System.IO;


namespace RegexTasks
{
    public class MenagerTask
    {
        public string Config { get; set; }
        private List<int> ChoosenTasks = new List<int>();
        //Odczytaj plik config z zadaniami -- > string

        public void DoTasks(string pathToConfig)
        {
            Tasks task = new Tasks();
            //Odczytaj plik config
            ReadConfig(pathToConfig);
            //pętla wykonuj dopóki istnieją elementy tablicy zadania
            for (int i = 0; i < ChoosenTasks.Count; i++)
            {
                //przełącz w zależności od podanego zadania
                switch (ChoosenTasks[i])
                {
                    //wykonaj wybrane zadanie

                    case 1:
                        {
                            task.TaskOne();
                            break;
                        }
                    case 2:
                        {
                            task.TaskTwo();
                            break;
                        }
                    case 3:
                        {
                            task.TaskThree();
                            break;
                        }
                    case 4:
                        {
                            task.TaskFour();
                            break;
                        }
                    case 6:
                        {
                            task.TaskSix();
                            break;
                        }
                    case 7:
                        {
                            task.TaskSeven();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Nieznane zadanie");
                            Console.ReadKey();
                            throw new ArgumentException();
                        }
                }
            }
          

        }

        public void ReadConfig(string pathToConfig)
        {
            

            FileSupporter configFileToRead = new FileSupporter();
            Config = configFileToRead.Read_File(pathToConfig);

            //Sparsuj plik otrzymując tylko numery zadań
            //Dodaj numery zadań do listy zadań

            ParseConfigAndAddTasksToList(Config, ChoosenTasks);

        }
       

        private void ParseConfigAndAddTasksToList(string Config, List<int> ChoosenTasks)
        {
            TextParser parserConfig = new TextParser();
            

             parserConfig.ExtractTasksFromConfig(Config, ChoosenTasks);

        }
    }
}