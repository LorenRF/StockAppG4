

namespace DataBase.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float price { get; set; }
        public string imagePath { get; set; }
        public int CategoryId { get; set; }
        //navegation properties
        public Category? Category { get; set; }
    }
}
