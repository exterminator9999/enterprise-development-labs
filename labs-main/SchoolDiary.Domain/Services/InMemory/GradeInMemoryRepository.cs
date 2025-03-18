using SchoolDiary.Domain.Data;
using SchoolDiary.Domain.Model;

namespace SchoolDiary.Domain.Services.InMemory;

/// <summary>
/// Имплементация репозитория для Оценок, которая хранит коллекцию в оперативной памяти 
/// </summary>
public class GradeInMemoryRepository : IGradeRepository
{
    private readonly List<Grade> _grade;
    private readonly List<Student> _student;
    private readonly List<StudentClass> _studentClasses;

    /// <summary>
    /// Конструктор репозитория
    /// </summary>
    public GradeInMemoryRepository()
    {
        _grade = DataSeeder.Grades;
        _student = DataSeeder.Students;
        _studentClasses = DataSeeder.StudentClasses;
    }

    /// <inheritdoc/>
    public Task<Grade> Add(Grade entity)
    {
        _grade.Add(entity);
        return Task.FromResult(entity);
    }

    /// <inheritdoc/>
    public async Task<bool> Delete(int key)
    {
        var grade = await Get(key);
        if (grade != null)
        {
            _grade.Remove(grade);
            return true;
        }
        return false;
    }

    /// <inheritdoc/>
    public Task<Grade> Update(Grade entity)
    {
        var existingGrade = _grade.FirstOrDefault(g => g.Id == entity.Id);
        if (existingGrade != null)
        {
            existingGrade.Id = entity.Id;
            existingGrade.StudentId = entity.StudentId;
            existingGrade.SubjectId = entity.SubjectId;
            existingGrade.Score = entity.Score;
            existingGrade.Date = entity.Date;
        }
        return Task.FromResult(entity);
    }

    /// <inheritdoc/>
    public Task<Grade?> Get(int key) =>
        Task.FromResult(_grade.FirstOrDefault(g => g.Id == key));

    /// <inheritdoc/>
    public Task<IList<Grade>> GetAll() =>
        Task.FromResult((IList<Grade>)_grade);

    /// <inheritdoc/>
    public Task<IList<(Student student, int gradeCount, double avgScore, int minScore, int maxScore)>> GetStudentGradeStatistics()
    {
        var statistics = _grades
            .GroupBy(g => g.StudentId)
            .Select(g =>
            {
                var studentClass = _studentClasses.FirstOrDefault(sc => sc.StudentId == g.Key);
                var student = studentClass != null ? _students.FirstOrDefault(s => s.Id == studentClass.StudentId) : null;
                return student != null
                    ? (student, g.Count(), g.Average(grade => grade.Score), g.Min(grade => grade.Score), g.Max(grade => grade.Score))
                    : default;
            })
            .Where(stat => stat.student != null)
            .ToList();

        return Task.FromResult((IList<(Student, int, double, int, int)>)statistics);
    }
}