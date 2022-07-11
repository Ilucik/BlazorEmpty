using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer
{
    public class EFFootballerRepository : EFRepository<Footballer>
    {
        private readonly EFDBContext context;

        public EFFootballerRepository(EFDBContext context):base(context)
        {
            this.context = context;
        }

        public override async Task<List<Footballer>> GetAsync(Func<Footballer, bool> selector)
        {
            return await Task.Run(()=>context.Footballer.Include(f => f.Team).Where(selector).ToList());
        }

        public override async Task<List<Footballer>> GetAllAsync()
        {
            return await context.Footballer.Include(f => f.Team).ToListAsync();
        }

        public override async Task<Footballer> GetByIdAsync(int id)
        {
            return await context.Footballer.Include(f => f.Team).FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
