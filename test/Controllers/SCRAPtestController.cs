using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace test.Controllers
{
    public class SCRAPtestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("TEST")]
        public IEnumerable<SCRAPMTest> Get()
        {
            return Enumerable.Range(1, 4).Select(index => new SCRAPMTest
            {
                TestStrng = "Test"
            })
            .ToArray();
        }

        [HttpGet("aTEST")]
        public string testFunc()
        {
            string b = "aTEST";
            return b;
        }

        [HttpGet("bTest")]
        public string testFuncTwo()
        {
            return "bTest";
        }

    }

}
