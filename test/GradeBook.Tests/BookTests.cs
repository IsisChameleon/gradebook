using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        public delegate string WriteLogDelegate(string logMessage);
        int count=0;
        
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log;

            log = new WriteLogDelegate(ReturnMessage); // log is a function pointer to a function looking 
                                                       //like WriteLogDelegate pointing to the function ReturnMessage

            // the above can also be written more easily as :

            log = ReturnMessage;
            log += ReturnMessage;
            log += ReturnMessage2;
            
            var result = log("Hello");
            Assert.Equal("Hello", result);
            Assert.Equal(3, count);
        }

        string ReturnMessage(string msg)
        {
            count++;
            return msg.ToLower();
        }
  
        string ReturnMessage2(string msg)
        {
            count++;
            return msg;
        }
        
        [Fact]
        public void BookCalculatesAnAverageGrade()
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
            Console.WriteLine($"Letter : {result.Letter}");

            // assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);

        }
    }
}
