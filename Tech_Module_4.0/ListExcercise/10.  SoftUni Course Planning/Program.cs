using System;
using System.Linq;
using System.Collections.Generic;


namespace _10.__SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessonsAndExcercises = Console.ReadLine()
                .Split(", ")
                .ToList();

            string[] command = Console.ReadLine().Split(":").ToArray();

            while (command[0]!= "course start")
            {
                string action = command[0];
                string title = command[1];

                switch (action)
                {
                    case "Add":                        
                        Add(title, lessonsAndExcercises);
                        break;
                    case "Insert":
                      
                        int index =int.Parse( command[2]);
                        InsertAtIndex(title, index, lessonsAndExcercises);
                        break;
                    case "Remove":
                        RemoveTitle(title, lessonsAndExcercises);
                        break;
                    case "Swap":
                        string secondTitle = command[2];
                        SwapTwoTitles(title, secondTitle, lessonsAndExcercises);
                        break;
                    case "Exercise":
                        ExerciseAdd(title,lessonsAndExcercises);
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine().Split(":").ToArray();
            }
            foreach (var title in lessonsAndExcercises)
            {
                Console.WriteLine($"{lessonsAndExcercises.IndexOf(title)+1}.{title}");
            }
        }

        private static void ExerciseAdd(string title,List<string>list)
        {
            string titleExcersice = $"{title}-Exercise";
            if (list.Contains(title) && !list.Contains(titleExcersice))
            {
                int lessonIndex = list.IndexOf(title);
                list.Insert((lessonIndex + 1), titleExcersice);
            }
            if (!list.Contains(title))
            {
                list.Add(title);
                list.Add(titleExcersice);
            }
        }

        private static void SwapTwoTitles(string title, string secondTitle, List<string> lessonsAndExcercises)
        {
            if (lessonsAndExcercises.Contains(title)&&lessonsAndExcercises.Contains(secondTitle))
            {
                int firstTitleIndex = lessonsAndExcercises.IndexOf(title);
                int secondTitleIndex = lessonsAndExcercises.IndexOf(secondTitle);

                string tempTitleOne = title;
                
                lessonsAndExcercises[firstTitleIndex] = secondTitle;
                lessonsAndExcercises[secondTitleIndex] = tempTitleOne;

                string firstTitleExcercise = $"{title}-Exercise";
                int firstExcersiceIndex = lessonsAndExcercises.IndexOf(firstTitleExcercise);
                string secondTitleExcercise = $"{secondTitle}-Exercise";
                int secondExcerciseIndex = lessonsAndExcercises.IndexOf(secondTitleExcercise);

                if (lessonsAndExcercises.Contains(firstTitleExcercise))
                {                  
                    lessonsAndExcercises.Insert((secondTitleIndex + 1), firstTitleExcercise);
                    lessonsAndExcercises.RemoveAt(firstExcersiceIndex+1);
                }
                if (lessonsAndExcercises.Contains(secondTitleExcercise))
                {
                    lessonsAndExcercises.Insert((firstTitleIndex + 1), secondTitleExcercise);
                    lessonsAndExcercises.RemoveAt(secondExcerciseIndex+1);
                }
            }
        }

        private static void RemoveTitle(string title, List<string> lessonsAndExcercises)
        {
            if (lessonsAndExcercises.Contains(title))
            {
                string titleExcersice = $"{title}-Exercise";
                if (lessonsAndExcercises.Contains(titleExcersice))
                {
                    lessonsAndExcercises.Remove(titleExcersice);
                }
                lessonsAndExcercises.Remove(title);
            }
        }

        private static void InsertAtIndex(string title, int index, List<string> lessonsAndExcercises)
        {
            if (!lessonsAndExcercises.Contains(title))
            {
                lessonsAndExcercises.Insert(index, title);
            }
        }

        private static void Add(string title, List<string> lessonsAndExcercises)
        {
            if (!lessonsAndExcercises.Contains(title))
            {
                lessonsAndExcercises.Add(title);
            }
        }
    }
}
