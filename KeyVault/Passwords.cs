using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyVault
{
    class Passwords
    {
        public static int max_title = 8;
        public static int max_login=5;
        public static int max_passwords=6;
        public static int max_site=5;
        public static int max_comment=11;
        public string title;
        public string login;
        public string passwords;
        public string site;
        public string comment;
        public int pass_code;
        public Passwords
            (
            string title,
            string login,
            string passwords,
            string site,
            string comment
            ) 
        {
            this.title = title;
            this.login = login;
            this.passwords = passwords;
            this.site = site;
            this.comment = comment;
            this.pass_code = (title + login + passwords + site + comment).GetHashCode();

            max_title = max_title > title.Length ? max_title : title.Length;
            max_login = max_login > login.Length ? max_login : login.Length;
            max_passwords = max_passwords > passwords.Length ? max_passwords : passwords.Length;
            max_site = max_site > site.Length ? max_site : site.Length;
            max_comment = max_comment > comment.Length ? max_comment : comment.Length;

        }
        public override string ToString()
        {
            return this.title;
        }

    }
}
