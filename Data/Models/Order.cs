using System.Net.Http.Headers;

namespace CHUSHKA02.Data.Models
{
    public class Order
    {
        public Order()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string ClientId { get; set; }
        public DateTime OrderedOn { get; set; }

        public Product Product { get; set; }
        public AppUser Client { get; set; }
    }
}
