namespace ChepelareHotelBookingSystem.Controllers
{
    using System;
    using System.Linq;

    using Enums;
    using Infrastructure;
    using Interfaces;
    using Models;

    public class RoomsController : Controller
    {
        public RoomsController(IHotelBookingSystemData data, User user)
            : base(data, user)
        {
        }

        /// <summary>
        /// Adds a new room to the venue with the specified ID.
        /// </summary>
        /// <param name="venueId">Venue id.</param>
        /// <param name="places">Places.</param>
        /// <param name="pricePerDay">The price per day.</param>
        /// <returns>New view.</returns>
        public IView Add(int venueId, int places, decimal pricePerDay)
        {
            this.Authorize(Roles.VenueAdmin);
            var venue = this.Data.RepositoryWithVenues.Get(venueId);
            if (venue == null)
            {
                return this.NotFound(string.Format("The venue with ID {0} does not exist.", venueId));
            }

            var newRoom = new Room(places, pricePerDay);
            venue.Rooms.Add(newRoom);
            this.Data.RepositoryWithRooms.Add(newRoom);
            return this.View(newRoom);
        }

        /// <summary>
        /// Adds a new period to the room with the specified ID.
        /// </summary>
        /// <param name="roomId">Room's id.</param>
        /// <param name="startDate">Start date.</param>
        /// <param name="endDate">End date.</param>
        /// <returns>New view.</returns>
        public IView AddPeriod(int roomId, DateTime startDate, DateTime endDate)
        {
            this.Authorize(Roles.VenueAdmin);
            var room = this.Data.RepositoryWithRooms.Get(roomId);
            if (room == null)
            {
                return this.NotFound(string.Format("The room with ID {0} does not exist.", roomId));
            }

            if (startDate > endDate)
            {
                throw new ArgumentException("The date range is invalid.");
            }
            room.AvailableDates.Add(new AvailableDate(startDate, endDate));
            return this.View(room);
        }

        /// <summary>
        /// Displays all booking information about the room with the specified ID.
        /// </summary>
        /// <param name="id">Room's id.</param>
        /// <returns>New view.</returns>
        public IView ViewBookings(int id)
        {
            this.Authorize(Roles.VenueAdmin);
            var room = this.Data.RepositoryWithRooms.Get(id);
            if (room == null)
            {
                return this.NotFound(string.Format("The room with ID {0} does not exist.", id));
            }

            return this.View(room.Bookings);
        }

        /// <summary>
        /// Books the room with the specified ID. As a result, creates a new booking entry in the database and updates the room’s available periods.
        /// </summary>
        /// <param name="roomId">Room's id.</param>
        /// <param name="startDate">The start date of the reservation.</param>
        /// <param name="endDate">The end date of the reservation.</param>
        /// <param name="comments">Booking comments.</param>
        /// <returns>New view.</returns>
        public IView Book(int roomId, DateTime startDate, DateTime endDate, string comments)
        {
            this.Authorize(Roles.User, Roles.VenueAdmin);
            var room = this.Data.RepositoryWithRooms.Get(roomId);
            if (room == null)
            {
                return this.NotFound(string.Format("The room with ID {0} does not exist.", roomId));
            }

            if (endDate < startDate)
            {
                throw new ArgumentException("The date range is invalid.");
            }

            var availablePeriod = room.AvailableDates.FirstOrDefault(d => d.StartDate <= startDate && d.EndDate >= endDate);
            if (availablePeriod == null)
            {
                throw new ArgumentException(string.Format("The room is not available to book in the period {0:dd.MM.yyyy} - {1:dd.MM.yyyy}.", startDate, endDate));
            }

            decimal totalPrice = (endDate - startDate).Days * room.PricePerDay;
            var booking = new Booking(this.CurrentUser, startDate, endDate, totalPrice, comments);
            room.Bookings.Add(booking);
            this.CurrentUser.Bookings.Add(booking);
            this.UpdateRoomAvailability(startDate, endDate, room, availablePeriod);
            return this.View(booking);
        }

        // This works, don't touch!
        private void UpdateRoomAvailability(DateTime startDate, DateTime endDate, Room room, AvailableDate availablePeriod)
        {
            room.AvailableDates.Remove(availablePeriod);
            var periodBeforeBooking = startDate - availablePeriod.StartDate;
            if (periodBeforeBooking > TimeSpan.Zero)
            {
                room.AvailableDates.Add(new AvailableDate(availablePeriod.StartDate, availablePeriod.StartDate.Add(periodBeforeBooking)));
            }

            var periodAfterBooking = availablePeriod.EndDate - endDate;
            if (periodAfterBooking > TimeSpan.Zero)
            {
                room.AvailableDates.Add(new AvailableDate(availablePeriod.EndDate.Subtract(periodAfterBooking), availablePeriod.EndDate));
            }
        }
    }
}
