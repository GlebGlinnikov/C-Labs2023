using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Lab2
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class Controller : ControllerBase
    {
        private static readonly TodoList list = new TodoList();

        [Microsoft.AspNetCore.Mvc.HttpGet(Name = "SearchByTag")]
        public TodoTask Search(string tag)
        {
            TodoTask result = new TodoTask();
            foreach (var task in list.Tasks)
            {
                if (task.Tags.Contains(tag))
                {
                    result = task;
                    break;
                }
            }
            return result;
        }

        [Microsoft.AspNetCore.Mvc.HttpPost(Name = "AddTask")]
        public IActionResult Add(string Title, string Description, DateTime Deadline, List<string> tags)
        {
            TodoTask temp = new TodoTask(Title, Description, Deadline, tags);
            list.Add(temp);
            return Ok();
        }
    }
}
