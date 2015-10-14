using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MarkJohansen.Forms
{
    public class MSJDataGridView : DataGridView
    {
        private delegate void emptyCallBack(DataGridViewRow r);

        public void Add(DataGridViewRow r)
        {
            if (this.InvokeRequired)
            {
                emptyCallBack d = new emptyCallBack(Add);
                this.Invoke(d, new object[] { r });
            }
            else
            {
                base.Rows.Add(r);
            }
        }
    }
}
