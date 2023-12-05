using BookStore.Models;

namespace BookStore.Services
{
    public class ReservationBookService
    {

        /// <summary>
        /// elle retourne la liste
        /// des reservations
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Reservation> ListeReservations()
        {
           return Enumerable.Empty<Reservation>();
        }

        public bool IsDisponible(Book book)
        {
            return true;
        }
        public void Reserver(Book book, string name)
        {
            throw new NotImplementedException();
        }

        public void RetourReservation(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
