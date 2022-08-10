using hw_03.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_03
{
    internal static class ProductExtensions
    {
        public static string GetEan13(this Product p)
        {
            if (string.IsNullOrEmpty(p.Gtin))
                return "";

            if (p.Gtin.Length != 14)
                return "";

            return p.Gtin[1..];
        }
    }
}
