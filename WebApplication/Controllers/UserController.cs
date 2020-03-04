using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/user/getAllUsers
        [HttpGet("[action]")]
        public ActionResult GetAllUsers()
        {
            var userService = Factory.InstantiateUserService();

            var operationResult = userService.GetAllUsers();

            if (operationResult.HasSucceeded && operationResult.Result.Count == 0)
                return NoContent();

            if (operationResult.HasSucceeded)
                return Ok(operationResult.Result);

            return BadRequest(operationResult.Exception.Message);
        }

        // GET: api/user/getUserByUserName/username
        [HttpGet("[action]/{username}")]
        public ActionResult GetUserByUserName(string username)
        {   
            var userService = Factory.InstantiateUserService();

            var operationResult = userService.GetUserByUserName(username);

            if (operationResult.HasSucceeded)
                return Ok(operationResult.Result);
            
            return BadRequest(operationResult.Exception.Message);
        }

        // POST: api/User
        [HttpPost("[action]")]
        public ActionResult CreateUser(UserRequestDTO user)
        {
            var userService = Factory.InstantiateUserService();

            var operationResult = userService.CreateUser(user);

            if (operationResult.HasSucceeded)
                return Ok();

            return BadRequest(operationResult.Exception.Message);
        }

    }
}
