using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using A7MovieLibrary.Models;
using Newtonsoft.Json;


namespace A7MovieLibrary.Data
{
public class MovieWriter : IRepository
    {
       private string File = Path.Combine(Environment.CurrentDirectory, "Files", "movies.json");
        private List<Movie> ListOfMovies;
        
        public void WriteToFile(Movie movie)
        {
            FileToList();
            ListOfMovies.Add(movie);

            using (StreamWriter sw = new StreamWriter(File))
            {
                string json = JsonConvert.SerializeObject(ListOfMovies, Formatting.Indented);

                sw.Write(json);
            }
        }

        public List<Movie> ReadFromFile()
        {
            FileToList();
            return ListOfMovies;
        }

        private void FileToList()
        {
            string json;
            using (StreamReader sr = new StreamReader(File))
            {
                json = sr.ReadToEnd();
            }

            ListOfMovies = JsonConvert.DeserializeObject<List<Movie>>(json);
        }

        public int GetNextId()
        {
            FileToList();
            ListOfMovies.Sort((x,y) => x.MovieID.CompareTo(y.MovieID));
            return ListOfMovies.Last().MovieID + 1;
        }
    }
}