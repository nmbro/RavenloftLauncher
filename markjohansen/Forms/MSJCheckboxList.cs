using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MarkJohansen.Forms
{
    public class MSJCheckboxList : System.Windows.Forms.CheckedListBox
    {
        #region Control CallBacks
        private delegate void setIntCallBack(int v);
        private delegate int getIntCallBack();

        private delegate void setBoolCallBack(bool b);
        private delegate bool getBoolCallBack();

        private delegate void setStringCallBack(string s);
        private delegate string getStringCallBack();
        #endregion

        public void Add(string name)
        {
            if (this.InvokeRequired)
            {
                setStringCallBack d = new setStringCallBack(Add);
                this.Invoke(d, new object[] { name });
            }
            else
            {
                this.Items.Add(name);
            }
        }
    }
}
