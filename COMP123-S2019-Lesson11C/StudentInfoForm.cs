using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP123_S2019_Lesson11C
{
    public partial class StudentInfoForm : Form
    {
        public StudentInfoForm()
        {
            InitializeComponent();
        }

        

        private void StudentInfoForm_Load(object sender, EventArgs e)
        {
            StreamReader inputStream = new StreamReader("Student.txt");

            Program.student.id = int.Parse(inputStream.ReadLine());
            Program.student.StudentID = inputStream.ReadLine();
            Program.student.FirstName = inputStream.ReadLine();
            Program.student.LastName = inputStream.ReadLine();

            
            inputStream.Close();
        }
    }
}
