using SchoolDiary.Domain.Model;

namespace SchoolDiary.Domain.Data;

/// <summary>
/// Класс для заполнения коллекций данными
/// </summary>
public static class DataSeeder
{
    /// <summary>
    /// Коллекция учеников для начального наполнения
    /// </summary>
    public static readonly List<Student> Student =
    [
        new() { Id = 1, Passport = "123456", Name = "Иван", Surname = "Иванов", YearOfBirth = 2002 },
        new() { Id = 2, Passport = "132435", Name = "Петр", Surname = "Петров", YearOfBirth = 2001 },
        new() { Id = 3, Passport = "211345", Name = "Семен",Surname = "Семенов", YearOfBirth = 2002 },
        new() { Id = 4, Passport = "345234", Name = "Михаил",Surname = "Михайлов", YearOfBirth = 2002 },
        new() { Id = 5, Passport = "234543", Name = "Алексей", Surname = "Алексеев", YearOfBirth = 2003 }
    ];

    /// <summary>
    /// Коллекция классов начального наполнения
    /// </summary>
    public static readonly List<Classes> Classes =
    [
        new() { Id = 1, Number = 9, Litera = "А" },
        new() { Id = 2, Number = 9, Litera = "Б" },
        new() { Id = 3, Number = 9, Litera = "В" }
    ];

    /// <summary>
    /// Коллекция связей учеников и классов
    /// </summary>
    public static readonly List<StudentClasses> StudentClasses =
    [
        new() { Id = 1, StudentId = 1, ClassId = 1 },
        new() { Id = 2, StudentId = 2, ClassId = 2 },
        new() { Id = 3, StudentId = 3, ClassId = 3 },
        new() { Id = 4, StudentId = 4, ClassId = 1 },
        new() { Id = 5, StudentId = 5, ClassId = 2 }
    ];

    /// <summary>
    /// Коллекция предметов
    /// </summary>
    public static readonly List<Subject> Subject =
    [
        new() { Id = 1, SubjectName = "Математика", Year = 9 },
        new() { Id = 2, SubjectName = "Русский", Year = 9 },
        new() { Id = 3, SubjectName = "Физика", Year = 10 },
        new() { Id = 4, SubjectName = "Литература", Year = 10 }
    ];

    /// <summary>
    /// Коллекция оценок
    /// </summary>
    public static readonly List<Grade> Grade =
    [
        new() { Id = 1, StudentId = 1, SubjectId = 1, Score = 5, Date = new DateTime(2023, 9, 1)},
        new() { Id = 2, StudentId = 1, SubjectId = 2, Score = 5, Date = new DateTime(2023, 9, 7) },
        new() { Id = 3, StudentId = 1, SubjectId = 3, Score = 4, Date = new DateTime(2023, 9, 6) },
        new() { Id = 4, StudentId = 1, SubjectId = 4, Score = 3, Date = new DateTime(2023, 9, 8)},
        new() { Id = 5, StudentId = 1, SubjectId = 1, Score = 4, Date = new DateTime(2023, 9, 9)}
    ];

