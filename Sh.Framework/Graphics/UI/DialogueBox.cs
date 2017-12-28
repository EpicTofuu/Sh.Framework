using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sh.Framework.Graphics.UI
{
    public class DialogueBox
    {
        public enum type
        {
            okay,
            yesno,
            yesnocancel,
            input,
            inputyesno
        }

        public type Type;
        public string message;
        public string title;
        public bool outcome;
        public string answer;

    }
}
