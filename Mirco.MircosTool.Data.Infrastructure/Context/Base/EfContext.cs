using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mirco.MircosTool.Data.Infrastructure.Context.Base
{
    public abstract class EfContext<TContext> : DbContext
      where TContext : DbContext
    {
        internal readonly ILogger<TContext> _logger;

        protected EfContext(
            DbContextOptions<TContext> options,
            ILogger<TContext> logger
        )
            : base(options)
        {
            _logger = logger;
        }

        
       
       
    }
}
