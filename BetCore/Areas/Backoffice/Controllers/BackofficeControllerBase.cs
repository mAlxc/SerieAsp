using BetCore.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetCore.Areas.Backoffice.Controllers
{
    [Area("Backoffice")]
    public abstract class BackofficeControllerBase : Controller
    {
        protected readonly BetCoreDbContext _context;
        public BackofficeControllerBase(BetCoreDbContext context)
        {
            _context = context;
        }
    }
}
