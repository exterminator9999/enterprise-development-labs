using SchoolDiary.Domain.Model;
using SchoolDiary.Domain.Services;

namespace SchoolDiary.Domain.Services;

/// <summary>
/// Репозиторий для работы с Предметами.
/// </summary>
public interface ISubjectRepository : IRepository<Subject, int>
{
    /// <summary>
    /// Получить все предметы, по которым были выставлены оценки за указанный период, упорядоченные по названию.
    /// </summary>
    /// <param name="startDate">Начальная дата периода.</param>
    /// <param name="endDate">Конечная дата периода.</param>
    /// <returns>Список предметов.</returns>
    Task<IList<Subject>> GetSubjectsByGradePeriod(int startDate, int endDate);

    /// <summary>
    /// Получить количество оценок по каждому предмету.
    /// </summary>
    /// <returns>Список предметов и количества оценок по ним.</returns>
    Task<IList<(Subject subject, int gradeCount)>> GetGradeCountBySubject();

    /// <summary>
    /// Получить предметы, по которым было выставлено максимальное количество оценок за указанный период.
    /// </summary>
    /// <param name="startDate">Начальная дата периода.</param>
    /// <param name="endDate">Конечная дата периода.</param>
    /// <returns>Список предметов с максимальным количеством оценок.</returns>
    Task<IList<Subject>> GetTopSubjectsByGradePeriod(int startDate, int endDate);
}