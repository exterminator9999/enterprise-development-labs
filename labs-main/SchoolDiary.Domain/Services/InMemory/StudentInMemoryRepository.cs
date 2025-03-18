using SchoolDiary.Domain.Model;
using SchoolDiary.Domain.Services;
using SchoolDiary.Domain.Data;

namespace SchoolDiary.Domain.Services.InMemory;
/// <summary>
/// Реализация репозитория для работы с учениками в памяти.
/// </summary>
public class StudentInMemoryRepository : IStudentRepository
{
    private readonly List<Student> _student;
    private readonly List<Classes> _classes;
    private readonly List<StudentClasses> _studentClasses;
    private readonly List<Grade> _grade;

    /// <inheritdoc/>
    public StudentInMemoryRepository()
    {
        _student = DataSeeder.Student;
        _classes = DataSeeder.Classes;
        _studentClasses = DataSeeder.StudentClasses;
        _grades = DataSeeder.Grades;
    }

    /// <inheritdoc/>
    public Task<IList<Student>> GetAll()
    {
        return Task.FromResult<IList<Student>>(_student);
    
    }

    /// <inheritdoc/>
    public Task<Student?> Get(int key)
    {
        var student = _student.FirstOrDefault(s => s.Id == key);
        return Task.FromResult(student);
    }

    /// <inheritdoc/>
    public Task<Student> Add(Student entity)
    {
        if (!_student.Any(s => s.Id == entity.Id))
        {
            _student.Add(entity);
        }
        return Task.FromResult(entity);
    }

    /// <inheritdoc/>
    public Task<Student> Update(Student entity)
    {
        var existingStudent = _student.FirstOrDefault(s => s.Id == entity.Id);
        if (existingStudent != null)
        {
            existingStudent.Name = entity.Name;
            existingStudent.Surname = entity.Surname;
            existingStudent.Passport = entity.Passport;
            existingStudent.YaerOfBirth = entity.YaerOfBirth;
        }
        return Task.FromResult(entity);
    }

    /// <inheritdoc/>
    public Task<bool> Delete(int key)
    {
        var student = _student.FirstOrDefault(s => s.Id == key);
        if (student != null)
        {
            _student.Remove(student);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    /// <inheritdoc/>
    public Task<(Student student, Classes classes)?> GetStudentWithClasses(int id)
    {
        var studentClass = _studentClasses.FirstOrDefault(sc => sc.StudentId == id);
        if (studentClass != null)
        {
            var student = _student.FirstOrDefault(s => s.Id == studentClass.StudentId);
            var classes = _classes.FirstOrDefault(c => c.Id == studentClass.ClassesId);
            if (student != null && classes != null)
            {
                return Task.FromResult<(Student, Classes)?>((student, classes));
            }
        }
        return Task.FromResult<(Student, Classes)?>(null);
    }

    /// <inheritdoc/>
    public Task<IList<(Student student, int gradeAverage)>> GetTop5StudentByGradeCount()
    {
        var topStudent = _grade
            .GroupBy(g => g.StudentId)
            .Select(g => new
            {
                Student = _student.FirstOrDefault(s => s.Id == g.Key),
                GradeCount = g.Count(),
                GradeCount = (int)g.Count(x => x.Score)
            })
            .Where(x => x.Student != null)
            .OrderByDescending(x => x.GradeCount)
            .Take(5)
            .Select(x => (x.Student!, x.GradeCount))
            .ToList();

        return Task.FromResult<IList<(Student, int)>>(topStudent);
    }

    /// <inheritdoc/>
    public Task<IList<(Student student, int gradeCount, double gradeAvg, int minScore, int maxScore)>> GetStudentGradeStatistics()
    {
        var studentStats = _grade
            .GroupBy(g => g.StudentId) // Группируем оценки по StudentId
            .Select(g => new
            {
                Student = _students.FirstOrDefault(s => s.Id == g.Key), // Находим ученика
                GradeCount = g.Count(), // Количество оценок
                GradeAvg = g.Average(x => x.Score), // Среднее значение оценок
                MinScore = g.Min(x => x.Score), // Минимальная оценка
                MaxScore = g.Max(x => x.Score) // Максимальная оценка
            })
            .Where(x => x.Student != null) // Фильтруем только тех, у кого есть ученик
            .Select(x => (x.Student!, x.GradeCount, x.GradeAvg, x.MinScore, x.MaxScore)) // Формируем кортеж
            .ToList();

        return Task.FromResult<IList<(Student, int, double, int, int)>>(studentStats); // Возвращаем результат
    }
}
