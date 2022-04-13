namespace Aiva.Models
{
    /// <summary>
    /// Промокод.
    /// </summary>
    public class Promocode
    {
        /// <summary>
        /// Идентификатор.
        /// </summary
        public int Id { get; set; }

        /// <summary>
        /// Активен ли примокод.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Промокод.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Сумма скидки.
        /// </summary>
        public decimal DiscountSum { get; set; }
    }
}