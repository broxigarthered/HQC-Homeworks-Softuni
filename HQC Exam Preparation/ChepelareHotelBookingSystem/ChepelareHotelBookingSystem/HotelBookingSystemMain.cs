using System;

namespace ChepelareHotelBookingSystem
{
    using ChepelareHotelBookingSystem.Core;

    public class HotelBookingSystemMain
    {
        public static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            var engine = Activator.CreateInstance(typeof(Engine)) as Engine;
            engine.StartOperation();
        }
    }
}
