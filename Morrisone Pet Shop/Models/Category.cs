namespace Morrisone_Pet_Shop.Areas
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string? Image { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
