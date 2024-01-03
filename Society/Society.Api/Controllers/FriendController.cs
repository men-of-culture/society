using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Society.Api.Repositories;
using Society.Shared.Models;
using System.Collections.Generic;

namespace Society.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly FriendRepository _repository;

        public FriendController(FriendRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Friend>> GetAllById(Guid id)
        {
            return Ok(_repository.GetAllById(id));
        }

        [HttpPost]
        public ActionResult AddFriend([FromBody]JObject data)
        {
            User user = data["user"].ToObject<User>();
            User userFriend = data["userFriend"].ToObject<User>();
            _repository.AddFriend(user, userFriend);
            return Ok("Friend was successfully added");
        }

        //[HttpDelete]
        //public ActionResult DeleteFriend(User user, User userFriend)
        //{
        //    _repository.DeleteFriend(user, userFriend);
        //    return Ok("Friend was successfully deleted");
        //}


    }
}
