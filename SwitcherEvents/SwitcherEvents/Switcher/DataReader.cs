using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Switcher
{
    public class DataReader
    {
        

        private string newString;
        public string NewString// строка що вводиться
        {
            get
            {
                return newString;
            }
            set
            {
                newString = value;
                OnStringChanged();// що відбувається при зміні данних в стрічці
            }
        }

        public event System.EventHandler StringChanged;// подія на ввід строки

        protected virtual void OnStringChanged()
        {
            if (StringChanged != null) StringChanged(this, EventArgs.Empty);
        }

        
    }
}
