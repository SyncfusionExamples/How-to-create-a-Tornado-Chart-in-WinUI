using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WinUI_TornadoChart
{
    public class ViewModel
    {
        public ObservableCollection<Model> Data { get; set; }

        public ViewModel()
        {
            Data = new ObservableCollection<Model>();

            Data.Add(new Model(new DateTime(2000, 1, 1), 175, -125));
            Data.Add(new Model(new DateTime(2001, 1, 1), 190, -125));
            Data.Add(new Model(new DateTime(2002, 1, 1), 210, -150));
            Data.Add(new Model(new DateTime(2003, 1, 1), 210, -200));
            Data.Add(new Model(new DateTime(2004, 1, 1), 260, -220));
            Data.Add(new Model(new DateTime(2005, 1, 1), 250, -140));
            Data.Add(new Model(new DateTime(2006, 1, 1), 220, -210));
            Data.Add(new Model(new DateTime(2007, 1, 1), 240, -290));
            Data.Add(new Model(new DateTime(2008, 1, 1), 375, -320));
            Data.Add(new Model(new DateTime(2009, 1, 1), 180, -325));
        }
    }
}
