using DataLayer;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlazorEmpty.GraphQl
{
    public class Queries
    {
        public IQueryable<Footballer> GetFootballers([Service] EFDBContext context) => context.Footballer.Include(f => f.Team);
        public IQueryable<Team> GetTeams([Service] EFDBContext context) => context.Team;
    }
}
