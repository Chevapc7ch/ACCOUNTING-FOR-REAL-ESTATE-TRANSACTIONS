using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RieltorsAPP.Entities
{
    public partial class Apartments
    {
        public  string NameObject
        {
            get
            {               
                var name = "";
                if (Floor == null)
                {
                    return name = $"{House}, {Quadrature}";
                }
                else
                {
                    return name = $"{House}, {Quadrature} m\u00B2, {Floor}";
                }                
            }
        }

        public string MoneySum
        {
            get
            {
                var money = Price;
                string mony = "";

                if (money < 1_000_000)
                {
                   mony = Price.ToString("N2") + " ₽ в месяц";
                }
                if (money >= 1_000_000)
                {
                   mony = Price.ToString("N2") + " ₽";
                }

                return mony;
            }
        }
    }
}
