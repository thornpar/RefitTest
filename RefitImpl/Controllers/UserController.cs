using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Refit;
using RefitApi;

namespace RefitTest.Controllers
{

    public static class UserRepo
    {
        public static List<User> users = new()
        {
            new User
            {
                Age = 10,
                Id = 1,
                Name = "Pelle"
            },
            new User
            {
                Age = 11,
                Id = 2,
                Name = "Kalle"
            },
            new User
            {
                Age = 12,
                Id = 3,
                Name = "Nisse"
            },
        };
    }

    [ApiController]
    [Route("api/[controller]s/v1")]
    public class UserController : ControllerBase, IUserApi
    {
        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await Task.Run(() => UserRepo.users);
        }

        [HttpPost]
        public async Task CreateUser([FromBody]User user)
        {
            await Task.Run(() => UserRepo.users.Add(user));
        }

        [HttpGet("{id:int}")]
        public async Task<User> GetUser(int id)
        {
            return await Task.Run(() => UserRepo.users.FirstOrDefault(e => e.Id == id));
        }
    }
}