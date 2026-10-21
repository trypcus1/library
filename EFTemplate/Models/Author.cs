using System;
using System.Collections.Generic;
using System.Text;

namespace EFTemplate.Models
{
    /// <summary>
    /// автор книги. Связан с книгами связью "один ко многим":
    /// у одного автора может быть много книг.
    /// </summary>
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public int BirthYear { get; set; }

        // навигационное свойство: список книг автора
        public List<Book> Books { get; set; } = new();
    }
}