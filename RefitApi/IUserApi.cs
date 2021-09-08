using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace RefitApi
{
    /// <summary>
    /// A useless api for users
    /// </summary>
    public interface IUserApi
    {
        /// <summary>
        /// Gets all the useless users
        /// </summary>
        /// <returns>some users</returns>
        [Get("/api/users/v1")]
        Task<IEnumerable<User>> GetUsers();

        /// <summary>
        /// Create a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Post("/api/users/v1")]
        Task CreateUser(User user);

        /// <summary>
        /// Get a user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Get("/api/users/v1/{id}")]
        Task<User> GetUser(int id);
        
    }
}