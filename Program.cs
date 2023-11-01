using System;
using System.Collections.Generic;

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

    static DateTime currentDate = DateTime.Now;

    static void Main(string[] args)
    {
        Allnotes();
        ConsoleKeyInfo key;

        do
        {
            Console.Clear();
            Menu();

            key = Console.ReadKey();

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
        Console.WriteLine("Дата: " + currentDate.ToString("yyyy-MM-dd"));
        Console.WriteLine("Ежедневник:");
        Console.WriteLine("Используйте стрелки ↑ и ↓ для переключения между заметками.");
        Console.WriteLine("Используйте Z для добавления новой записи.");
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
            IsCompleted = false
        });

        notes.Add(new Note
        {
            Title = "День",
            Description = "Надо блин, много сделать блин, да блинб",
            IsCompleted = true
        });

        notes.Add(new Note
        {
            Title = "Вечер",
            Description = "Пойти на концерт",
            IsCompleted = false
        });
    }

    private static void SND(Note note)
    {
        Console.Clear();
        Console.WriteLine("Полная информация о заметке:");
        Console.WriteLine($"Название: {note.Title}");
        Console.WriteLine($"Описание: {note.Description}");
        Console.WriteLine($"Дата: {note.Date:yyyy-MM-dd}");
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
        
        DateTime date;
        while (true)
        {
            Console.Write("Дата (гггг-мм-дд): ");
            if (DateTime.TryParse(Console.ReadLine(), out date))
            {
                break;
            }
            else
            {
                Console.WriteLine("Ошибка при вводе даты. Попробуйте еще раз.");
            }
        }

        notes.Add(new Note
        {
            Title = title,
            Description = description,
            Date = date,
            IsCompleted = false
        });

        Console.WriteLine("Заметка успешно добавлена.");
        Console.WriteLine("\nНажмите любую клавишу для продолжения.");
        Console.ReadKey();
    }
}
