using WeatherForcast.Models;

namespace WeatherForcast.Sources
{
    /// <summary>
    /// Хранилище для записей о погоде
    /// </summary>
    public class WeatherDB
    {
        private List<WeatherRecord> _records;

        #region Конструкторы
        public WeatherDB()
        {
            _records = new List<WeatherRecord>();
        }
        #endregion

        private WeatherRecord GetRecordByDate(DateTime date)
        {
            foreach (WeatherRecord record in _records) 
            {
                if (record.Date == date) return record;
            }
            return null;
        }


        /// <summary>
        /// Возвращает все записи о погоде из диапазона дат
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        public List<WeatherRecord> Get(DateTime dateFrom, DateTime dateTo)
        { 
            return _records.FindAll(item => item.Date>=dateFrom && item.Date<=dateTo);
        }

        /// <summary>
        /// Добавление записи, если такой еще нет
        /// </summary>
        /// <param name="date">Дата наблюдения погоды</param>
        /// <param name="temperatureC">Температура в градусах Цельсия</param>
        /// <param name="windSpeed">Скорость ветра в м/с</param>
        /// <returns>Истина, если удалось доьавить запись, ЛОЖЬ - если место уже занято</returns>
        public bool AddRecord(DateTime date, int temperatureC, byte windSpeed)
        { 
            WeatherRecord record = GetRecordByDate(date);
            if (record == null)
            {
                _records.Add(new WeatherRecord() { Date = date, TemperatureC = temperatureC, WindSpeedMpS = windSpeed });
                return true;
            }
            else
            { 
                return false;
            }
        }

        /// <summary>
        /// Изменение записи
        /// </summary>
        /// <param name="date">Дата наблюдения погоды</param>
        /// <param name="temperatureC">Температура в градусах Цельсия</param>
        /// <param name="windSpeed">Скорость ветра в м/с</param>
        /// <returns>Истина, если удалось обновить запись, ЛОЖЬ - если запись за такую дату отсутствует</returns>
        public bool EditRecord(DateTime date, int temperatureC, byte windSpeed)
        {
            WeatherRecord record = GetRecordByDate(date);
            if (record != null)
            {
                record.TemperatureC = temperatureC;
                record.WindSpeedMpS = windSpeed;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="date">Дата записи о погоде</param>
        /// <returns>Истина, если удалось удалить запись, ЛОЖЬ - если запись за такую дату отсутствует</returns>
        public bool DeleteRecord(DateTime date)
        {
            WeatherRecord record = GetRecordByDate(date);
            if (record != null)
            {
                _records.Remove(record);
                return true;
            }
            else 
            {
                return false;
            }
        }




    }
}
