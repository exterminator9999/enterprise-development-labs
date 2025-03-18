using SchoolDiary.Domain.Model;
using SchoolDiary.Domain.Services;

namespace SchoolDiary.Domain.Services;
/// <summary>
/// Репозиторий для работы с оценками.
/// </summary>
public interface IGradeRepository : IRepository<Grade, int>
{
    /// <summary>
    /// Получить количество оценок, среднюю, минимальную и максимальную оценку для каждого ученика.
    /// </summary>
    /// <returns>Список данных об оценках учеников.</returns>
    Task<IList<(Student student, int gradeCount, double gradeAvg, int minScore, int maxScore)>> GetStudentGradeStatistics();
}
