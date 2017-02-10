using System.ComponentModel.DataAnnotations;

namespace SampleWebApiAspNetCore.Models
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required, MinLength(3)]
        public string Title { get; set; }

        [Required, MinLength(3)]
        public string Director { get; set; }
    }
}