using System;
using System.Collections.Generic;

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
        /// Дата подтвержения заказа.
        /// </summary>
        public DateTime ConfirmedAt { get; set; }

        /// <summary>
        /// Дата принятия заказа в работу.
        /// </summary>
        public DateTime StartedAt { get; set; }

        /// <summary>
        /// Дата завершения заказа.
        /// </summary>
        public DateTime FinishedAt { get; set; }

        /// <summary>
        /// Статус заказа.
        /// </summary>
        public OrderState State { get; set; }

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
        /// Повара на заказе.
        /// </summary>
        public ICollection<Cook> Cooks { get; set; }
    }
}