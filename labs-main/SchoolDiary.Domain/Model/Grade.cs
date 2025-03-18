using System.ComponentModel.DataAnnotations;

namespace SchoolDiary.Domain.Model;
///<summary>
///Класс оценки
///</summary>
public class Grade
{
    ///<summary>
    ///Индификатор оценки
    ///</summary>
    [Key]
    public required int Id { get; set; }
    ///<summary>
    ///Идентификатор ученика 
    ///</summary>
    public required int? StudentId { get; set; }
    ///<summary>
    ///Идентификатор предмета
    ///</summary>
    public required int? SubjectId { get; set; }
    ///<summary>
    ///Оценка
    ///</summary>
    public int? Score { get; set; }
    ///<summary>
    ///Время получения оценки
    ///</summary>
    required DateTime Date { get; set; }

}

