using EFTemplate.Models;
using System;
using System.Collections.Generic;
using System.Text;
using EFTemplate.Models;

namespace EFTemplate.Data
{
    public static class DbInitializer
    {
        public static void ResetAndSeed(AppDbContext context)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n[БАЗА ДАННЫХ] Удаление старой версии SQLite...");
            context.Database.EnsureDeleted();

            Console.WriteLine("[БАЗА ДАННЫХ] Создание чистой структуры по текущим моделям...");
            context.Database.EnsureCreated();
            Console.ResetColor();

            // --- Авторы ---
            var tolstoy = new Author { FullName = "Лев Толстой", Country = "Россия", BirthYear = 1828 };
            var orwell = new Author { FullName = "Джордж Оруэлл", Country = "Великобритания", BirthYear = 1903 };
            var remark = new Author { FullName = "Эрих Мария Ремарк", Country = "Германия", BirthYear = 1898 };

            // --- Книги (каждая — со своей карточкой) ---
            var warAndPeace = new Book
            {
                Title = "Война и мир",
                PublishYear = 1869,
                Genre = "Роман-эпопея",
                Author = tolstoy,
                Card = new BookCard { InventoryNumber = "БИБ-001", ShelfLocation = "Зал А, стеллаж 3" }
            };
            var annaKarenina = new Book
            {
                Title = "Анна Каренина",
                PublishYear = 1877,
                Genre = "Роман",
                Author = tolstoy,
                Card = new BookCard { InventoryNumber = "БИБ-002", ShelfLocation = "Зал А, стеллаж 3" }
            };
            var nineteenEightyFour = new Book
            {
                Title = "1984",
                PublishYear = 1949,
                Genre = "Антиутопия",
                Author = orwell,
                Card = new BookCard { InventoryNumber = "БИБ-003", ShelfLocation = "Зал Б, стеллаж 1" }
            };
            var threeComrades = new Book
            {
                Title = "Три товарища",
                PublishYear = 1936,
                Genre = "Роман",
                Author = remark,
                Card = new BookCard { InventoryNumber = "БИБ-004", ShelfLocation = "Зал Б, стеллаж 2" }
            };

            context.Authors.AddRange(tolstoy, orwell, remark);
            context.Books.AddRange(warAndPeace, annaKarenina, nineteenEightyFour, threeComrades);
            context.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[БАЗА ДАННЫХ] Пересоздано: авторов = {context.Authors.Count()}, " +
                              $"книг = {context.Books.Count()}, карточек = {context.BookCards.Count()}");
            Console.ResetColor();
        }
    }
}