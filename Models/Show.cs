 using System;
 using System.IO;
 using System.Collections.Generic;
 using System.Linq;


 namespace A4MovieLibrary
 {
     public class Show : Media{
         public int Season { get; set; } 
         public int Episode { get; set; } 
         public List<String> Writers { get; set; }
         public static string File = "shows.csv";

        public Show(int id, string title, int season, int episode, List<String> writers)
        {
            ItemID = id;
            Title = title;
            Season = season;
            Episode = episode;
            Writers = writers;
        }

         public override void Read()
         {
             Console.WriteLine("How many shows do you want to be displayed? ");
             int numberOfShows = Int32.Parse(Console.ReadLine());
            
             StreamReader reader = new StreamReader(File);

             for(int i = 0; i < numberOfShows + 1 ; i++)
             {
                 string line = reader.ReadLine();
                 Console.WriteLine(line);    
             }
             reader.Close();
         }

         public override void Write()
         {
             ItemID = getLastID() + 1;
             StreamWriter sw = new StreamWriter(File, true);

             Console.WriteLine("Enter a new Title: ");
             string showTitle = Console.ReadLine();

             Console.WriteLine("Enter a new season: ");
             int season = Int32.Parse(Console.ReadLine());

             Console.WriteLine("Enter a new episode: ");
             int episode = Int32.Parse(Console.ReadLine()) ;

             var writers = new List<string>();
             string writer;
             string option;

             do
             {
                 Console.WriteLine("Add writer: ");
                 writer = Console.ReadLine();
                 writers.Add(writer);
                 Console.WriteLine("Do you want to add a write: (Y/N)");
                 option = Console.ReadLine().ToUpper();
             } while (option == "Y");
            
             string newWriters =  string.Join("|", writers); 
             sw.WriteLine("{0},{1},{2},{3},{4}", ItemID, showTitle, season, episode, newWriters);
             sw.Close();
         }

         public override int getLastID()
         {
             int lastID = 0;
                 try
                 {
                     string lastLine = System.IO.File.ReadLines(File).Last();
                     string[] lastLineSplit = lastLine.Split(',');
                     lastID = Convert.ToInt32(lastLineSplit[0]);
                     return lastID;
                 }
                 catch (DirectoryNotFoundException)
                 {
                     Console.WriteLine("File does not exist.");
                 }
                 return lastID;
         }
     }

 }
