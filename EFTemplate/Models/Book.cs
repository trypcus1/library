using System;
using System.Collections.Generic;
using System.Text;

namespace EFTemplate.Models
{
    /// <summary>
    /// книга. принадлежит одному автору (многие к одному)
    /// и имеет ровно одну библиотечную карточку (один к одному).
    /// </summary>
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int PublishYear { get; set; }
        public string Genre { get; set; } = string.Empty;

        // внешний ключ и навигация к автору (многие к одному)
        public int AuthorId { get; set; }
        public Author? Author { get; set; }

        // связь один к одному с библиотечной карточкой
        public BookCard? Card { get; set; }
    }
}