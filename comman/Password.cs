using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schoolmanagementn.comman
{
    public class Password
    {
        public string Encode(string Password)
        {
            try
            {
                byte[] encoded = System.Text.Encoding.UTF8.GetBytes(Password);
                return Convert.ToBase64String(encoded);
            }
            catch (Exception) { return null; }  
        }
        public string Decode(string Password)
        {
            byte[] decoded = Convert.FromBase64String(Password);

            return System.Text.Encoding.UTF8.GetString(decoded);


        }
        public string decodestring(string Password)
        {
            byte[] decodeStrin = Convert.FromBase64String(Password);
            return System.Text.Encoding.ASCII.GetString(decodeStrin);
        }
       /* var decodedstring = window.btoa(encodedstring);
        document.getElementById("password").value = decodedstring;
*/

    }
}
