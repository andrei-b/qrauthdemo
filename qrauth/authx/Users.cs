using System;
using LiteDB;

namespace authx
{
    public class Users : IDisposable
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
        public Users()
        {
            db = new LiteDatabase(@"auhx.db");
        }

        public LiteCollection<User> items()
        {
            return db.GetCollection<User>("users");
        }

        public void insert(User user)
        {
            items().Insert(user);
        }

        public Boolean isLoggedIn(int id)
        {
            return false;
        }
        // Create your new customer instance
        //          var customer = new Customer
        //          {
        //              Name = "John Doe",
        //              Phones = new string[] { "8000-0000", "9000-0000" },
        //              IsActive = true
        //          };
        //     }
        //}
    }
}
