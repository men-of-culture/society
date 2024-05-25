using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Society.Api.Repositories;
using Society.Shared.Models;

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

        [HttpGet("{userId}/{friendId}")]
        public ActionResult<Friend> Get(Guid userId, Guid friendId)
        {
            var friend = _repository.GetById(userId, friendId);
            if (friend is null)
            {
                return NotFound($"Friend with userId: {userId} and friendId: {friendId} was not found");
            }

            return Ok(friend);
        }

        [HttpGet("{userId}")]
        public ActionResult<IEnumerable<Friend>> GetAll(Guid userId)
        {
            var friends = _repository.GetAll(userId).ToList();
            if (friends.IsNullOrEmpty())
            {
                return NotFound($"No friends were found to userId: {userId}");
            }

            return Ok(friends);
        }

        [HttpPost("{friend}")]
        public ActionResult Add(Friend friend)
        {
            if (friend is null)
            {
                return NotFound($"Friend does not exist");
            }

            _repository.Add(friend);
            return Ok("Friend was successfully added");
        }

        [HttpDelete("{userId}/{friendId}")]
        public ActionResult Delete(Guid userId, Guid friendId)
        {
            var friend = _repository.GetById(userId, friendId);
            if (friend is null)
            {
                return NotFound($"Friend with userId: {userId} and friendId: {friend} was not found");
            }

            _repository.Delete(userId, friendId);
            return Ok("Friend was successfully deleted");
        }

        [HttpPut("{friend}")]
        public ActionResult Update(Friend friend)
        {
            if (friend is null)
            {
                return NotFound($"Friend does not exist");
            }

            _repository.Update(friend);
            return Ok("Friend was successfully updated");
        }
    }
}
