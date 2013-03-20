using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using DotNetStandard.HashGenerators;
using Heracles.Intefaces;
using DotNetStandard.Cache;

namespace Heracles
{
    public class MembershipWrapper : IMembership
    {
        public bool ValidateUser(string username, string password)
        {
            return Membership.ValidateUser(username, password);
        }

        public string CreateToken(bool addToCache)
        {
            string tokenValue = HashGenerator.GetRandomHash();

            if (addToCache)
            {
                TokenCacheStrategy.Instance.Insert(tokenValue);
            }

            return tokenValue;
        }

        public string AddObjectToCache(object item)
        {
            string tokenValue = HashGenerator.GetRandomHash();

            TokenCacheStrategy.Instance.Insert(tokenValue, item);

            return tokenValue;
        }

        public object GetObjectFromCache(string key)
        {
            return TokenCacheStrategy.Instance.GetCachedObject(key);
        }

        public void RemoveTokenFromCache(string token)
        {
            TokenCacheStrategy.Instance.Delete(token);
        }
    }
}
