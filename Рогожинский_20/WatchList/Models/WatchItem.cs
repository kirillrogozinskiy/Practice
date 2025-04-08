using System.ComponentModel.DataAnnotations;

namespace WatchList.Models
{
    public class WatchItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }
    }
}
