using EFTemplate.Data;
using EFTemplate.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFTemplate.Demos
{
    public static class ChangeTracker
    {
        public static void Run(AppDbContext db)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=== 2. CHANGE TRACKER (ОТСЛЕЖИВАНИЕ СОСТОЯНИЙ) ===");
            Console.ResetColor();

            var book = new Book
            {
                Title = "Тестовая книга",
                PublishYear = 2024,
                Genre = "Тест",
                AuthorId = 1
            };
            Console.WriteLine($"1. Объект создан в C#:               State = {db.Entry(book).State}");

            db.Books.Add(book);
            Console.WriteLine($"2. После db.Books.Add():            State = {db.Entry(book).State}");

            db.SaveChanges();
            Console.WriteLine($"3. После db.SaveChanges():          State = {db.Entry(book).State}");

            book.Title = "Обновлённая тестовая книга";
            Console.WriteLine($"4. Изменили свойство в коде:        State = {db.Entry(book).State}");

            db.Books.Remove(book);
            Console.WriteLine($"5. После db.Books.Remove():         State = {db.Entry(book).State}");

            db.SaveChanges();
            Console.WriteLine($"6. После удаления и SaveChanges():  State = {db.Entry(book).State}");
        }
    }
}