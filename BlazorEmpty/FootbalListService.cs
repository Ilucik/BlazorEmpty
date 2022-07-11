using BlazorEmpty.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEmpty
{
    public class FootbalListService
    {
        public FootbalListService()
        {
            FootballersList = new List<FootballerView>();
        }
        public List<FootballerView> FootballersList {get;}

        public void Add(FootballerView f)
        {
            FootballersList.Add(f);
            UpdateEvent?.Invoke();
        }

        public void Remove(FootballerView f)
        {
            FootballersList.Remove(f);
            UpdateEvent?.Invoke();
        }

        public void Update()
        {
            UpdateEvent?.Invoke();
        }

        public event Func<Task> UpdateEvent;
    }
}
