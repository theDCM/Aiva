namespace Aiva.Models
{
    /// <summary>
    /// Сохранённые адреса клиента.
    /// </summary>
    public class ClientAddress
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
        /// Адрес доставки.
        /// </summary>
        public string Address { get; set; }
    }
}