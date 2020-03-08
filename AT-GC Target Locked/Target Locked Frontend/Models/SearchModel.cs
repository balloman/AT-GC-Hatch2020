using System.ComponentModel.DataAnnotations;

namespace Target_Locked_Frontend.Models
{
    public class SearchModel
    {
        [Required]
        public string Query { get; set; }
    }
}