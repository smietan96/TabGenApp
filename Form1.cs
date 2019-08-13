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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            if(chosenScale != null)
            {
                int[][] pickedNotes = FileGenerator.PickNotes(chosenScale);
                fretboard = FileGenerator.CreateEmptyTab();

                FileGenerator.InsertPickedNotes(fretboard, pickedNotes, chosenScale);
                FileGenerator.CreateFile(fretboard);
                try
                {
                    Process.Start(@"D:\Program Files\Guitar Pro 6\GuitarPro.exe");      
                }catch(Exception ex)
                {

                }
            }
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            if (File.Exists(FileGenerator.path))
            {
                string[] linesArray = FileGenerator.GetArrayFromFile();
                int[][] nextNotes = FileGenerator.PickNotes(chosenScale);
                fretboard = FileGenerator.CreateEmptyTab();

                FileGenerator.InsertPickedNotes(fretboard, nextNotes, chosenScale);
                FileGenerator.UpdateFile(linesArray, fretboard);

            }
        }
    }
}
