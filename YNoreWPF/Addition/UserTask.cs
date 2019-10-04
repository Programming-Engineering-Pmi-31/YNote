using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YNoreWPF.Addition {
    public class UserTask {
        public bool Status { get; set; }
        public string Text { get; set; }

        public UserTask(bool status, string text) {
            Status = status;
            Text = text;
        }
    }
}
