using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ted Torkkeli
// 2016-07-05

namespace ChessDatabase.Services
{
    public class OnUpdatedEventArgs : EventArgs
    {
        public string updateMessage { get; set; }
        public int entityId { get; set; }
    }

    public interface IService
    {
        event EventHandler Updated;
    }
}
