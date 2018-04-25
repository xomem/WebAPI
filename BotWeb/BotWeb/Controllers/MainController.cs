using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BotWeb.Controllers
{
    //[Route("api/")]
    [Route("api/")]
    public class MainController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        

        // GET api/values/5
        [HttpGet("phone/{id}")]
        public string Get(int id)
        {
            string textToReturn = "";
            if (Querys.MoreOneCar(Convert.ToString(id)))
            {
                textToReturn = string.Join("\n", Querys.GetCarsByChatID(Convert.ToString(id)));
            }
            else
            {
                string carNumber = StringEngine.ExtractFromBrackets(Querys.GetCarByChatId(Convert.ToString(id)));
                //await context.PostAsync(optionSelected);
                textToReturn = "Дата ТО - " + Convert.ToString(Querys.GetTIDate(carNumber));
            }
            return textToReturn;
        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
