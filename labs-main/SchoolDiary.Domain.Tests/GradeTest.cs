using SchoolDiary.Domain.Services.InMemory;
using SchoolDiary.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SchoolDiary.Domain.Tests;

/// <summary>
/// Класс с юнит-тестами репозитория с оценками
/// </summary>
public class GradeRepositoryTests
{
    /// <summary>
    /// Тест проверяет успешное получение статистики по оценкам учеников.
    /// </summary>
    [Fact]
    public async Task GetStudentGradeStatistics_Success()
    {
        var repo = new GradeInMemoryRepository();
        var statistics = await repo.GetStudentGradeStatistics();

        Assert.NotNull(statistics);
    }
}