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
            return reservations.All(r=>r.Book.ISBN != book.ISBN);
        }

        public void Reserver(Book book, string name)
        {
            reservations.Add(new Reservation
            {
                Book = book,
                DateDebut = DateTime.Today,
                Nom = name
            });
        }

        public void RetourReservation(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
