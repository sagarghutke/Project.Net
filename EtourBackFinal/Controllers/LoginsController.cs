using EtourBackFinal.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace EtourBackFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly ETourContext _context;

        public LoginsController(ETourContext context)
        {
            _context = context;
        }

        // POST: api/Logins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoginResponse>> PostLogin(LoginRequest request)
        {
            string pass = null;
            if (request != null)
            {
                pass = HashPassword(request.Password);
            }

            var customer = await _context.CustomerMaster.FirstOrDefaultAsync(_customers => _customers.PhoneNumber.Equals(request.PhoneNumber) && _customers.Password.Equals(pass));

            if (customer != null)
            {
                if (customer.PhoneNumber.Equals(request.PhoneNumber) && customer.Password.Equals(pass))
                {
                    return Ok(new LoginResponse { Success = true, Customer = customer });
                }
            }

            return BadRequest("Invalid PhoneNo. OR Password");
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convert the password to a byte array and compute the hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert the hashed byte array back to a string and return it
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }

    public class LoginRequest
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public bool Success { get; set; }
        public Customer_Master Customer { get; set; }
    }
}