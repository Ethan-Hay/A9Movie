using A7MovieLibrary.Data;
using A7MovieLibrary.Models;

namespace A7MovieLibrary.Menus
{
public interface IMenu
    {
        bool ValidMenu { get; set; }
        void DisplayMenu();
        void Add();
        Movie GetMovie();
        void PrintList();
        void MediaType();
        void ActionMenu();

    }
}