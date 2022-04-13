namespace Aiva.Models
{
    /// <summary>
    /// Блюдо.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Кухня.
        /// </summary>
        public Kitchen Kitchen { get; set; }

        /// <summary>
        /// Стоимость.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Название изображения.
        /// </summary>
        public string ImageName { get; set; }
    }
}