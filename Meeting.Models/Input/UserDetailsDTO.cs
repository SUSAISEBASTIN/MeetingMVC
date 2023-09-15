using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meeting.Models.Input
{
    public class UserDetailsDTO
    {
        public int? BookingId { get; set; }
        public string? TeamName { get; set; }
        public string? RoomNo { get; set; }
        public string? MeetingDate { get; set; }
        public string? FromTime { get; set; }
        public string? ToTime { get; set; }
        public string? Purpose { get; set; }

    }
}
