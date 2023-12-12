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
        public void ReserveBook_Should_Does_Not_Anything_If_Book_Is_Already_reserved()
        {
            // Act
            _reserveBookService.IsDisponible(seigneurDesAnneaux).Should().BeTrue();
            _reserveBookService.Reserver(seigneurDesAnneaux, "abdou");
            _reserveBookService.IsDisponible(seigneurDesAnneaux).Should().BeFalse();
            _reserveBookService.Reserver(seigneurDesAnneaux, "abdou");
         
            var reservations = _reserveBookService.ListeReservations();
            reservations.Should().HaveCount(1); 
            var reservation = reservations.First();
            reservation.Book.Should().Be(seigneurDesAnneaux);
            reservation.Nom.Should().Be("abdou");
            reservation.DateFin.Should().NotHaveValue();


        }

        [Fact]
        public void isDisponible_should_Return_True_when_the_book_isdisponible()
        {
            // Act
            var isdispo = _reserveBookService.IsDisponible(seigneurDesAnneaux);
            isdispo.Should().BeTrue();
        }

        [Fact]
        public void isDisponible_should_false_When_Book_isNotDisponible()
        {
            // Act
             _reserveBookService.IsDisponible(seigneurDesAnneaux).Should().BeTrue();
            _reserveBookService.Reserver(seigneurDesAnneaux, "abdou");
            _reserveBookService.IsDisponible(seigneurDesAnneaux).Should().BeFalse(); ;

        }


        [Fact]
        public void RetourBook_Make_Book_IsDisponible()
        {
           _reserveBookService.IsDisponible(seigneurDesAnneaux).Should().BeTrue();
            _reserveBookService.Reserver(seigneurDesAnneaux, "abdou");
            _reserveBookService.IsDisponible(seigneurDesAnneaux).Should().BeFalse();
            _reserveBookService.RetourReservation(seigneurDesAnneaux);
            _reserveBookService.IsDisponible(seigneurDesAnneaux).Should().BeTrue();


        }


        [Fact]
        public void RetourBook_Should_Be_Not_Do_AnyThing_IF_Book_IS_NOT_Reserved()
        {
            _reserveBookService.IsDisponible(seigneurDesAnneaux).Should().BeTrue();
            _reserveBookService.Reserver(seigneurDesAnneaux, "abdou");
            _reserveBookService.IsDisponible(seigneurDesAnneaux).Should().BeFalse();
            _reserveBookService.RetourReservation(seigneurDesAnneaux);
            _reserveBookService.IsDisponible(seigneurDesAnneaux).Should().BeTrue();


        }

    }
}
