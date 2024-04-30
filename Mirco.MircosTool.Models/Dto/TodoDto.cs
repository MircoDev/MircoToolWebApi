using MircoToolWebApi.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirco.MircosTool.Models.Dto
{
    public record TodoDto
    {
      
        public required string Description { get; set; }

       
        public DateTime? DateExpiration { get; set; }

      
        public Priority? Priority { get; set; }

       
        public bool IsCompleted { get; set; }
    }
}
