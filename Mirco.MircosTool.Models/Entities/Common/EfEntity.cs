using System.ComponentModel.DataAnnotations.Schema;

namespace Mirco.MircosTool.Models.Entities.Base
{
    public class EfEntity
    {
        public int Id { get; set; }
        [Column("DateCreated")]
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [Column("DateUpdated")]
        public DateTime? DateUpdated { get; set; }
    }
}
