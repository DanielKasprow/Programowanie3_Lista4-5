﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daniel_Kasprow_lista_4
{
    public class Registration : ObservableObject
    {
        private string _peselname;
        public string Peselname
        {
            get { return _peselname; }
            set
            {
                OnPropertyChanged(ref _peselname, value);
            }
        }
    }
}
