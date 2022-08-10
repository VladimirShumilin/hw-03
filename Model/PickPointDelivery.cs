using System;


namespace hw_03.Model
{
    /// <summary>
    /// Класс реализует бизнеслогику доставки в постомат.
    /// логика работы из 4х шагов. 
    ///1 - принять в обработку  (AcceptedForProcessing)
    ///2 - передать в службу доставки или курьеру(SubmittedToTheDeliveryService)
    ///3 - зафиксировать укладку в ячейку постомата.(DeliveredToPickPoint)
    ///4 - завершить доставку успешно или отменить.(SuccessfullyDelivered,CancelDelivery)
    /// </summary>
    internal class PickPointDelivery : Delivery
    {
        public string PickPointCell { get; set; }
        public string PickPointCellPin { get; set; }
        public TimeSpan StorageTime { get; set; }
        public СouriersService СourierService { get; private set; }
        public override DeliveryStatus Status { get; protected set; }

        public PickPointDelivery(СouriersService courierService,  TimeSpan storageTime) : base()
        {
            СourierService = courierService;
            StorageTime = storageTime;
        }

        #region логика работы службы
        public bool AcceptedForProcessing()
        {
            //логика проверки корректности нового состояния 
            //если установить новый статус не возможно функция должна вернуть false
            //...

            //здесь логика первичного определения даты доставки и временного интервала
            //...


            Status = DeliveryStatus.Accepted;
            return true;
        }
        public bool SubmittedToTheDeliveryService(СouriersService newCourier)
        {
            //здесь логика проверки корректности нового состояния 
            //если установить новый статус не возможно функция должна вернуть false
            //...

            //здесь логика актуализауции даты доставки и временного интервала
            //...


            СourierService = newCourier;
            Status = DeliveryStatus.Shipped;
            return true;
        }
        public bool DeliveredToPickPoint(string pickPointCell,string pickPointCellPin)
        {
            //здесь логика проверки корректности нового состояния 
            //если установить новый статус не возможно функция должна вернуть false
            //...

            //здесь логика актуализауции даты доставки и временного интервала
            //...

            PickPointCell = pickPointCell;
            PickPointCellPin = pickPointCellPin;
            
            Status = DeliveryStatus.AwaitInPickPoint;
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
            if (СourierService == null)
                return $"Сервис доставки не задан";

            return $"Статус доставки: {DeliveryStatusInfo.StatusDict[Status]}.\nОжидаемая дата доставки:{DeliveryDate}.\nВремя хранения {StorageTime.Days} суток";
        }
        public override string GetDeliveryServiceInfo()
        {
            if (СourierService == null)
                return $"Сервис доставки не задан";

            return $"Достаку осуществляет: {СourierService.Name}. Контактный тел: {СourierService.Tel} ";
        }
        public override string GetDeliveryInfo()
        {
            return $"Дата создания:{DateOfRegistration:yyyy.MM.dd}\nДата доставки:{DeliveryDate:yyyy.MM.dd}";
        }
        #endregion
    }
}
