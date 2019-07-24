using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace COMP123_S2019_Lesson11C
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// This is the constructor for MainForm
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This is the event handler for the MainForm's FormClosing event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// This is the event handler for the exitToolStripMenuItem Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// This is the event handler for the aboutToolStripMenuItem Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.aboutForm.ShowDialog();
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            Program.aboutForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sectionCDatabaseDataSet.StudentTable' table. You can move, or remove it, as needed.
            this.studentTableTableAdapter.Fill(this.sectionCDatabaseDataSet.StudentTable);

        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            //var StudentList =
            //    from student in this.sectionCDatabaseDataSet.StudentTable
            //    select student;

            //foreach (var student in StudentList.ToList())
            //{
            //    Debug.WriteLine("Student Id:" + student.StudentID +
            //        "Last Name:" + student.LastName);
            //}
        }

        private void StudentDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // local variables that are used as aliases
            var currentCell = StudentDataGridView.CurrentCell;
            var rowIndex = StudentDataGridView.CurrentCell.RowIndex;
            var currentRow = StudentDataGridView.Rows[rowIndex];
            var columnCount = StudentDataGridView.ColumnCount;
            var cells = currentRow.Cells;


            currentRow.Selected = true;

            string outputstring = String.Empty;

            for (int index = 0; index < columnCount; index++)
            {
                outputstring += cells[index].Value + " ";
            }

            SelectionLabel.Text = outputstring;

            Program.student.id = int.Parse(cells[0].Value.ToString());
            Program.student.StudentID = cells[1].Value.ToString();
            Program.student.FirstName = cells[2].Value.ToString();
            Program.student.LastName = cells[3].Value.ToString();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter outputStream = new StreamWriter("Student.txt");

            outputStream.WriteLine(Program.student.id);
            outputStream.WriteLine(Program.student.StudentID);
            outputStream.WriteLine(Program.student.FirstName);
            outputStream.WriteLine(Program.student.LastName);

            outputStream.Close();
        }
    }
}
