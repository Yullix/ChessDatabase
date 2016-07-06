using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ted Torkkeli
// 2016-07-05

namespace ChessDatabase.Models
{
    /// <summary>
    /// Singleton instance of the database context.
    /// </summary>
    class ContextSingleton
    {
        static ChessDatabaseContext context;

        /// <summary>
        /// returns the database context instance.
        /// </summary>
        /// <returns></returns>
        public static ChessDatabaseContext GetContext()
        {
            if (context == null)
                context = new ChessDatabaseContext();

            return context;
        }
    }
}
