using Meeting.Models;
using Meeting.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meeting.Service.Interface
{
    public interface IUserDetailsService
    {
        Task<ResultDataArgs> AddUserDetailsAsync(UserDetailsDTO userDetailDTO);

        Task<ResultDataArgs> DeleteUserDetailsAsync(int Id);

        Task<ResultDataArgs> GetUserDetailsAsync();

        Task<ResultDataArgs> GetUserDetailsByIdAsync(int Id);

        Task<ResultDataArgs> UpdateUserDetailsAsync(UserDetailsDTO userDetailDTO);

    }
}
