using Microsoft.AspNetCore.Mvc;

namespace translation.api.Models
{
    public class RequestDto
    {
        public required string message { get; set; }
    }
}
