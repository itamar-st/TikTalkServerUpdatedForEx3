using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Firebase
    {
        public static Dictionary<string,string> usersDict = new Dictionary<string,string>();

        public static void Add(string user, string token) { usersDict.Add(user, token); }
        public static string Get(string user) { 
            if(!usersDict.ContainsKey(user))
            {
                return null;
            }
            return usersDict[user]; 
        }
    }
}
