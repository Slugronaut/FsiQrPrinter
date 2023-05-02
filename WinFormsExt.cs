using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QRTest
{
    public static class WinFormsExt
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="combo"></param>
        /// <returns></returns>
        public static List<string> ComboToStringArray(this ComboBox combo)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < combo.Items.Count; i++)
            {
                var item = combo.Items[i];
                list.Add(combo.GetItemText(item));
            }

            return list;
        }
    }
}
