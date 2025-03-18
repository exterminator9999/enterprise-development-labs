using System.ComponentModel.DataAnnotations;

namespace SchoolDiary.Domain.Model;
///<summary>
///класс учеников
///</summary>
public class Student
{
    ///<summary>
    ///Индификатор ученика 
    ///</summary>
    [Key]
    public required int Id { get; set; }
    ///<summary>
    ///Паспорт ученика
    ///</summary>
    public required int? Passport { get; set; }
    ///<summary>
    ///Имя ученика
    ///</summary>
    public string? Name { get; set; }
    ///<summary>
    ///Фамилия ученика
    ///</summary>
    public string? Surname { get; set; }
    ///<summary>
    ///Год рождения ученика
    ///</summary>
    public int? YearOfBirth { get; set; }
    
}

