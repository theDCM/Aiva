namespace Aiva.Models
{
    /// <summary>
    /// Статус заказа.
    /// </summary>
    public enum OrderState
    {
        /// <summary>
        /// Создан.
        /// </summary>
        Created = 0,

        /// <summary>
        /// Принят.
        /// </summary>
        Confirmed = 1,

        /// <summary>
        /// В работе.
        /// </summary>
        Started = 2,

        /// <summary>
        /// Готов.
        /// </summary>
        Finished = 3
    }
}
