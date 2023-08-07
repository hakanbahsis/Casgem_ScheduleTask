namespace WebUI.CQRS.Results
{
    public class GetEventQueryResult
    {
        public int EventID { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string ThemeColor { get; set; }
        public bool IsFullDay { get; set; }
    }
}
