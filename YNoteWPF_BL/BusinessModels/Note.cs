using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YNoteWPF_BL.BusinessModels
{
    public class Note {
        public string Text { get; set; }
        public List<UserTask> Tasks { get; set; }

        public Note() {
            Text = "";
            Tasks = new List<UserTask>();
        }
        public Note(string text, List<UserTask> tasks) {
            Text = text;
            Tasks = tasks;
        }
    }
}
