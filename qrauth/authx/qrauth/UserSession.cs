using System;
using System.Configuration;
using System.Linq;

namespace qrauth
{
    public class UserSession
    {
        public UserSession()
        {
            userSessionId = 0;
            userId = 0;
            timestamp = DateTime.Today;
        }
        public UserSession(int sid)
        {
            userSessionId = sid;
            userId = 0;
            timestamp = DateTime.Now;
        }
        public bool isUsed()
        {
            return userId != 0;
        }
        public bool isTimedOut()
        {
            return (DateTime.Now - timestamp).Seconds < Convert.ToInt32(ConfigurationManager.AppSettings.Get("LoginTimeout"));
        }
        public bool isUserTimedOut()
        {
            return (DateTime.Now - timestamp).Seconds < Convert.ToInt32(ConfigurationManager.AppSettings.Get("UserTimeout"));
        }
        public void resetTime()
        {
            timestamp = DateTime.Now;
        }
        public void addUser(int uid)
        {
            userId = uid;
            resetTime();
        }
        public int userSessionId { get; set; }
        public int userId { get; set; }
        public DateTime timestamp { get; set; }
    }
    
}