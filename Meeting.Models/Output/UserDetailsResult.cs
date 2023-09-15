using Meeting.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meeting.Models.Output
{
    public class UserDetailResult
    {
       

        public UserDetailsDTO? UserDetails { get; set; }
        public List<UserDetailsDTO>? UserDetailsList { get; set; }
       
    }

}
