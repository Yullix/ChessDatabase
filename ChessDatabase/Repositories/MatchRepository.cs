﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDatabase.Models;

namespace ChessDatabase.Repositories
{
    public class MatchRepository : IRepository<Match, int>
    {
        private ChessDatabaseContext context;

        public MatchRepository(ChessDatabaseContext ctx)
        {
            this.context = ctx;
        }

        public void Add(Match item)
        {
            context.Matches.Add(item);
            context.SaveChanges();
        }

        public IEnumerable<Match> All()
        {
            return context.Matches.ToList();
        }

        public IEnumerable<Match> ByFunc(Func<Match, bool> function)
        {
            return context.Matches.Where(function).ToList();
        }

        public void Edit(Match item)
        {
            context.Entry(item).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public Match Find(int ID)
        {
            return context.Matches.FirstOrDefault(m => m.Id.Equals(ID));
        }

        public bool Remove(int ID)
        {
            Match removeMatch = Find(ID);

            if (removeMatch != null)
            {
                context.Matches.Remove(removeMatch);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Ply> GetPlies(int _matchId)
        {
            return context.Plies.Where(p => p.gameId.Equals(_matchId));
        }
    }
}
