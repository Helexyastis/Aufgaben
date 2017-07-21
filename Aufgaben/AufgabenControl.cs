using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aufgaben
{
    class AufgabenControl : Control
    {

        Label lName;
        
        public AufgabenControl() 
            : base()
        {

        }

        public AufgabenControl(string text, int left, int top, int width, int height) 
            : base(text, left, top, width, height)
        {

        }

       
    }
}
