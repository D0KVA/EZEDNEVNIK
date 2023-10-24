using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

class Note
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public bool IsCompleted { get; set; }
}

class Program
{
    private static List<Note> notes = new List<Note>();
    private static int poz = 0;
    static void Main(string[] args)
    {
        Allnotes();
        ConsoleKeyInfo key;

        do
        {
            Console.Clear();
            Menu();

            key = Console.ReadKey();
            DateTime currentDate = DateTime.Now; 
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (poz > 0)
                        poz--;
                    break;
                case ConsoleKey.DownArrow:
                    if (poz < notes.Count - 1)
                        poz++;
                    break;
                case ConsoleKey.Enter:
                    SND(notes[poz]);
                    break;
                case ConsoleKey.Z:
                    Newnote();
                    break;
                case ConsoleKey.LeftArrow:
                    currentDate = currentDate.AddDays(-1); 
                    break;
                case ConsoleKey.RightArrow:
                    currentDate = currentDate.AddDays(1);
                    break;
            }
        } while (key.Key != ConsoleKey.Escape);
    }

    private static void Menu()
    {
        Console.WriteLine("Дата:"); //не могу ввести currentDate, ведь пишет, что не может. 
        Console.WriteLine("Ежедневник:");
        Console.WriteLine("Используйте стрелки ↑ и ↓ для переключения между заметками.");
        Console.WriteLine("Используйте z для добавления новой записи.");
        Console.WriteLine("Используйте Enter для просмотра полной информации.");
        Console.WriteLine("Используйте Esc для выхода.");
        Console.WriteLine();

        for (int i = 0; i < notes.Count; i++)
        {
            Console.Write(i == poz ? "→ " : "  ");
            Console.WriteLine(notes[i].Title);
        }
    }
    private static void Allnotes()
    {
        notes.Add(new Note
        {
            Title = "Гойда",
            Description = "Я ватник, ххеахахахахахахах",
            Date = new DateTime(2023, 10, 17),
            IsCompleted = false
        });

        notes.Add(new Note
        {
            Title = "День",
            Description = "Надо блин, много сделать блинб, да блинб",
            Date = new DateTime(2023, 10, 16),
            IsCompleted = true
        });

        notes.Add(new Note
        {
            Title = "Вечер",
            Description = "Пойти на концерт",
            Date = new DateTime(2023, 10, 15),
            IsCompleted = false
        });
    }
    private static void SND(Note note)
    {
        Console.Clear();
        Console.WriteLine("Полная информация о заметке:");
        Console.WriteLine($"Название: {note.Title}");
        Console.WriteLine($"Описание: {note.Description}");
        Console.WriteLine($"Дата: {note.Date:2007-12-24}");
        Console.WriteLine($"Завершено: {note.IsCompleted}");
        Console.WriteLine("\nНажмите любую клавишу для возврата.");
        Console.ReadKey();
    }
    private static void Newnote()
    {
        Console.Clear();
        Console.WriteLine("Добавление новой записи:");
        Console.Write("Название: ");
        string title = Console.ReadLine();
        Console.Write("Описание: ");
        string description = Console.ReadLine();
        Console.Write("Дата (гггг-мм-дд): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
        {
            notes.Add(new Note
            {
                Title = title,
                Description = description,
                Date = date,
                IsCompleted = false
            });
            Console.WriteLine("Заметка успешно добавлена.");
        }
        else
        {
            Console.WriteLine("Ошибка при вводе даты.");
        }

        Console.WriteLine("\nНажмите любую клавишу для продолжения.");
        Console.ReadKey();
    }
}