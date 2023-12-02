using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Lab2
{
    [ApiController]
    [Route("[controller]")]
    public class Controller : ControllerBase
    {
        private static readonly MarkList list = new MarkList();

        [HttpGet(Name = "GetMark")]
        public Mark GetNum(int n)
        {
            return list.GetMark(n);
        }

        [HttpPost(Name = "AddMark")]
        public IActionResult Add(double a, double b, double c)
        {
            Mark m = new Mark(a,b,c);
            list.add(m);
            return Ok();
        }
    }
}