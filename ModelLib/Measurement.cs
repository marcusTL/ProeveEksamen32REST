using System;

namespace ModelLib
{
    public class Measurement
    {
        private int _id;
        private int _pressure;
        private int _humidity;
        private int _temperature;
        private DateTime _timestamp;

        public Measurement(int id, int pressure, int humidity, int temperature, DateTime timestamp)
        {
            Id = id;
            Pressure = pressure;
            Humidity = humidity;
            Temperature = temperature;
            Timestamp = timestamp;
        }
        public Measurement()
        {
        }
        public int Id
        {
            get => _id;
            set => _id = value;
        }
        public int Pressure
        {
            get => _pressure;
            set => _pressure = value;
        }
        public int Humidity
        {
            get => _humidity;
            set => _humidity = value;
        }
        public int Temperature
        {
            get => _temperature;
            set => _temperature = value;
        }
        public DateTime Timestamp
        {
            get => _timestamp;
            set => _timestamp = value;
        }

        public override string ToString()
        {
            return $"{_id},{_pressure},{_humidity},{_temperature},{_timestamp}";
        }
    }
}
