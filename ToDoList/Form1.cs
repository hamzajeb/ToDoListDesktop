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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            populateItems();
        }
        private int i = 0;

        private void populateItems()
        {
            flowLayoutPanel1.Controls.Clear();
            Task[] list = new Task[5];
            string[] text = new string[5] {"Task 1","Task 2","Task 3","Task 4","Task 5"};
           for (int i = 0; i < list.Length; i++)
            {
                list[i] = new Task();
                list[i].TaskName = text[i];
                list[i].TaskRemoved += Task_TaskRemoved;
                list[i].TaskCompleted += Task_TaskCompleted;
                flowLayoutPanel1.Controls.Add(list[i]);
                list[i].Click += new System.EventHandler(this.UserControl_Click);
           }
      }
        private void Task_TaskCompleted(object sender, EventArgs e)
        {
            Task task = (Task)sender;
            string count = Count.Text;
            int i = int.Parse(count);
            if (task.IsCompleted)
            {
                // Do something when a task is completed
                i = i + 1;
               
            }
            else
            {
                i = i - 1;
            }
            string c= i.ToString();
            Count.Text = c;

        }
        private void Task_TaskRemoved(object sender, Task task)
        {
            // Suppression du TaskControl associé
            flowLayoutPanel1.Controls.Remove(task);
            string count = Count.Text;
            int i = int.Parse(count);
            if (task.IsCompleted)
            {
                // Do something when a task is completed
                i = i - 1;

            }
            string c = i.ToString();
            Count.Text = c;
        }

        private void UserControl_Click(object sender, EventArgs e)
        {
            Task obj = (Task)sender;
            MessageBox.Show(string.Format(obj.TaskName), "Message", MessageBoxButtons.OK);
        }

        private void button1_Click(object sender, EventArgs e)
        {
                
                string text = textBox1.Text;
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("texte est vide", "Message", MessageBoxButtons.OK);
            }
            else
            {
                Task task = new Task();
                task.TaskName = text;
                // Abonnement à l'événement TaskRemoved de chaque TaskControl
                task.TaskRemoved += Task_TaskRemoved;
                task.TaskCompleted += Task_TaskCompleted;
                flowLayoutPanel1.Controls.Add(task);
                textBox1.Text = "";
                // Utilisez la variable "texte" pour faire quelque chose avec le texte récupéré
            }

        }

    }
}
