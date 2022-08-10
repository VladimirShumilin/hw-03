using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_03.Model
{
    /// <summary>
    /// Класс представляет справочник  с описанием состояний  DeliveryStatus
    /// </summary>
    internal static class DeliveryStatusInfo
    {
        private static Dictionary<DeliveryStatus, string> statusDict;
        public static Dictionary<DeliveryStatus, string> StatusDict
        {
            get {
                if(statusDict == null)
                    statusDict = new Dictionary<DeliveryStatus,string>();

                return statusDict;
            }
        }

        static DeliveryStatusInfo()
        {
            StatusDict[DeliveryStatus.Uncknow] = "Не установлен";
            StatusDict[DeliveryStatus.Accepted] = "Принят в доставку";
            StatusDict[DeliveryStatus.Shipped] = "В пути";
            StatusDict[DeliveryStatus.AwaitInPickPoint] = "Ожидает в постамате";
            StatusDict[DeliveryStatus.Delivered] = "Доставлен";
            StatusDict[DeliveryStatus.Canceled] = "Отменен";
        }
    }
}
