using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
    [Serializable]
    public class Weather
    {
        public int id;
        public string main;
        public string description;
    }

    [Serializable]
    public class WeatherInfo
    {

        public int id;
        public string name;
        public List<Weather> weather;

    }
}
