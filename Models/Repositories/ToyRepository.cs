namespace ToysP.Models.Repositories
{
    public static class ToyRepository
    {
        private static List<Toy> toys = new List<Toy>()
        {
            new Toy { ToyId = 1, Name = "Spiderman", Gender = "boy", Price = 59, Age = 10},
            new Toy { ToyId = 2, Name = "Batman", Gender = "boy", Price = 45, Age = 8},
            new Toy { ToyId = 3, Name = "Barbie", Gender = "girl", Price = 20, Age = 6},
            new Toy { ToyId = 4, Name = "Pokemon", Gender = "girl", Price = 70, Age = 7},
        };

        public static List<Toy> GetToys()
        {
            return toys;
        }

        public static bool ToyExists(int id)
        {
            return toys.Any(x => x.ToyId == id);
        }

        public static Toy? GetToyById(int id)
        {
            return toys.FirstOrDefault(x => x.ToyId == id);
        }

        public static Toy? GetToyByProperties(string? brand, string? gender, int? size)
        {
            return toys.FirstOrDefault(x =>
            !string.IsNullOrWhiteSpace(brand) &&
            !string.IsNullOrWhiteSpace(x.Name) &&
            x.Name.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(gender) &&
            !string.IsNullOrWhiteSpace(x.Gender) &&
            x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) &&
            
           
            size.HasValue &&
            x.Age.HasValue &&
            size.Value == x.Age.Value);
        }

        public static void AddToy(Toy toy)
        {
            int maxId = toys.Max(x => x.ToyId);
            toy.ToyId = maxId + 1;
            toys.Add(toy);
        }

        public static void UpdateToy(Toy toy)
        {
            var toyToUpdate = toys.First(x => x.ToyId == toy.ToyId);
            toyToUpdate.Name = toy.Name;
            toyToUpdate.Price = toy.Price;
            toyToUpdate.Age = toy.Age;

            toyToUpdate.Gender = toy.Gender;
        }

        public static void DeleteToy(int toyId)
        {
            var toy = GetToyById(toyId);
            if (toy != null)
            {
                toys.Remove(toy);
            }
        }

    }
}
