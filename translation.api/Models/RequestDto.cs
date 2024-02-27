using Microsoft.AspNetCore.Mvc;

namespace translation.api.Models
{
    public class RequestDto
    {
        public required string message { get; set; }
        public required string fromLanguage { get; set; }
        public required string toLanguage { get; set; }
    }
}
