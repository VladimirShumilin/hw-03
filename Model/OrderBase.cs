
namespace hw_03.Model
{
    /// <summary>
    /// Базовый класс для всех типов класса Order
    /// обеспечивает уникальность номера нового созданного объекта
    /// </summary>
    internal class OrderBase
    {
        public static int OrderNum { get; private set; }
        protected static int CreateNewNumber()
        {
            //здесь логика создания нового номера
            //...
            return ++OrderNum;
        }
    }
}
