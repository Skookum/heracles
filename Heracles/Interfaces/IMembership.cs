using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Heracles.Intefaces
{
    public interface IMembership
    {
        bool ValidateUser(string username, string password);
        string CreateToken(bool addToCache);
        string AddObjectToCache(object item);
        object GetObjectFromCache(string key);
        void RemoveTokenFromCache(string token);
    }
}
