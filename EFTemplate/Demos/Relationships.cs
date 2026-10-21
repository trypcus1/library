using EFTemplate.Data;
using EFTemplate.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFTemplate.Demos
{
    public static class RelationshipsDemo
    {
        public static void Run(AppDbContext db)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=== 3. СВЯЗИ И КАСКАДНОЕ УДАЛЕНИЕ ===");
            Console.ResetColor();

            // Создаём автора вместе с книгой и её карточкой в одном графе
            var newAuthor = new Author
            {
                FullName = "Временный Автор",
                Country = "Тестландия",
                BirthYear = 2000,
                Books = new List<Book>
                {
                    new Book
                    {
                        Title = "Временная книга",
                        PublishYear = 2024,
                        Genre = "Тест",
                        Card = new BookCard
                        {
                            InventoryNumber = "ВРЕМ-999",
                            ShelfLocation = "Временная полка"
                        }
                    }
                }
            };

            db.Authors.Add(newAuthor);
            db.SaveChanges();
            Console.WriteLine($"Автор '{newAuthor.FullName}' создан вместе с книгой и карточкой.");

            // Удаляем автора — EF каскадно удалит книги и их карточки
            Console.WriteLine("\n--> Удаляем автора 'Временный Автор' (каскад)...");
            db.Authors.Remove(newAuthor);
            db.SaveChanges();

            var orphanBook = db.Books.FirstOrDefault(b => b.Title == "Временная книга");
            var orphanCard = db.BookCards.FirstOrDefault(c => c.InventoryNumber == "ВРЕМ-999");

            Console.WriteLine($"   Книга после удаления автора:      {(orphanBook != null ? "ЕСТЬ (плохо)" : "НЕТ (удалена каскадно)")}");
            Console.WriteLine($"   Карточка после удаления автора:   {(orphanCard != null ? "ЕСТЬ (плохо)" : "НЕТ (удалена каскадно)")}");
        }
    }
}