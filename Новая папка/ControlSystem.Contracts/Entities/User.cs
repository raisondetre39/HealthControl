using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlSystem.Contracts.Entities
{
    [Table("Users")]
    public class User : BaseEntity
    {
        [Column("email")]
        public string Email { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("password")]
        [JsonIgnore]
        public string Password { get; set; }

        [JsonIgnore]
        public virtual Device Device { get; set; }

        [Column("device_id")]
        public int? DeviceId { get; set; }

        public virtual Disease Disease { get; set; }

        [Column("disease_id")]
        public int? DiseaseId { get; set; }

        [Column("role")]
        public int Role { get; set; }
    }
}
