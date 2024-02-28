using translation.infrastructure.TranslatorServices;

namespace translation.infrastructure.Models
{

    public class ResponseData
    {
        public string TranslatedText { get; set; }
        public double Match { get; set; }
    }

    public class Match
    {
        public string Id { get; set; }
        public string Segment { get; set; }
        public string Translation { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public string Quality { get; set; }
        public object Reference { get; set; }
        public int UsageCount { get; set; }
        public string Subject { get; set; }
        public string CreatedBy { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public double MatchValue { get; set; }
    }
    public class MyMemoryApiResponse
    {
        public ResponseData responseData { get; set; }
        public bool quotaFinished { get; set; }
        public object mtLangSupported { get; set; }
        public string responseDetails { get; set; }
        public int responseStatus { get; set; }
        public object responderId { get; set; }
        public object exception_code { get; set; }
        public List<Match> matches { get; set; }
    }
}
