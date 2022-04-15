using System;

namespace Aiva.Models
{
    /// <summary>
    /// Заказ.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Клиент.
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Дата размещения заказа.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Номер заказа.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Итоговая стоимость заказа.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Адрес доставки.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Промокод.
        /// </summary>
        public Promocode Promocode { get; set; }
    }
}