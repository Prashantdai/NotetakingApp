using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notetaking
{
     public partial class Form1 : Form
     {
        DataTable notes = new DataTable();
        bool editing = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("Note");

            previousNotes.DataSource = notes;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnload_Click(object sender, EventArgs e)
        {
            titlebox.Text=notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            notebox.Text=notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing =true;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                notes.Rows[previousNotes.CurrentCell.RowIndex].Delete();
            }
            catch(Exception ex) { Console.WriteLine("Not a valid Note"); }
        }

        private void btnnewnote_Click(object sender, EventArgs e)
        {
            titlebox.Text = "";
            notebox.Text = "";
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                notes.Rows[previousNotes.CurrentCell.RowIndex]["title"]=titlebox.Text;
                notes.Rows[previousNotes.CurrentCell.RowIndex]["Note"]=notebox.Text;

            }
            else
            {
                notes.Rows.Add(titlebox.Text, notebox.Text);
            }
            titlebox.Text = "";
            notebox.Text = "";
            editing = false;
        }

        private void previousNotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            titlebox.Text=notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            notebox.Text=notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing =true;
        }
    }
}
