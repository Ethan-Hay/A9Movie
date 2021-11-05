using System.Collections.Generic;
using A4MovieLibrary;
using A7MovieLibrary.Models;

namespace A7MovieLibrary
{
    public class MediaManager
    {
        public List<Media> MediaItems {get; set;}

        public MediaManager ()
        {
            MediaItems = new List<Media>();
        }
    }
}