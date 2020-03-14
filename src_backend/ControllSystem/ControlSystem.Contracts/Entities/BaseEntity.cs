using System.ComponentModel.DataAnnotations.Schema;

namespace ControlSystem.Contracts.Entities
{
    public abstract class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
    }
}
