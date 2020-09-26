using System.ComponentModel.DataAnnotations;

namespace TBSTech.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string VideoName { get; set; }
        public string VideoUrl { get; set; }
    }
}