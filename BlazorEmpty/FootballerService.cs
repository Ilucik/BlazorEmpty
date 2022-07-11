using BlazorEmpty.ViewModel;
using DataLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEmpty
{
    public class FootballerService
    {
        public FootballerService(DataManager dataManager, TeamService teamService)
        {
            DataManager = dataManager;
            TeamService = teamService;
        }

        private DataManager DataManager { get; }
        public TeamService TeamService { get; }

        public async Task<List<FootballerView>> GetFootballersAsync()
        {
            var data = await DataManager.Footballers.GetAllAsync();
            return await Task.FromResult(data.Select(e => DbToView(e)).ToList()); ;
        }

        public async Task<int> AddFootballersAsync(FootballerView footballer)
        {
            var id = await DataManager.Footballers.AddAsync(await ViewToDb(footballer));
            footballer.Id = id;
            return id;
        }

        public async Task RemoveAsync(int id)
        {
            await DataManager.Footballers.RemoveAsync(id);
        }

        public async Task UpdateAsync(FootballerView footballer)
        {
            await DataManager.Footballers.UpdateAsync(await ViewToDb(footballer));
        }

        public FootballerView DbToView(Footballer footballer)
        {
            return new FootballerView
            {
                Id = footballer.Id,
                Name = footballer.Name,
                Surname = footballer.Surname,
                Birthday = footballer.Birthday,
                Country = footballer.Country,
                Gender = footballer.Gender,
                TeamName = footballer.Team.Name
            };
        }

        public async Task<Footballer> ViewToDb(FootballerView footballer)
        {
            Footballer f = await DataManager.Footballers.GetByIdAsync(footballer.Id);
            if (f is null)
                f = new();
            Team team = (await TeamService.GetAsync(e => e.Name.Equals(footballer.TeamName))).FirstOrDefault();
            if (team is null)
                team = new Team() { Name = footballer.TeamName };
            f.Name = footballer.Name;
            f.Surname = footballer.Surname;
            f.Birthday = footballer.Birthday;
            f.Country = footballer.Country;
            f.Gender = footballer.Gender;
            f.Team = team;
            f.TeamId = team.Id;
            return f;
        }
    }
}
