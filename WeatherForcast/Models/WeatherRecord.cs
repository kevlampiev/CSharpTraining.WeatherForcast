namespace WeatherForcast.Models
{
    /// <summary>
    /// Запись о погоде в определенный момент времени
    /// </summary>
    public class WeatherRecord
    {
        /// <summary>
        /// Дата измерения
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Температура в градусах цельсия
        /// </summary>
        public int TemperatureC { get; set; } 

        /// <summary>
        /// Скорость ветра в метрах в секунду
        /// </summary>
        public Byte WindSpeedMpS { get; set; }

        /// <summary>
        /// Температура в градусах по Фаренгейту
        /// </summary>
        public Double TemperatureF => 32 + TemperatureC / 0.5556;

        public string Summary => TemperatureC switch
        {
            <= -30 => "Freezing",
            <= -20 => "Bracing",
            <= -10 => "Chilly",
            <= 5 => "Cool",
            <= 10 => "Mild",
            <= 20 => "Warm",
            <= 30 => "Balmy",
            <= 35 => "Hot",
            _ => "Hell"

        };
    }
}
