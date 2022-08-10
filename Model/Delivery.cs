using System;

namespace hw_03.Model
{
    /// <summary>
    /// Базовый класс для класов реализующих логику доаставки
    /// </summary>
    internal abstract class Delivery
    {
        public Guid ID { get; set; }
        public string Address { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime DateOfRegistration { get; }
        public string RecipientName { get; set; }
        public string RecipientTel { get; set; }
        public abstract  DeliveryStatus Status { get; protected set; }

        public Delivery()
        {
            ID = Guid.NewGuid();
            DateOfRegistration = DateTime.Now;
        }

        public abstract string GetDeliveryStatusInfo();
        public abstract string GetDeliveryServiceInfo();
        public abstract string GetDeliveryInfo();

        public string GetRecipientInfo()
        {
            return $"Получатель: {RecipientName}.\nКонтактный тел: {RecipientTel}\nАдрес: {Address}";
        }
    }

    //internal class ff<T> where T : Delivery
    //{
        
    //}
    //internal class ddd
    //{
    //    public void fdf()
    //    {
    //        ff<HomeDelivery> hd = new();
    //    }
    //}

}
