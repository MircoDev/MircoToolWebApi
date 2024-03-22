using MircoToolWebApi.Enums;

namespace MircoToolWebApi.Entities
{
    public class ToDo : BaseEntity
    {
        
        public required string Description { get; set; }

        public DateTime? DateExpiration { get; set; }

        public EnumPriority Priority { get; set; }

        public bool Completed { get; set; }

    }
}
