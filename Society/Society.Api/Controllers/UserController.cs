using Microsoft.AspNetCore.Mvc;
using Society.Api.Models;
using Society.Api.Repositories;

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
            return _repository.GetById(id);
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _repository.GetAll().ToList();
        }
    }
}
