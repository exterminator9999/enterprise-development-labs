using SchoolDiary.Domain.Model;

namespace SchoolDiary.Domain.Services;
/// <summary>
/// Репозиторий для работы с учениками.
/// </summary>
public interface IStudentRepository : IRepository<Student, int>
{
    /// <summary>
    /// Получить все сведения о конкретном ученике и его классе.
    /// </summary>
    /// <param name="Id">Идентификатор студента.</param>
    /// <returns>Данные об ученике и его классе.</returns>
    Task<(Student student, Classes classes)?> GetStudentWithClass(int Id);

    /// <summary>
    /// Получить топ 5 студентов по средней оценке.
    /// </summary>
    /// <returns>Список из 5 студентов и их количество оценок.</returns>
    Task<IList<(Student student, int gradeCount)>> GetTop5StudentByGradeCount();
    /// <summary>
    /// Получить информацию о количестве оценок, средней, минимальной и максимальной оценке для каждого ученика.
    /// </summary>
    /// <returns>Список учеников с данными по их оценкам.</returns>
    Task<IList<(Student student, int gradeCount, double gradeAvg, int minScore, int maxScore)>> GetStudentGradeStatistics();
}