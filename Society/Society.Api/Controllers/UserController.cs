using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Society.Api.Repositories;
using Society.Shared.Models;

namespace Society.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _repository;

        public UserController(IRepository<User> repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(Guid id)
        {
            var user = _repository.GetById(id);
            if (user is null)
            {
                return NotFound($"User with id: {id} was not found");
            }

            return Ok(_repository.GetById(id));
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            var users = _repository.GetAll().ToList();
            if (users.IsNullOrEmpty())
            {
                return NotFound($"No users were found");
            }

            return Ok(users);
        }

        [HttpPost("{user}")]
        public ActionResult Add(User user)
        {
            if (user is null)
            {
                return NotFound($"User does not exist");
            }

            _repository.Add(user);
            return Ok("User was successfully added");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var user = _repository.GetById(id);
            if (user is null)
            {
                return NotFound($"User with id: {id} was not found");
            }

            _repository.Delete(id);
            return Ok("User was successfully deleted");
        }

        [HttpPut("{user}")]
        public ActionResult Update(User user)
        {
            if (user is null)
            {
                return NotFound($"User does not exist");
            }

            _repository.Update(user);
            return Ok("User was successfully updated");
        }
    }
}
