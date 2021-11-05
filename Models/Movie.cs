using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using A4MovieLibrary;
using Newtonsoft.Json;

namespace A7MovieLibrary.Models
{
  [JsonObject(MemberSerialization.OptIn)]
    public class Movie : Media

    {
        
        [JsonProperty]
        public int MovieID { get; set; }
        [JsonProperty]
        public new string Title { get; set; }
        [JsonProperty]
        public new List<string> Genres { get; set; }

        public static string File = "movies.csv";

        public Movie(int id, string title, List<string> genres)
        {
            MovieID = id;
            Title = title;
            Genres = genres;
        }

        public override string ToString()
        {
            string genres = "";
            foreach (string g in Genres)
            {
                genres += g + " | ";
            }
            return $"{MovieID, -5} {Title, -15} {genres, -30}";
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

             Console.WriteLine("Enter a new genre: ");
             string firstGenre =Console.ReadLine();

             Console.WriteLine("Enter another new genre: ");
             string secondGenre = Console.ReadLine() ;
 
             sw.WriteLine("{0},{1},{2},{3},{4}", ItemID, showTitle, firstGenre, secondGenre);
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