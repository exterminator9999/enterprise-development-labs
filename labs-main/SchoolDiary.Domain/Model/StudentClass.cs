using System.ComponentModel.DataAnnotations;

namespace SchoolDiary.Domain.Model;
///<summary>
///Класс связывающий учеников и классы
///</summary>
public class StudentClasses
{
    /// <summary>
    /// Идентификатор связи
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Идентификатор ученика
    /// </summary>
    public required int StudentId { get; set; }

    /// <summary>
    /// Идентификатор класса
    /// </summary>
    public required int ClassesId { get; set; }
}

