namespace Domain.Models
{
    public partial class Story
    {
        public string By { get; set; }
        public long Descendants { get; set; }
        public long Id { get; set; }
        public long[] Kids { get; set; }
        public long Score { get; set; }
        public long Time { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public Uri Url { get; set; }
    }
}
