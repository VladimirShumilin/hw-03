namespace hw_03.Model
{
    /// <summary>
    /// Статусы доступные для класов производных от Delivery описывающих логику доставки .
    /// </summary>
    internal enum DeliveryStatus
    {
        Uncknow,
        Accepted,
        Shipped,
        AwaitInPickPoint,
        Delivered,
        Canceled
    }
}
