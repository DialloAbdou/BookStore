using BookStore.Services;
using FluentAssertions;

namespace BookStoreTest.services
{

    public class BookServiceTest
    {
        private BookService service;

        public BookServiceTest()
        {
                service = new BookService();    
        }

        [Fact]
        public void ReserverLivre_should_InvalidOperationException_When_Book_Not_INDB()
        {
            //Arrange
            var isbn = "2xxxx";
            var nom = "diallo";
            // Act
             Action action = () => service.ReserverLivre(isbn, nom);
            //Assert
            action.Should().Throw<InvalidOperationException>();
       
        }

        [Fact]
        public void ReserverLivre_should_InvalidOperationException_When_Book_Is_Imprinted()
        {
            //Arrange
            var isbn = "2070584623";
            var nom = "diallo";
            // Act
            Action action = () => service.ReserverLivre(isbn, nom);
            //Assert
            action.Should().Throw<InvalidOperationException>();

        }

        [Fact]
        public void ReserverLivre_should_InvalidOperationException_When_Book_Is_Not_Imprinted()
        {
            //Arrange
            var isbn = "2267027003";
            var nom = "diallo";
            // Act
            var result = service.ReserverLivre(isbn, nom);
            //Assert
            result.Should().NotBeNull();
             result.ISBN.Should().Be(isbn);

        }
    }
}
