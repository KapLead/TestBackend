using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestBackend.Data
{
    /// <summary> Пользователь </summary>
    public class User
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid Id { get; set; }

        /// <summary> Кол-во входов </summary>
        public long CountSignIn { get; set; }
    }
}
