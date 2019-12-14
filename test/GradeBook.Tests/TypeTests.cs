using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void SringsBehaveLikeValueType()
        {
            string name = "isabelle";
            var upper = MakeUppercase(name);

            Assert.Equal("ISABELLE", upper);

        }

        private string MakeUppercase(string x)
        {
            return x.ToUpper();
        }

        [Fact]
        public void OldTest1()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);

        }

        [Fact]
        public void CSharpCanPassByRef()
        {
                var book1 = GetBook("Book 1");
                GetBookSetNameRef(ref book1, "New Name");
                Assert.Equal("New Name", book1.Name);
        }
        private void GetBookSetNameRef(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
                var book1 = GetBook("Book 1");
                GetBookSetName(book1, "New Name");
                Assert.Equal("Book 1", book1.Name);
        }
        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        private InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
