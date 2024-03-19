using static CHUSHKA02.Data.Models.Product;

namespace CHUSHKA02.Models
{
    public class InputProductModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public Type_ ProductType { get; set; }
    }
}
