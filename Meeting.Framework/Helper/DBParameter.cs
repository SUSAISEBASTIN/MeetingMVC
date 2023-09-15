using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meeting.Framework.Helper
{
    public class DBParameter
    {
        public class Registeration 
        { 
            public const string bookingId = "@BookingId";
            public const string teamName = "@TeamName";
            public const string roomNo = "@RoomNo";
            public const string meetingDate = "@MeetingDate";
            public const string fromTime = "@FromTime";
            public const string toTime = "@ToTime";
            public const string purpose = "@Purpose";

        }

    }
}
