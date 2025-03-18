using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolDiary.Domain.Model;
using SchoolDiary.Domain.Services.InMemory;
using Xunit;

namespace SchoolDiary.Domain.Tests;

/// <summary>
/// Класс с юнит-тестами репозитория с предметами
/// </summary>
public class SubjectRepositoryTests
{
    /// <summary>
    /// Тест проверяет успешное получение предметов, по которым были выставлены оценки за указанный период.
    /// </summary>
    [Fact]
    public async Task GetSubjectsByGradePeriod_Success()
    {
        var repo = new SubjectInMemoryRepository();
        var subject = await repo.GetSubjectsByGradePeriod(20230101, 20231231);

        Assert.NotNull(subject);
    }

    /// <summary>
    /// Тест проверяет успешное получение количества оценок для каждого предмета.
    /// </summary>
    [Fact]
    public async Task GetGradeCountBySubject_Success()
    {
        var repo = new SubjectInMemoryRepository();
        var gradeCounts = await repo.GetGradeCountBySubject();

        Assert.NotNull(gradeCounts);
    }

    /// <summary>
    /// Тест проверяет успешное получение топ-предметов по количеству оценок за указанный период.
    /// </summary>
    [Fact]
    public async Task GetTopSubjectsByGradePeriod_Success()
    {
        var repo = new SubjectInMemoryRepository();
        var topSubjects = await repo.GetTopSubjectsByGradePeriod(20230101, 20231231);

        Assert.NotNull(topSubjects);
    }
}