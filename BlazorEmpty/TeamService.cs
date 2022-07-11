using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEmpty
{
    public class TeamService
    {
        public TeamService(DataManager dataManager)
        {
            DataManager = dataManager;
        }

        private DataManager DataManager { get; }

        public async Task<List<Team>> GetTeamsAsync()
        {
            return await DataManager.Teams.GetAllAsync();
        }

        public async Task<List<Team>> GetAsync(Func<Team, bool> selector)
        {
            return await DataManager.Teams.GetAsync(selector);
        }
    }
}
