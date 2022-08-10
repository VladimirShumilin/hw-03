using hw_03.Model;
using System;

namespace hw_03
{
    class Program
    {
        static void Main(string[] args)
        {
            #region  заказ с доставкой на дом курьером
            Order<HomeDelivery> hm = new() { Description="Доставка на дом" };
            //определить список товаров
            hm.AddProduct(new Product("12345678901234", "Product 1", "", 20.2d, 1));
            hm.AddProduct(new Product("12345678901231", "Product 2", "", 20.2d, 1));
            hm.AddProduct(new Product("12345678901234", "Product 1", "", 20.2d, 1));

            //определить курьерскую службу
            СouriersService cs = new (СouriersServiceType.Courier) { Name = "Иваныч", Tel = "+79161092343", Transport = "Иваныч мобиль", Price = 10.4d };

            //определить параметры доставки
            HomeDelivery hd = new(cs) { Address="Moskow, Lenin str, d 98", NotesForTheCourier="c 10 до 17", RecipientName ="Наташа",
                RecipientTel="+71921920019", DeliveryTime= "14 - 17", DeliveryDate = DateTime.Today.AddDays(2)};

            //связать доставку с заказом
            hm.ChangeDelivery(hd);

            //выполнить первый этап - передача заказа в работу
            hd.AcceptedForProcessing();

            //вывести информацию по заказу
            Console.WriteLine(hm.GetOrderInfo());
            #endregion

            #region  заказ с доставкой в PickPoint
            Order<PickPointDelivery> pp = new() { Description = "доставка в PickPoint" };
            //определить список товаров
            pp.AddProduct(new Product("12345678901234", "Product 1", "", 20.2d, 1));
            pp.AddProduct(new Product("12345678901231", "Product 2", "", 20.2d, 1));
            pp.AddProduct(new Product("12345678901234", "Product 1", "", 20.2d, 1));

          
            //определить параметры доставки
            PickPointDelivery pd = new(cs, TimeSpan.FromDays(3))
            {
                Address = "Moskow, Lenin str, d 98",
                RecipientName = "Наташа",
                RecipientTel = "+71921920019",
                DeliveryDate = DateTime.Today.AddDays(2),
            };

            //связать доставку с заказом
            pp.ChangeDelivery(pd);

            //доставить заказ в постомат
            pd.DeliveredToPickPoint("С01", "1241214");

            //вывести информацию по заказу
            Console.WriteLine(pp.GetOrderInfo());
            #endregion

            #region  заказ с доставкой в магазин
            Order<ShopDelivery> ss = new() { Description = "доставка в магазин" };
            //определить список товаров
            ss.AddProduct(new Product("12345678901234", "Product 1", "", 20.2d, 1));
            ss.AddProduct(new Product("12345678901231", "Product 2", "", 20.2d, 1));
            ss.AddProduct(new Product("12345678901234", "Product 1", "", 20.2d, 1));


            //определить параметры доставки
            ShopDelivery sd = new(DateTime.Now.AddDays(2))
            {
                Address = "Moskow, Lenin str, d 98",
                RecipientName = "Наташа",
                RecipientTel = "+71921920019",
                DeliveryDate = DateTime.Today.AddDays(2),
            };

            //связать доставку с заказом
            ss.ChangeDelivery(sd);

            //отшрузить заказ с склада
            sd.Shipped("Иваныч", "+79161092343");

            //вывести информацию по заказу
            Console.WriteLine(ss.GetOrderInfo());
            #endregion
        }
    }
}
