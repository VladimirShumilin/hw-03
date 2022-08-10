namespace hw_03.Model
{
    /// <summary>
    /// Класс реализует бизнеслогику доставки на дом курьером или курьерской службой.
    /// логика работы из 3х шагов. 
    ///1 - принять в обработку  (AcceptedForProcessing)
    ///2 - передать в службу доставки или курьеру(SubmittedToTheDeliveryService)
    ///3 - завершить доставку успешно или отменить.(SuccessfullyDelivered,CancelDelivery)
    /// </summary>
    internal class HomeDelivery : Delivery
    {
        /// <summary>
        /// Содержит временной интервал доставки . например 9:00 - 17:00
        /// </summary>
        public string DeliveryTime { get; set; }
        /// <summary>
        /// Коментарии к доставке для курьера, если такие есть.
        /// </summary>
        public string NotesForTheCourier { get; set; }
      
        public override DeliveryStatus Status { get; protected set; }
        public СouriersService СourierService { get; private set; }

        /// <summary>
        /// Конструктор с агрегацией объекта СourierService
        /// </summary>
        /// <param name="courierService"></param>
        public HomeDelivery(СouriersService courierService):base()
        {
            СourierService = courierService;
        }

        #region логика работы службы
        public bool AcceptedForProcessing()
        {
            //логика проверки корректности нового состояния 
            //если установить новый статус не возможно функция должна вернуть false
            //...

            //здесь логика первичного определения даты доставки и временного интервала
            //...


            Status =  DeliveryStatus.Accepted;
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

           return $"Статус доставки: {DeliveryStatusInfo.StatusDict[Status]}.\nОжидаемая дата доставки:{DeliveryDate}.\nИнтервал времени доставки {DeliveryTime}";
        }
        public override string GetDeliveryServiceInfo()
        {
            if (СourierService == null)
                return $"Сервис доставки не задан";

            return $"Достаку осуществляет: {СourierService.Name}. Контактный тел: {СourierService.Tel} ";
        }
        public override string GetDeliveryInfo()
        {
            return $"Дата создания:{DateOfRegistration:yyyy.MM.dd}\nДата доставки:{DeliveryDate:yyyy.MM.dd}\nВремя доставки:{DeliveryTime}";
        }
        #endregion
    }
}
 