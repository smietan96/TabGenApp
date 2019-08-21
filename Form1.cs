using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabGenApp
{
    public partial class Form1 : Form
    {
        public int[][] chosenScale;
        public string[,] fretboard;
        public string[] previousLinesArray;

        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            scaleLbl.Text = "D Dur";
            chosenScale = FileGenerator.GetDMajorFrets();
            BackBtn.Enabled = false;
        }

        private void DMajorBtn_Click(object sender, EventArgs e)
        {
            scaleLbl.Text = "D Dur";
            chosenScale = FileGenerator.GetDMajorFrets();
        }

        private void CMajorBtn_Click(object sender, EventArgs e)
        {
            scaleLbl.Text = "C Dur";
            chosenScale = FileGenerator.GetCMajorFrets();
        }

        private void ABluesBtn_Click(object sender, EventArgs e)
        {
            scaleLbl.Text = "A Blues";
            chosenScale = FileGenerator.GetABluesFrets();
        }

        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            if (min10chbx.Checked)
                FileGenerator.minFret = 10;
            else
                FileGenerator.minFret = 0;

            FileGenerator.numberOfIterations = 0;

            if (chosenScale != null)
            {
                int[][] pickedNotes = FileGenerator.PickNotes(chosenScale);
                fretboard = FileGenerator.CreateEmptyTab();

                FileGenerator.InsertPickedNotes(fretboard, pickedNotes, chosenScale);
                FileGenerator.CreateFile(fretboard);
                try
                {
                    Process.Start(@"D:\Program Files\Guitar Pro 6\GuitarPro.exe");
                }
                catch (Exception ex)
                {

                }
                richTextBox2.Text = File.ReadAllText(FileGenerator.path);
                richTextBox2.ScrollToCaret();
            }
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            if (min10chbx.Checked)
                FileGenerator.minFret = 10;
            else
                FileGenerator.minFret = 0;

            if (File.Exists(FileGenerator.path))
            {                
                FileGenerator.numberOfIterations++;
                string[] linesArray = FileGenerator.GetArrayFromFile();
                previousLinesArray = linesArray;
                int[][] nextNotes = FileGenerator.PickNotes(chosenScale, linesArray);
                fretboard = FileGenerator.CreateEmptyTab();

                FileGenerator.InsertPickedNotes(fretboard, nextNotes, chosenScale);
                FileGenerator.UpdateFile(linesArray, fretboard);
                richTextBox2.Text = File.ReadAllText(FileGenerator.path);
                richTextBox2.ScrollToCaret();
                BackBtn.Enabled = true;
            }
        }


        private void BackBtn_Click_1(object sender, EventArgs e)
        {
            if (min10chbx.Checked)
                FileGenerator.minFret = 10;
            else
                FileGenerator.minFret = 0;

            if (File.Exists(FileGenerator.path) && FileGenerator.numberOfIterations > 0)
            {
                FileGenerator.numberOfIterations--;
                fretboard = null;
                FileGenerator.UpdateFile(previousLinesArray, fretboard);
                richTextBox2.Text = File.ReadAllText(FileGenerator.path);
                richTextBox2.SelectionStart = richTextBox2.Text.Length;
                richTextBox2.ScrollToCaret();
            }
            BackBtn.Enabled = false;
        }

        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            File.Delete(FileGenerator.path);
        }

        private void Min10chbx_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
