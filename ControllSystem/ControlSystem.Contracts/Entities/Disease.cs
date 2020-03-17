using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlSystem.Contracts.Entities
{
    [Table("Diseases")]
    public class Disease : BaseEntity
    {
        [Column("disease_name")]
        public string DiseaseName { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<User> Users { get; set; }
    }
}
