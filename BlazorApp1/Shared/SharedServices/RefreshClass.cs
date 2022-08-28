using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.SharedServices
{
    public class RefreshClass : RefreshInterface
    {
        public event Action? RefreshRequested;
        public void CallRequestRefresh(User user)
        {
            RefreshRequested?.Invoke();
        }

        public void CallRequestRefresh2()
        {
            RefreshRequested?.Invoke();
        }
    }
}
