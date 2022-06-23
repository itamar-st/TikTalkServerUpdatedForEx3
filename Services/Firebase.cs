using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    // push notification with firebase
    public class Firebase
    {
        // user and his token
        public static Dictionary<string,string> usersDict = new Dictionary<string,string>();
        //add user and token to the dict
        public static void Add(string user, string token) {
            if (!usersDict.ContainsKey(user))
            {
                usersDict.Add(user, token);
            }
            usersDict[user] = token;
         }
        //get user's token
        public static string Get(string user) { 
            if(!usersDict.ContainsKey(user))
            {
                return null;
            }
            return usersDict[user]; 
        }
    }
}
