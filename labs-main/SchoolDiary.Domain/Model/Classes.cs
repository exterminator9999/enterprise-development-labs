using System.ComponentModel.DataAnnotations;

namespace SchoolDiary.Domain.Model;
///<summary>
///Класс классов
///</summary>
public class Classes
{
    /// <summary>
    /// Индификатор класса
    /// </summary>
    [Key]
    public required int Id { get; set; }
    ///<summary>
    ///Номер класса
    ///</summary>
    public int? Number { get; set; }

    ///<summary>
    ///Буква класса
    ///</summary>
    public string? Litera { get; set; }
}

