using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LiteDB;

namespace authx
{
    public class Seances : IDisposable
    {
        LiteDatabase db = null;
        public void Dispose()
        {
            if (db != null)
            {
                db.Dispose();
                db = null;
            }
        }
        public Seances()
        {
            db = new LiteDatabase(@"auhx.db");
        }
        public LiteCollection<Seance> items()
        {
            return db.GetCollection<Seance>("seances");
        }
        public Seance newSeance()
        {
             Seance s = new Seance
            {
                code = "abc",
                userId = 0,
            };
            items().Insert(s);
            return s;
        }
        public Seance seanceByCode(String code)
        {
            var results = items().Find(x => x.code.Equals(code));
            if (results == null)
                return null;
            if (results.Count() == 0)
                return null;
            return results.First();
        }
    }
}