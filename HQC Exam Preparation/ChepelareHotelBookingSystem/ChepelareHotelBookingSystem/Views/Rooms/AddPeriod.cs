namespace ChepelareHotelBookingSystem.Views.Rooms
{
    using System.Text;

    using ChepelareHotelBookingSystem.Infrastructure;

    public class AddPeriod : View
    {
        public AddPeriod(Models.Room room)
            : base(room)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var room = this.Model as Models.Room;
            viewResult.AppendFormat("The period has been added to room with ID {0}.", room.Id)
                .AppendLine();
        }
    }
}