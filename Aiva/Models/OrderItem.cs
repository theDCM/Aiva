namespace Aiva.Models
{
    /// <summary>
    /// Элементы заказа.
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Заказ.
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// Блюдо.
        /// </summary>
        public Item Item { get; set; }

        /// <summary>
        /// Количество таких блюд в заказе.
        /// </summary>
        public int Count { get; set; }
    }
}