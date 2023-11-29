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
            //var user = _repository.GetById(id);

            //var UserDto = new UserDto
            //{
            //    Id = user.Id,
            //    Name = user.Name,
            //    Email = user.Email,
            //    Password = user.Password,
            //    Description = user.Description,
            //    Image = user.Image,
            //    Friends = user.Friends.Select(f => new FriendDto
            //    {
            //        UserId = f.UserFriend.userid,

            //    }).ToList()
            //};



            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _repository.GetAll().ToList();
        }
    }
}
