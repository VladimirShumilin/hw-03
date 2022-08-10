using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_03.Model
{
    /// <summary>
    /// Класс представляет объект продукт.
    /// операторы == и != переопределены так что 
    /// уникальным продуктом считается только те у которых различаются
    /// поля Gtin , Name или SerialNumber
    /// </summary>
    internal class Product
    {
        public string Gtin { get; }
        public string Name { get; set; } = "";
        public string SerialNumber { get; set; } = "";
        public double Price { get; set; }
        public int Count { get; set; }

        public Product(string gtin, string name, string serialNumber, double price, int count)
        {
            if (string.IsNullOrEmpty(gtin))
                throw new ArgumentException("Gtin не указан");

            if (gtin.Length != 14)
                throw new ArgumentException("Gtin указан неверно");

            Gtin = gtin;
            Name = name;
            SerialNumber = serialNumber;
            Price = price;
            Count = count;
        }

        #region Переопределение операторов
        public static bool operator == (Product obj1, Product obj2)
        {
            if (ReferenceEquals(obj1, obj2))
                return true;
            if (obj1 is null)
                return false;
            if (obj2 is null)
                return false;

            return obj1.Equals(obj2);
        }
        public static bool operator != (Product obj1, Product obj2)
        {
            return !(obj1 == obj2);
        }
        #endregion

        public bool Equals(Product other)
        {
            if (other is null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Gtin.Equals(other.Gtin)
                   && Name.Equals(other.Name)
                   && SerialNumber.Equals(other.SerialNumber);
        }
        public override bool Equals(object obj) => Equals(obj as Product);
        public override int GetHashCode()
        {
            return HashCode.Combine(Gtin, Name, SerialNumber);
        }
    } 
}
