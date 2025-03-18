using SchoolDiary.Domain.Data;
using SchoolDiary.Domain.Model;

namespace SchoolDiary.Domain.Services.InMemory;

/// <summary>
/// Имплементация репозитория для Предметов, которая хранит коллекцию в оперативной памяти 
/// </summary>
public class SubjectInMemoryRepository : ISubjectRepository
{
    private List<Subject> _subject;
    private List<StudentClass> _studentClasses;
    private List<Grade> _grade;

    /// <summary>
    /// Конструктор репозитория
    /// </summary>
    public SubjectInMemoryRepository()
    {
        _subject = DataSeeder.Subject;
        _studentClasses = DataSeeder.StudentClasses;
        _grade = DataSeeder.Grade;
    }

    /// <inheritdoc/>
    public Task<Subject> Add(Subject entity)
    {
        _subject.Add(entity);
        return Task.FromResult(entity);
    }

    /// <inheritdoc/>
    public async Task<bool> Delete(int key)
    {
        var subject = await Get(key);
        if (subject != null)
        {
            _subjects.Remove(subject);
            return true;
        }
        return false;
    }

    /// <inheritdoc/>
    public async Task<Subject> Update(Subject entity)
    {
        try
        {
            await Delete(entity.Id);
            await Add(entity);
        }
        catch
        {
            return null!;
        }
        return entity;
    }

    /// <inheritdoc/>
    public Task<Subject?> Get(int key) =>
        Task.FromResult(_subjects.FirstOrDefault(s => s.Id == key));

    /// <inheritdoc/>
    public Task<IList<Subject>> GetAll() =>
        Task.FromResult((IList<Subject>)_subject);

    /// <inheritdoc/>
    public Task<IList<Subject>> GetSubjectsByGradePeriod(int startDate, int endDate)
    {
        var subject = _studentClasses
            .Where(sc => _grades.Any(g => g.StudentId == sc.StudentId && g.Date >= startDate && g.Date <= endDate))
            .Select(sc => _subjects.FirstOrDefault(s => s.Id == sc.ClassId))
            .Where(s => s != null)
            .Select(s => s!)
            .OrderBy(s => s.Name)
            .ToList();

        return Task.FromResult<IList<Subject>>(subjects);
    }

    /// <inheritdoc/>
    public Task<IList<(Subject subject, int gradeCount)>> GetGradeCountBySubject()
    {
        var gradeCounts = _studentClasses
            .GroupBy(sc => sc.ClassId)
            .Select(g => (subject: _subject.FirstOrDefault(s => s.Id == g.Key), gradeCount: g.Count()))
            .Where(x => x.subject != null)
            .ToList();

        return Task.FromResult((IList<(Subject, int)>)gradeCounts);
    }

    /// <inheritdoc/>
    public Task<IList<Subject>> GetTopSubjectsByGradePeriod(int startDate, int endDate)
    {
        var topSubjects = _studentClasses
            .Where(sc => _grade.Any(g => g.StudentId == sc.StudentId && g.Date >= startDate && g.Date <= endDate))
            .GroupBy(sc => sc.ClassId)
            .OrderByDescending(g => g.Count())
            .Select(g => _subject.FirstOrDefault(s => s.Id == g.Key))
            .Where(s => s != null)
            .Select(s => s!)
            .ToList();

        return Task.FromResult<IList<Subject>>(topSubjects);
    }
}