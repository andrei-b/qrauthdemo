using System;

namespace authx
{
    public class User
    {
        public String name { get; set; }
        public String passCode { get; set; }
        public String prefix { get; set; }
        public Boolean logged { get; set; }
        public int userId { get; set; }
    }
}

