 using System;
 using System.IO;
 using System.Collections.Generic;
 using System.Linq;


 namespace A4MovieLibrary
 {
     public abstract class Media{
         public int ItemID { get; set;}
         public string Title { get; set;}
         public string Genres { get; set;}

         public abstract void Read();
         public abstract void Write();
         public abstract int getLastID();
     }
 }
