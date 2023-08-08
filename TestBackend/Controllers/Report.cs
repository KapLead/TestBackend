using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestBackend.Data;

namespace TestBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Report : ControllerBase
    {
        private static readonly Context Instance = new(new DbContextOptions<Context>());

        [HttpPost(Name = "user_statistic"),Route("user_statistic")]
        public Response Post(string user)
        {
            var u = Instance.Users.FirstOrDefault(u => u.Id == new Guid(user));
            if (u == null)
                u = new User { Id = new Guid(user), CountSignIn = 1 };
            else 
                u.CountSignIn++;
            Instance.SaveChanges();
            return new Response();
        }

        [HttpGet(Name = "info"),Route("info")]
        public Response Get(string user,string query)
        {
            User? u;
            try
            {
                u = Instance.Users.FirstOrDefault(usr => usr.Id == new Guid(user));
            }
            catch
            {
                return new Response()
                {
                    query = new Guid(),
                    persent = 0,
                    result = null
                };
            }
            if (u == null)
            {
                u = new User { Id = new Guid(user), CountSignIn = 1 }; 
                Instance.Users.Add(u);
            }
            else 
                u.CountSignIn++;
            var req = Instance.Requests.FirstOrDefault(r => r.Query == new Guid(query));
            if (req == null)
            {
                req = new Request { Query = new Guid(query), Data = DateTime.Now };
                Instance.Requests.Add(req);
            }
            Instance.SaveChanges();
            var persent = ((DateTime.Now - req.Data).TotalSeconds*100)/60;
            RespResult? result = null;
            if (persent > 100)
            {
                persent = 100;
                result = new RespResult(u.Id,u.CountSignIn);
            }
            Debug.WriteLine($"Request {u.Id} persent={persent}%");
            return new Response
            {
                query = new Guid(query), 
                persent = (int)persent, 
                result = result
            };
        }
    }
}