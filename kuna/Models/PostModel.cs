using kuna.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace kuna.Models
{
    public struct PostModel
    {
        private string id;
        private string name;
        private string species;
        private int age;
        private string size;
        private string breed;
        private string image;
        private string color;
        private string characteristics;
        private DateTime date;
        private string user;

        public PostModel(string id, string name, string species, int age, string image, string size, string breed, string color, string characteristics, DateTime date, string user)
        {
            Id = id;
            Name = name;
            Species = species;
            Age = age;
            Image = image;
            Size = size;
            Breed = breed;
            Color = color;
            Characteristics = characteristics;
            Date = date;
            User = user;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Species { get => species; set => species = value; }
        public int Age { get => age; set => age = value; }
        public string Image { get => image; set => image = value; }
        public string Size { get => size; set => size = value; }
        public string Breed { get => breed; set => breed = value; }
        public string Color { get => color; set => color = value; }
        public string Characteristics { get => characteristics; set => characteristics = value; }
        public DateTime Date { get => date; set => date = value; }

        public string User { get => user; set => user = value; }

    }
}
