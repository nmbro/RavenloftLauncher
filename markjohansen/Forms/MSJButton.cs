using System.Windows.Forms;

namespace MarkJohansen.Forms
{
    public class MSJButton : Button
    {
        private delegate void setEnableBoolCallBack(bool status);
        public void setEnableBool(bool status)
        {
            if (this.InvokeRequired)
            {
                setEnableBoolCallBack d = new setEnableBoolCallBack(setEnableBool);
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
    }
}
