using SchoolDiary.Domain.Model;
using SchoolDiary.Domain.Services.InMemory;

namespace SchoolDiary.Domain.Tests;

/// <summary>
/// Класс юнит-теста репозитория с учениками
/// </summary>
public class StudentRepositoryTests
{
    /// <summary>
    /// Тест проверяет успешное получение ученика с его классом
    /// </summary>
    [Fact]
    public async Task GetStudentWithClass_Success()
    {
        var repo = new StudentInMemoryRepository();
        var studentClasses = await repo.GetStudentWithClass(1);

        Assert.NotNull(studentClasses);
        Assert.NotNull(studentClasses?.student);
        Assert.NotNull(studentClasses?.classes);
    }

    /// <summary>
    /// Тест проверяет успешное получение топ-5 учеников по количеству оценок
    /// </summary>
    [Fact]
    public async Task GetTop5StudentsByGradeCount_Success()
    {
        var repo = new StudentInMemoryRepository();
        var topStudent = await repo.GetTop5StudentsByGradeCount();

        Assert.NotNull(topStudent);
        Assert.True(topStudent.Count <= 5);
    }

    /// <summary>
    /// Тест проверяет успешное получение статистики по оценкам учеников
    /// </summary>
    [Fact]
    public async Task GetStudentGradeStatistics_Success()
    {
        var repo = new StudentInMemoryRepository();
        var statistics = await repo.GetStudentGradeStatistics();

        Assert.NotNull(statistics);
    }
}