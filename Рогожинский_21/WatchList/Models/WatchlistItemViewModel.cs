using System.ComponentModel.DataAnnotations;

namespace WatchList.Models
{
    public class WatchlistItemViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название обязательно")]
        [StringLength(100, ErrorMessage = "Название не может быть длиннее 100 символов")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Жанр обязателен")]
        [StringLength(50, ErrorMessage = "Жанр не может быть длиннее 50 символов")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Тип обязателен")]
        public string Type { get; set; } 
    }
}