using BookStore.Models;
using System.Reflection.Metadata.Ecma335;

namespace BookStore.Services
{
    public class ReservationBookService
    {

        private List<Reservation> reservations = new();
        /// <summary>
        /// elle retourne la liste
        /// des reservations
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Reservation> ListeReservations()
        {
          return reservations.AsEnumerable();
        
        }

        public bool IsDisponible(Book book)
        {
            return !reservations.Any(r=>r.Book.ISBN == book.ISBN && r.DateFin  is  null);
        }

        public void Reserver(Book book, string name)
        {
            if (!IsDisponible(book)) return;
            reservations.Add(new Reservation
            {
                Book = book,
                DateDebut = DateTime.Today,
                Nom = name
            });
        }

        public void RetourReservation(Book book)
        {
            if (!IsDisponible(book))
            {
                var bookReserve = reservations.FirstOrDefault(r => r.Book.ISBN == book.ISBN);
                if(bookReserve is not null)
                {
                    bookReserve.DateFin = DateTime.Today;
                }
               
            }
        }
    }
}
