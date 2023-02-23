using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class Task : UserControl
    {
        public Task()
        {
            InitializeComponent();
        }
        public string TaskName
        {
            get { return lblTaskName.Text; }
            set { lblTaskName.Text = value; }
        }
        public bool IsCompleted
        {
            get { return checkBox1.Checked; }
            set { checkBox1.Checked = value; }
        }
        public event EventHandler<Task> TaskRemoved;
        public event EventHandler TaskCompleted;
        private void button1_Click(object sender, EventArgs e)
        {
            TaskRemoved?.Invoke(this, this);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (TaskCompleted != null)
            {
                TaskCompleted(this, EventArgs.Empty);
            }
        }
    }
}
