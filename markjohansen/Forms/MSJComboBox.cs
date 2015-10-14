using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MarkJohansen.Forms
{
    public class MSJComboBox : ComboBox
    {
        #region Control CallBacks
        private delegate void setIntCallBack(int v);
        private delegate int getIntCallBack();

        private delegate void setBoolCallBack(bool b);
        private delegate bool getBoolCallBack();

        private delegate void setStringCallBack(string s);
        private delegate string getStringCallBack();
        #endregion

        #region base.Enable override
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

        #region base.Text override
        public void setText(string s)
        {
            if (this.InvokeRequired)
            {
                setStringCallBack d = new setStringCallBack(setText);
                this.Invoke(d, new object[] { s });
            }
            else
            {
                base.Text = s;
            }
        }
        public string getText()
        {
            if (this.InvokeRequired)
            {
                getStringCallBack d = new getStringCallBack(getText);
                return (string)this.Invoke(d);
            }
            else
            {
                return base.Text;
            }
        }
        public string Text
        {
            get { return this.getText(); }
            set
            {
                this.setText(value);
            }
        }
        #endregion
    }
}
