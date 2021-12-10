using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MobileWhouse
{
    public delegate void LoadComboBoxDataSource(System.Windows.Forms.Control sender, List<string> items);

    public delegate void OnSelectedObject(object sender, object obj);
}
