using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestBackend.Data
{
    /// <summary> запрос </summary>
    public class Request
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid Id { get; set; }

        /// <summary> Id запроса </summary>
        public Guid Query { get; set; }

        /// <summary> дата время запроса </summary>
        public DateTime Data { get; set; }
    }

}
