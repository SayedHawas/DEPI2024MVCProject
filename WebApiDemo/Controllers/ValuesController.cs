using Microsoft.AspNetCore.Mvc;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        static List<string> names = new List<string> { "Sayed", "zayed", "Retaj", "Marima" };

        //localhost:5202/api/Values
        [HttpGet]
        public IEnumerable<string> GetEmployee()
        {
            return names;
        }
        [HttpGet("{id:int}")]
        //[Route("api/{id}")]
        public string GetByID(int id)
        {
            var employee = names.Count > id ? names[id] : null;
            return employee;
        }
        [HttpGet("Show")]
        public string GetShow()
        {
            return "Welcome in Web api Core ...";
        }

        [HttpGet("ShowNumber")]
        public int GetNumber(int num)
        {
            return num;
        }

    }
}
