using System;

namespace hw_03.Model
{

    /// <summary>
    /// Класс реализует бизнеслогику доставки в розничный магазин машинами компании.
    /// логика работы из 3х шагов. 
    /// 1 - запланировать доставку на определенное число (указывается в конструкторе при создании объекта)
    /// 2 - назначить машину и водителя (Shipped)
    /// 3 - завершить или отменить доставку.(SuccessfullyDelivered,CancelDelivery)
    /// </summary>
    internal class ShopDelivery : Delivery
    {
        public string CarNumber { get; set; }
        public string DriverTel { get; set; }
        public override DeliveryStatus Status { get; protected set; }

        public ShopDelivery(DateTime deliveryDate) : base()
        {
            DeliveryDate = deliveryDate;
            Status = DeliveryStatus.Accepted;
        }

        #region логика работы 
        public bool Shipped(string carNumber, string driverTel)
        {
            //здесь логика проверки корректности нового состояния 
            //если установить новый статус не возможно функция должна вернуть false
            //...

            //здесь логика актуализауции даты доставки и временного интервала
            //...

            DriverTel = driverTel;
            CarNumber = carNumber;
            Status = DeliveryStatus.Shipped;
            return true;
        }
        public bool SuccessfullyDelivered()
        {
            //логика проверки корректности нового состояния 
            //если установить новый статус не возможно функция должна вернуть false
            //...

            Status = DeliveryStatus.Delivered;
            return true;
        }
        public bool CancelDelivery()
        {
            //логика проверки корректности нового состояния 
            //если установить новый статус не возможно функция должна вернуть false
            //...

            Status = DeliveryStatus.Canceled;
            return true;
        }
        #endregion

        #region переопределяемые методы
        public override string GetDeliveryStatusInfo()
        {
            return $"Статус доставки: {DeliveryStatusInfo.StatusDict[Status]}.\nОжидаемая дата доставки:{DeliveryDate}.  ";
        }
        public override string GetDeliveryServiceInfo()
        {
            if (string.IsNullOrEmpty(CarNumber))
                return $"Машина доставки не задана";

            return $"Достаку осуществляет машина: {CarNumber}. Контактный телефон водителя: {DriverTel} ";
        }
        public override string GetDeliveryInfo()
        {
            return $"Дата создания:{DateOfRegistration:yyyy.MM.dd}\nДата доставки:{DeliveryDate:yyyy.MM.dd}";
        }
        #endregion
    }
}
