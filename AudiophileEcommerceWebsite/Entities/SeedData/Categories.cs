namespace AudiophileEcommerceWebsite.Entities.SeedData
{
    public static class Categories
    {
        public static Dictionary<string, Category> categories
        {
            get
            {
                var genresList = new Category[]
                {
                    new Category { CategoryName = "headphones" },
                    new Category { CategoryName = "earphones" },
                    new Category { CategoryName = "speakers" },
                };

                var categories = new Dictionary<string, Category>();

                foreach (Category genre in genresList)
                {
                    categories.Add(genre.CategoryName, genre);
                }

                return categories;
            }
        }

        public static List<Category> GetCategories()
        {
            return categories.Select(c => c.Value)
                              .ToList();
        }
    }
}
