using System;

namespace MvcDemo.Ajax.Models
{
    // Detta är vår vy-modell
    // Vy-modellen i detta fallet är en exakt kopia av Photo.cs
    // Detta för att det är best-practice att INTE returnera sin 
    // model som man använder vid lagring i t.ex. EntityFramework
    public class PhotoViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Filename { get; set; }
    }
}