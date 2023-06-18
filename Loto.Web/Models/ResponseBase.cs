namespace Loto.Web.Models
{
    public class ResponseBase
    {
        public string? message { get; set; }
        public bool success { get; internal set; }
    }
}
