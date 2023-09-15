using Meeting.Models.Input;
using Meeting.Service.Interface;
using Meeting.Service.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Meeting.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        public readonly IUserDetailsService _userDetailsService;

        public RegisterController(IUserDetailsService userDetailsService)
        {
            _userDetailsService = userDetailsService;
        }

        // GET: api/<RegisterController>
        [HttpGet]
        public async Task<IActionResult> GetUserDetailsAsync()
        {
            return Ok(await _userDetailsService.GetUserDetailsAsync());
        }

        // GET api/<RegisterController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserDetailsByIdAsync(int id)
        {
            return Ok(await _userDetailsService.GetUserDetailsByIdAsync(id));
        }

        // POST api/<RegisterController>
        [HttpPost]
        [ActionName("AddUserDetailsAsync")]
        public async Task<IActionResult> AddUserDetailsAsync([FromBody] UserDetailsDTO userDetail)
        {
            //userDetail.BookingId = id;
            return Ok(await _userDetailsService.AddUserDetailsAsync(userDetail));
        }

        // PUT api/<RegisterController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserDetailsAsync( int id,[FromBody] UserDetailsDTO userDetail)
        {
            userDetail.BookingId=id;
            return Ok(await _userDetailsService.UpdateUserDetailsAsync(userDetail));
        }
    

    // DELETE api/<RegisterController>/5
    [HttpDelete]
        public async Task<IActionResult> DeleteUserDetailsAsync(int Id)
        {
            return Ok(await _userDetailsService.DeleteUserDetailsAsync(Id));
        }
    }
}
