
namespace WebShop.Models
{
    public class SampleData : System.Data.Entity.CreateDatabaseIfNotExists<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            //List<Category> categories = new List<Category>();
            //categories.Add(new Category() { CategoryId = 0, Description = "Various types of furnitures", Name = "Furniture", Products = new List<Product>() });
            //categories.Add(new Category() { CategoryId = 1, Description = "Clothing items", Name = "Clothes", Products = new List<Product>() });
            //categories.Add(new Category() { CategoryId = 2, Description = "Different kinds of eletronics", Name = "Eletronics", Products = new List<Product>() });

            //List<Product> products = new List<Product>();
            //products.Add(new Product() { ProductId = 0, Name = "Awesome Chair", Description = "The best chair in the world!", Price = 5000, CategoryId = 0, ImageUrl = "/Content/Images/placeholder.gif" });
            //products.Add(new Product() { ProductId = 1, Name = "Crappy Chair", Description = "The worst chair in the world :(", Price = 1, CategoryId = 0, ImageUrl = "/Content/Images/placeholder.gif" });
            //products.Add(new Product() { ProductId = 2, Name = "Standard Chair", Description = "Nothing special about this...", Price = 100, CategoryId = 0, ImageUrl = "/Content/Images/placeholder.gif" });
            //products.Add(new Product() { ProductId = 3, Name = "Manly T-Shirt", Description = "This is a T-Shirt for men!", Price = 200, CategoryId = 1, ImageUrl = "/Content/Images/placeholder.gif" });
            //products.Add(new Product() { ProductId = 4, Name = "Not so manly T-Shirt", Description = "This is a T-Shirt for not so manly men!", Price = 400, CategoryId = 1, ImageUrl = "/Content/Images/placeholder.gif" });
            //products.Add(new Product() { ProductId = 5, Name = "Pants", Description = "Standard pants", Price = 210, CategoryId = 1, ImageUrl = "/Content/Images/placeholder.gif" });
            //products.Add(new Product() { ProductId = 6, Name = "Pants", Description = "Standard pants", Price = 210, CategoryId = 1, ImageUrl = "/Content/Images/placeholder.gif" });

            //categories.ForEach(x => x.Products.AddRange(products.Where(y => y.CategoryId == x.CategoryId)));
            
            //categories.ForEach(x => context.Categorys.Add(x));
            //products.ForEach(x => context.Products.Add(x));
        }
    }
}