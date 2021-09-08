using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Refit;
using RefitApi;

namespace RefitUse.Controllers
{
    [ApiController]
    [Route("test")]
    public class ExampleController : ControllerBase
    {
        private readonly IUserApi _userApi;

        public ExampleController(IUserApi userApi)
        {
            _userApi = userApi;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> UseTheUsersApi()
        {
            var result = await _userApi.GetUsers();

            var id = new Random(10).Next(0, 9999);
            await _userApi.CreateUser(new User
            {
                Age = 100,
                Id = id,
                Name = $"Pelle {id}"
            });

            var singleResult = await _userApi.GetUser(1);

            return Ok(result);
        }
    }
}