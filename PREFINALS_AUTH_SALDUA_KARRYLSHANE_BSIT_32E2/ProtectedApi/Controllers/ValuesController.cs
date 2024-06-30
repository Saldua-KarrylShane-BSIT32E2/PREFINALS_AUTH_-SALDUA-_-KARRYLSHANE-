using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ProtectedApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<object> Get()
        {
            var user = HttpContext.User.Identity.Name;
            var userSection = "32E2";
            var userCourse = "Bachelor of Science in Information Technology";

            var funFacts = new List<string>
            {
                "This Creator is a tiktoker.",
                "Henlo, my name is Karryl Shane S. Saldua",
                "I really love to dance and listen to music.",
                "I am an ambivert hehe",
                "My Favorite hobby is biking, swimming, and watching movies.",
                "I believe that I am one of a class."
                "I love everyhting about me wiee."
                
            };

            // Random generator
            var random = new Random();
            var selectedFacts = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                var index = random.Next(funFacts.Count);
                selectedFacts.Add(funFacts[index]);
                funFacts.RemoveAt(index);
            }

            return new
            {
                UserName = user,
                Section = userSection,
                Course = userCourse,
                FunFacts = selectedFacts
            };
        }
    }
}