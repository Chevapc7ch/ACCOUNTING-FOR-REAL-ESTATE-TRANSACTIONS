using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RieltorsAPP.Data
{
    internal class DataUser
    {
        public static string Login { get; set; }
        public static byte IdRole { get; set; } 

        public static byte AdUser { get; set;}
        // если = 1 это прожата регистрация, если два то добавление пользователя
    }
}
