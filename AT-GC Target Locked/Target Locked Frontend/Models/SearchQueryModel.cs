using System.ComponentModel.DataAnnotations;

namespace Target_Locked_Frontend.Models
{
    public class SearchQueryModel
    {
        [Required]
        public string Query { get; set; }
    }
}