using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MarkJohansen.Forms
{
    class CBDataGridViewTextBoxColumn : DataGridViewTextBoxColumn
    {
        #region Control CallBacks
        private delegate void setIntCallBack(int v);
        private delegate int getIntCallBack();

        private delegate void setBoolCallBack(bool b);
        private delegate bool getBoolCallBack();

        private delegate void setStringCallBack(string s);
        private delegate string getStringCallBack();
        #endregion

        #region base.Visible override
        public void setEnableBool(bool status)
        {
            if (this.InvokeRequired)
            {
                setBoolCallBack d = new setBoolCallBack(setEnableBool);
                this.Invoke(d, new object[] { status });
            }
            else
            {
                base.Enabled = status;
            }
        }
        public bool getEnableBool()
        {
            if (this.InvokeRequired)
            {
                getBoolCallBack d = new getBoolCallBack(getEnableBool);
                return (bool)this.Invoke(d);
            }
            else
            {
                return base.Enabled;
            }
        }
        public bool Enabled
        {
            get { return this.getEnableBool(); }
            set
            {
                this.setEnableBool(value);
            }
        }
        #endregion
    }
}
