using System;
using System.Collections.Generic;
using System.Linq;
using MvcDemo.Data.Models;

namespace MvcDemo.Data.Repositories
{
    public class PhotoRepository
    {
        // Spara i minnet tills vi flyttar till en databas
        public static IList<Photo> Photos { get; private set; } = new List<Photo>();

        public PhotoRepository()
        {
            if (!Photos.Any())
            {
                SetupTemporaryData();
            }
        }

        public void Add(Photo photo)
        {
            Photos.Add(photo);
        }

        public void Remove(Guid id)
        {
            var photo = Photos.Single(x => x.Id == id);
            Photos.Remove(photo);
        }

        private void SetupTemporaryData()
        {
            Photos = new List<Photo>
            {
                    new Photo
                    {
                        Id = Guid.NewGuid(),
                        Name = "Sunset on the beach",
                        Filename = "sunset.jpg"
                    },
                    new Photo
                    {
                        Id = Guid.NewGuid(),
                        Name = "Sunrise on the beach",
                        Filename = "sunrise.jpg"
                    }
                };
        }
    }
}