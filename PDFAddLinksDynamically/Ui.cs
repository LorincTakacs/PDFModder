using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFAddLinksDynamically
{
    public class Ui
    {
        private Form1 _form;

        public Form1 Form {
            get { return _form; }
            set { _form = value; }
        }
        
        public Ui(Form1 form)
        {
            Form = form;
        }
        
        public void SetSysMessage(string msg)
        {
            Form.sysConsole.Text += msg + " - " + DateTime.Now + "\n";
        }
    }
}
