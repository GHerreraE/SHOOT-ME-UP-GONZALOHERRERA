using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compte_Bancaire
{
    public class Account
    {
        private int _Amount;
        private int _Pin;
        private string _Owner;

        public Account (int amount, int pin, string owner)
        {
            _Amount = amount;
            _Pin = pin;
            _Owner = owner;
        }

        public void ShowAmount()
        {
            Console.WriteLine($"_Amount", _Pin, _Owner);
        }

        /*public string Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
            }
        }*/
    }


}
