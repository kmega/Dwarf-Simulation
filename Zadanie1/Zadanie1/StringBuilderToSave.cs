using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class StringBuilderToSave
    {
        
        public static string[] BuildStringToSaveTask(string fullName, int time)
        {
            return new[] { $"{fullName} był budowany {time.ToString()} minuty" };
        }
        public static string[] BuildStringToSaveTask(TimeSpan totalTimeToBuildHeroes)
        {
            return new[] { $"Wszystkie postacie do tej pory budowane były " +
                $"{totalTimeToBuildHeroes.Hours} godzin i {totalTimeToBuildHeroes.Minutes} minut." };
        }
        public static string[] BuildStringToSaveTask(List<string> names, int allTimeAssessed, int averageTime)
        {
            List<string> toSave = new List<string>();
            toSave.Add("Postacie które nie mają podanego czasu:");
            foreach(var name in names)
            {
                toSave.Add(name);
            }
            toSave.Add($"Średni czas budowania postaci to: {averageTime} minut");
            TimeSpan allTimeChanged = TimeSpan.FromMinutes(allTimeAssessed);
            toSave.Add($"Uwzględniając powyższe, postacie do tej pory budowane były najpewniej {allTimeChanged.Hours} godzin {allTimeChanged.Minutes} minut.");
            return toSave.ToArray();
        }
        public static string[] BuildStringToSaveTask(List<string> taleTitles)
        {
            List<string> toSave = new List<string>();
            toSave.Add("Magda Patiril występowała w następujących Opowieściach:");
            foreach(var title in taleTitles)
            {
                toSave.Add(title);
            }
            return toSave.ToArray();
        }
    }
}
