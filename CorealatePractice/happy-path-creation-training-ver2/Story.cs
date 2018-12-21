using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace happy_path_creation_training_ver2
{
    class Story
    {
        public string Title;
        public string StoryAsString;

        public string CreateStoryAsString(string filePath)
        {
            return StoryAsString = File.ReadAllText(filePath);
        }

        public void SetTitle(string storyAsString)
        {
            Title = TextParser.ExtractTitle(storyAsString);
        }

        public static Story ExtractStoryDataFromFile(string filePath)
        {
            Story story = new Story();
            story.SetTitle(story.CreateStoryAsString(filePath));
            return story;
        }

        public static List<Story> CreateStoriesListFromDirectory(string directoryPath)
        {
            List<Story> stories = new List<Story>();
            string[] filesInDirectoryArray = Directory.GetFiles(directoryPath);
            foreach (string s in filesInDirectoryArray)
            {
                stories.Add(Story.ExtractStoryDataFromFile(s));
            }
            return stories;
        }
    }
}
