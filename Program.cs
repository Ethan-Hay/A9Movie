using System;

using A7MovieLibrary.Data;
using A7MovieLibrary.Menus;
using Microsoft.Extensions.DependencyInjection;

namespace A7MovieLibrary
{
       class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IRepository, MovieWriter>()
                .AddSingleton<IMenu, Menu>()
                .BuildServiceProvider();

            var menu = serviceProvider.GetService<IMenu>();

            menu.DisplayMenu();
        
            Console.WriteLine("\nThank you for using the movie library!");
        }
    }
}