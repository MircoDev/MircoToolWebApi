using Mirco.MircosTool.Models.Entities.Base;
using MircoToolWebApi.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Mirco.MircosTool.Models.Entities.todo
{
    [Table("TODO")]
    public class ToDo : EfEntity
    {
        [Required]
        [Column("Description")]
        public required string Description { get; set; }

        [Column("DateExpiration")]
        public DateTime? DateExpiration { get; set; }

        [Column("Priority")]
        public Priority? Priority { get; set; }

        [Column("IsCompleted")]
        public bool IsCompleted { get; set; }


    }
}
