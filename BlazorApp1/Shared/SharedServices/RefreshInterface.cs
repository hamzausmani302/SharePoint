using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.SharedServices
{
    public interface RefreshInterface
    {
        event Action RefreshRequested;
        void CallRequestRefresh(User user);
        void CallRequestRefresh2();
    }
}
