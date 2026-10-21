using EFTemplate.Data;
using EFTemplate.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFTemplate.Demos
{
    public static class CrudOperations
    {
        public static void Run(AppDbContext db)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=== 1. БАЗОВЫЙ CRUD (Create / Read / Update / Delete) ===");
            Console.ResetColor();

            // --- CREATE ---
            Console.WriteLine("\n[CREATE] Добавляем книгу 'Мастер и Маргарита'...");
            var newBook = new Book
            {
                Title = "Мастер и Маргарита",
                PublishYear = 1967,
                Genre = "Мистический роман",
                AuthorId = 1
            };
            db.Books.Add(newBook);
            db.SaveChanges();
            Console.WriteLine($"   Книга добавлена. Сгенерированный Id = {newBook.Id}");

            // --- READ ---
            Console.WriteLine("\n[READ] Ищем книгу по Id через метод Find...");
            var book = db.Books.Find(newBook.Id);
            Console.WriteLine($"   Найдено: '{book?.Title}' ({book?.PublishYear} г.), жанр: {book?.Genre}");

            // --- UPDATE ---
            Console.WriteLine("\n[UPDATE] Меняем год публикации на 1966...");
            if (book != null)
            {
                book.PublishYear = 1966;
                db.SaveChanges();
                Console.WriteLine("   Изменение сохранено (EF сгенерировал SQL UPDATE автоматически).");
            }

            // --- DELETE ---
            Console.WriteLine("\n[DELETE] Удаляем только что созданную книгу...");
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
                Console.WriteLine("   Запись удалена (EF сгенерировал SQL DELETE).");
            }
        }
    }
}