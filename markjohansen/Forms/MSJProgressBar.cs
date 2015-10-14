using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MarkJohansen.Forms
{
    public class MSJProgressBar : ProgressBar
    {
        #region Control CallBacks
        private delegate void setIntCallBack(int v);
        private delegate void setBoolCallBack(bool b);
        private delegate void setStringCallBack(string s);
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
        public bool Enabled
        {
            get { return base.Enabled; }
            set
            {
                this.setEnableBool(value);
            }
        }
        #endregion

        #region base.Value override
        public void setValue(int v)
        {
            if (this.InvokeRequired)
            {
                setIntCallBack d = new setIntCallBack(setValue);
                this.Invoke(d, new object[] { v });
            }
            else
            {
                base.Value = v;
            }
        }
        public int Value
        {
            get { return base.Value; }
            set
            {
                this.setValue(value);
            }
        }
        #endregion

        #region base.Maximum override
        public void setMaximum(int v)
        {
            if (this.InvokeRequired)
            {
                setIntCallBack d = new setIntCallBack(setMaximum);
                this.Invoke(d, new object[] { v });
            }
            else
            {
                base.Maximum = v;
            }
        }
        public int Maximum
        {
            get { return base.Maximum; }
            set
            {
                this.setMaximum(value);
            }
        }
        #endregion
    }
}
