using Microsoft.AspNetCore.Mvc;
using WeatherForcast.Sources;

namespace WeatherForcast.Controllers
{
    [Route("api/weather")]
    [ApiController]
    public class WeatherController : ControllerBase
    {

        private readonly WeatherDB _holder;

        #region Конструкторы
        public WeatherController(WeatherDB holder)
        { 
            _holder = holder;
        }
        #endregion

        [HttpPost("add")]
        public IActionResult Add([FromQuery] DateTime date, [FromQuery] int temperature, [FromQuery] byte windSpeed) 
        {
            bool result = _holder.AddRecord(date, temperature, windSpeed);
            return Ok(result?"Запись добавлена":"Запись за эту дату уже существет");
        }

        [HttpPut("edit")]
        public IActionResult Update([FromQuery] DateTime date, [FromQuery] int temperature, [FromQuery] byte windSpeed)
        {
            bool result = _holder.EditRecord(date, temperature, windSpeed);
            return Ok(result ? "Запись изменена" : "Запись за эту дату не существет");
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] DateTime date)
        {
            bool result = _holder.DeleteRecord(date);
            return Ok(result ? "Запись удалена" : "Запись за эту дату не существет");        
        }

        [HttpGet("index")]
        public IActionResult Get([FromQuery] DateTime dateFrom, [FromQuery] DateTime dateTo)
        {
            return Ok(_holder.Get(dateFrom, dateTo));
        }
    }
}
