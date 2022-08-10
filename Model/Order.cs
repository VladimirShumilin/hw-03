using System;
using System.Linq;


namespace hw_03.Model
{
    /// <summary>
    /// Класс реализует логику работы с заказом
    /// </summary>
    /// <typeparam name="TDelivery"></typeparam>
    internal class Order<TDelivery>: OrderBase where TDelivery : Delivery
    {
        //отношения типа аггрегация 
        private TDelivery Delivery;

        public int Number { get; }
        public string Description { get; set; }

        public Order()
        {
            Number = CreateNewNumber();
        }

        //инкапсулирование  объекта Products с типом отношений композиция
        private readonly ProductCollection products = new();

        public TDelivery GetDelivery() => Delivery;
        public void ChangeDelivery<T>(T newDelivery) where T : TDelivery
        {
            Delivery = newDelivery;
        }

        public Product[] GetProducts() => products?.ToArray();
        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }
        public void AddProduct(Product p)
        {
            if (products.FirstOrDefault(x => x == p) is Product product)
                product.Count += p.Count;
            else
                products.Add(p);
        }
        public string GetDeliveryStatus() => Delivery?.GetDeliveryStatusInfo();
        public string GetDeliveryInfo() => Delivery?.GetDeliveryServiceInfo();
        public string GetOrderInfo()
        {
            return $" Заказ №:{Number}\n{Description}\n{Delivery.GetDeliveryStatusInfo()}\nСостав:\n" +
                $"{products.GetProductsInfo()}{Delivery.GetRecipientInfo()}\n" +
                $"{Delivery.GetDeliveryInfo()}\n\n";
        }
     
       
    }
}
