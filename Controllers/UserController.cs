using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        IUserService ius;
        public UserController(IUserService iuser){
            ius=iuser;
        }
        //uruitsservice us;
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(this.ius.GetUsers());
            //return Ok();
        }
        [HttpPost]
        public ActionResult Post(User u)
        {
            ius.AddUsers(u);
            return Ok();
        }
        [HttpPut]
        public ActionResult Put(User u)
        {
            ius.UpdateUsers(u);
            return Ok();
        }
        [HttpDelete]
        public ActionResult Delete(User u)
        {
            ius.DeleteUsers(u);
            return Ok();
        }
    }
}