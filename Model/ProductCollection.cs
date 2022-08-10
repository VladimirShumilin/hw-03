using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hw_03.Model
{
    /// <summary>
    /// Класс реализует методы работы с масивом объектов Product
    /// </summary>
    class ProductCollection : List<Product>
    {
        public new void Add(Product item)
        {
            if (!string.IsNullOrEmpty(item.SerialNumber))
            {
                //запретить добавлять элемент если он не уникальный
                if (this.FirstOrDefault(x => x.SerialNumber == item.SerialNumber) != default)
                    throw new ArgumentException("Серийный номер уже существует");
            }

            base.Add(item);
        }
        /// <summary>
        ///  индексатор
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        public Product this[string serialNumber]
        {
            get
            {
                return this.FirstOrDefault(x => x.SerialNumber == serialNumber);
            }
            set
            {
                if (this.FirstOrDefault(x => x.SerialNumber == serialNumber) is not Product p)
                    throw new ArgumentException("Серийный номер не существует");

                p = value;

            }
        }

        public string GetProductsInfo()
        {
            StringBuilder sb = new();

            foreach (Product p in this)
                sb.Append($"{p.GetEan13()};{p.Name};{p.SerialNumber};{(p.Price*p.Count)}\n");

            return sb.ToString();
        }
    }

}
