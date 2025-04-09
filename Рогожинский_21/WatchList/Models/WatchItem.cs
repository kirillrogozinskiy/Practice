using System.ComponentModel.DataAnnotations;

namespace WatchList.Models
{
    public class WatchItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название обязательно")]
        [StringLength(100, ErrorMessage = "Название не может быть длиннее 100 символов")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Жанр обязателен")]
        [StringLength(50, ErrorMessage = "Жанр не может быть длиннее 50 символов")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Жанр может содержать только буквы и пробелы")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Тип обязателен")]
        [StringLength(50, ErrorMessage = "Тип не может быть длиннее 50 символов")]
        public string Type { get; set; } 

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = "К просмотру";
    }
}
