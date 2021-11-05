using A7MovieLibrary.Models;
using System.Collections.Generic;

namespace A7MovieLibrary.Data
{
    public interface IRepository
    {
        void WriteToFile(Movie movie);
        List<Movie> ReadFromFile();
        int GetNextId();
    }
}