using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculateGradeStats()
        {
            // Arrange
            var book = new InMemoryBook("");
            book.AddGrade(90.1);
            book.AddGrade(75.2);
            book.AddGrade(45.6);

            // Act
            var result = book.GetStatistics();

            // Assert
            Assert.Equal(70.3, result.Average, 1);
            Assert.Equal(90.1, result.High, 1);
            Assert.Equal(45.6, result.Low, 1);
            Assert.Equal('C', result.Letter);
        }
    }
}
