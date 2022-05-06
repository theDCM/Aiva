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
        New = 0,

        /// <summary>
        /// Принят.
        /// </summary>
        Accepted = 1,

        /// <summary>
        /// В работе.
        /// </summary>
        InWork = 2,

        /// <summary>
        /// Готов.
        /// </summary>
        Done = 3
    }
}
