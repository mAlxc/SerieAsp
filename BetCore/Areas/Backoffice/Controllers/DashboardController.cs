using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetCore.Data;
using Microsoft.AspNetCore.Mvc;
using BetCore.Filters;

namespace BetCore.Areas.Backoffice.Controllers
{
    [AuthenticationBackofficeFilter]
    public class DashboardController : BackofficeControllerBase
    {
        public DashboardController(BetCoreDbContext context) : base(context)
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}