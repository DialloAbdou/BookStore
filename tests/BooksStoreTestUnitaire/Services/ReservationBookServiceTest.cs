using BookStore.Models;
using BookStore.Services;
using FluentAssertions;

namespace BooksStoreTestUnitaire.Services
{
    public class ReservationBookServiceTest
    {
        private ReservationBookService _reserveBookService;
        private Book seigneurDesAnneaux = new Book()
        {
            Title = "Le Seigneur des Anneaux, Tome 1 : La Fraternité de l'Anneau",
            Author = "J. R. R. Tolkien",
            NbPages = 528,
            ISBN = "2267027003"
        };
        public ReservationBookServiceTest()
        {
            _reserveBookService = new ReservationBookService();
        }

        [Fact]
        public void ListeReservaation_Should_return_empty_When_No_Reservetaion_InDB()
        {
            // Act
            var result = _reserveBookService.ListeReservations();
            //Assert
            result.Should().BeEmpty();
        }


        [Fact]
        public void ReserveBook_When_Book_IsDisponible()
        {
            // Act
            var isdispo = _reserveBookService.IsDisponible(seigneurDesAnneaux);
            _reserveBookService.Reserver(seigneurDesAnneaux, "abdou");
       
        }

        [Fact]
        public void ListeReservaation_Should_Return_Colection_When_have_CurrentReservation_InDB()
        {
            // Act
            _reserveBookService.Reserver(seigneurDesAnneaux, "abdou");
            IEnumerable<Reservation>? result = _reserveBookService.ListeReservations();
            result.Should().NotBeEmpty();
            var bookeReserve = result.FirstOrDefault();
            bookeReserve!.Nom.Should().Be("abdou");
            bookeReserve.Book.Should().Be(seigneurDesAnneaux);
           
        }

        [Fact]
        public void ReserveBook_Should_False_When_Book_is_Not_isponible()
        {
            // Act
            _reserveBookService.Reserver(seigneurDesAnneaux, "abdou");
            var isdispo = _reserveBookService.IsDisponible(seigneurDesAnneaux);
            isdispo.Should().BeFalse();
        }

        [Fact]
        public void isDisponible_should_True_When_Book_isDisponible()
        {
            // Act
            var isdispo = _reserveBookService.IsDisponible(seigneurDesAnneaux);
            isdispo.Should().BeTrue();
        }
    }
}
