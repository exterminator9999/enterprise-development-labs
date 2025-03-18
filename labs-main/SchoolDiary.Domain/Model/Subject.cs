using System.ComponentModel.DataAnnotations;

namespace SchoolDiary.Domain.Model;
///<summary>
///Класс предмет
///</summary>
public class Subject
{
    /// <summary>
    /// Индификатор предмета 
    /// </summary>
    [Key]
    public required int Id { get; set; }
    ///<summary>
    ///Наименование предмета 
    ///</summary>
    public string? SubjectName { get; set; }

    ///<summary>
    ///Год обучения 
    ///</summary>
    public int? Year { get; set; }

}

