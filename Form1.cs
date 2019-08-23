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
            for (int i = 1; i <= 24; i++)
            {
                comboBox1.Items.Add(i);
                comboBox2.Items.Add(i);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            scaleLbl.Text = "D Dur";
            chosenScale = FileGenerator.GetDMajorFrets();
            nextBtn.Enabled = false;
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
            if (comboBox1.SelectedItem != null)
                Int32.TryParse(comboBox1.SelectedItem.ToString(), out FileGenerator.minFret);

            if (comboBox2.SelectedItem != null)
                Int32.TryParse(comboBox2.SelectedItem.ToString(), out FileGenerator.maxFret);

            if (FileGenerator.minFret != 0 && FileGenerator.maxFret != 0)
            {
                if (FileGenerator.minFret >= FileGenerator.maxFret)
                {
                    MessageBox.Show("Niepoprawny zakres");
                    FileGenerator.minFret = 0;
                    FileGenerator.maxFret = 0;
                    return;
                }
            }

            FileGenerator.numberOfIterations = 0;

            if (chosenScale != null)
            {
                int[][] pickedNotes = FileGenerator.PickNotes(chosenScale);
                fretboard = FileGenerator.CreateEmptyTab();

                FileGenerator.InsertPickedNotes(fretboard, pickedNotes, chosenScale);
                FileGenerator.CreateFile(fretboard);

                richTextBox2.Text = File.ReadAllText(FileGenerator.path);
                richTextBox2.ScrollToCaret();
            }

            nextBtn.Enabled = true;
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
                Int32.TryParse(comboBox1.SelectedItem.ToString(), out FileGenerator.minFret);

            if (comboBox2.SelectedItem != null)
                Int32.TryParse(comboBox2.SelectedItem.ToString(), out FileGenerator.maxFret);

            if (FileGenerator.minFret != 0 && FileGenerator.maxFret != 0)
            {
                if (FileGenerator.minFret >= FileGenerator.maxFret)
                {
                    MessageBox.Show("Niepoprawny zakres");
                    FileGenerator.minFret = 0;
                    FileGenerator.maxFret = 0;
                    return;
                }
            }

            if (File.Exists(FileGenerator.path))
            {
                FileGenerator.numberOfIterations++;
                string[] linesArray = FileGenerator.GetArrayFromFile();
                previousLinesArray = linesArray;
                int[][] nextNotes = FileGenerator.PickNotes(chosenScale, linesArray);
                if(nextNotes == null)
                {
                    MessageBox.Show("Niepoprawny zakres");
                    FileGenerator.minFret = 0;
                    FileGenerator.maxFret = 0;
                    return;
                }
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

        private void ClearBtn1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                comboBox1.SelectedItem = null;
                FileGenerator.minFret = 0;
            }
        }

        private void ClearBtn2_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                comboBox2.SelectedItem = null;
                FileGenerator.maxFret = 0;
            }
        }
    }
}
