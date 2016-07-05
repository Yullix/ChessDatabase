using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDatabase.Models;

namespace ChessDatabase.Services
{
    public class GameService : IService
    {
        public event EventHandler Updated;
    }
}
