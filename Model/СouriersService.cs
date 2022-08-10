using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_03.Model
{
    /// <summary>
    /// класс СouriersService описывает курьера или курьерскую службу
    /// </summary>
    internal class СouriersService
    {
        public string Name { get; set; }
        public string Tel { get; set; }
        public string Transport { get; set; }
        public double Price { get; set; }
        public СouriersServiceType Type { get;  }
        /*другие поля описывающие объект ...*/


        public СouriersService(СouriersServiceType type)
        {
            Type = type;
        }
    }
}
