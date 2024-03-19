namespace CHUSHKA02.Models
{
    public class InputOrderModel
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string AppUserId { get; set; }
        public DateTime OrderedOn { get; set; }
    }
}
