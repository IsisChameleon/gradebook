using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            // arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            Statistics result = book.GetStatistics();

            Console.WriteLine($"Average actual : {result.Average}");
            Console.WriteLine($"High actual : {result.High}");
            Console.WriteLine($"Low actual : {result.Low}");

            // assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);

        }
    }
}
