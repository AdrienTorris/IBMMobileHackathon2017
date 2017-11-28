using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM.Books.Identity.API.Infrastructure.Helpers
{
    public static class UserHelper
    {
        public static bool CheckUsernamePolicy(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return false;

            if (!username.Contains('@') || !username.Contains('.'))
                return false;

            string[] arr = username.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            string[] arr2 = arr[1].Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

            bool ret = false;
            foreach (string s in arr2)
            {
                if (ret)
                    continue;

                if (s.ToLower().Trim() == "ibm")
                    ret = true;
            }

            arr = null;
            arr2 = null;

            return ret;
        }
    }
}