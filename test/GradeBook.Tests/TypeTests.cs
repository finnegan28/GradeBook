using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            

            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello");

            Assert.Equal(3, count);
        }

        string IncrementCount(string message)
        {
            count++;
            return message;
        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            // Arrange
            string name = "Neil";
            
            // Act
            var upper = MakeUppercase(name);

            // Assert
            Assert.Equal("Neil", name);
            Assert.Equal("NEIL", upper);
            
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void ValueTypeAlsoPassedByValue()
        {
            // Arrange
            var x = GetInt();
            
            // Act
            SetInt(ref x);

            // Assert
            Assert.Equal(42, x);
            
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            // Arrange
            var book1 = GetBook("Book 1");
            
            // Act
            GetBookSetName(ref book1, "New Name");

            // Assert
            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

       [Fact]
        public void CSharpIsPassByValue()
        {
            // Arrange
            var book1 = GetBook("Book 1");
            
            // Act
            GetBookSetName(book1, "New Name");

            // Assert
            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

       [Fact]
        public void CanSetNameFromReference()
        {
            // Arrange
            var book1 = GetBook("Book 1");
            
            // Act
            SetName(book1, "New Name");

            // Assert
            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDefferentObjects()
        {
            // Arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            // Act

            // Assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            // Arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;
            // Act

            // Assert
            Assert.Same(book1, book2);
        }


        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
