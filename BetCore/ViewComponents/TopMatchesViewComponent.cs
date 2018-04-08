using BetCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetCore.ViewComponents
{
    public class TopMatchesViewComponent : ViewComponent
    {
        private BetCoreDbContext context;

        public TopMatchesViewComponent(BetCoreDbContext context)
        {
            this.context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var matches = await context.Match.Where(x => !x.Deleted)
                                    .OrderBy(x => x.ID)
                                    .Take(5).ToListAsync();
            return View("_TopMatches", matches);

        }
    }
}
