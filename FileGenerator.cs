﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabGenApp
{
    enum GtrString { E, B, G, D, A };

    public static class FileGenerator
    {
        public static int numberOfIterations;
        public static Random rnd;
        public static string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Tab.txt";       // Na razie ustawilem miejsce utworzenia pliku na pulpicie
        public static int minFret;
        public static int maxFret;

        public static void CreateFile(string[,] fretboard)          // Tworzy plik teksowy z wylosowana tabulatura             
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                int rowLength = fretboard.GetLength(0);
                int colLength = fretboard.GetLength(1);

                for (int i = 0; i < rowLength; i++)
                {
                    sw.Write("{0} |--", i != rowLength - 1 ? (GtrString)i : (GtrString)0);

                    for (int j = 0; j < colLength; j++)
                    {
                        sw.Write(fretboard[i, j]);
                    }
                    sw.Write("--|");

                    if (i != rowLength - 1)
                        sw.WriteLine();
                }
            }
        }

        public static void UpdateFile(string[] linesArray, string[,] fretboard)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                if (fretboard != null)
                {
                    int rowLength = fretboard.GetLength(0);
                    int colLength = fretboard.GetLength(1);

                    for (int i = 0; i < linesArray.Length; i++)
                    {
                        sw.Write(linesArray[i] + "--");
                        for (int j = 0; j < colLength; j++)
                        {
                            sw.Write(fretboard[i, j]);
                        }
                        sw.Write("--|");
                        if (i != rowLength - 1)
                            sw.WriteLine();
                    }
                }
                else
                {
                    for (int i = 0; i < linesArray.Length; i++)
                    {
                        if (numberOfIterations % 2 == 0)
                        {
                            sw.Write(linesArray[i] + "--|");
                            if (i != linesArray.Length - 1)
                                sw.WriteLine();
                        }
                        else
                        {
                            sw.Write(linesArray[i]);
                            if (i != linesArray.Length - 1)
                                sw.WriteLine();
                        }
                    }
                }
            }
        }

        public static Tuple<int, int> GetLastNote(string[] linesArray)
        {
            int stringIndex = 0;
            int fret = 0;
            for (int i = 0; i < linesArray.Length; i++)
            {
                string line = linesArray[i];

                string twoLastChars = (numberOfIterations % 2 != 0) ? line.Substring(line.Length - 2) : line.Substring(line.Length - 5, 2);
                if (twoLastChars.Any(char.IsDigit))
                {
                    stringIndex = i;
                    if (twoLastChars.All(char.IsDigit))
                        fret = Int32.Parse(twoLastChars);
                    else
                        fret = Int32.Parse(twoLastChars.Substring(1));
                }
            }

            return Tuple.Create(stringIndex, fret);
        }

        public static string[] GetArrayFromFile()
        {
            string fileText = File.ReadAllText(path);
            string[] lines = fileText.Split('\n');

            List<int> cnt = new List<int>();
            foreach (var line in lines)
            {
                cnt.Add(line.Length);
            }

            for (int i = 0; i < lines.Length; i++)
            {
                if (numberOfIterations % 2 == 0)
                {
                    if (i != lines.Length - 1)
                        lines[i] = lines[i].Remove(lines[i].Length - 1);
                    //else
                    //    lines[i] = lines[i].Remove(lines[i].Length);
                }
                else
                {
                    if (i != lines.Length - 1)
                        lines[i] = lines[i].Remove(lines[i].Length - 4);
                    else
                        lines[i] = lines[i].Remove(lines[i].Length - 3);
                }

            }
            return lines;
        }

        public static int[][] PickNotes(int[][] scaleFrets, string[] linesArray = null)         // Tworzy tablice ze wspólrzednymi wylosowanych dzwieków ze skali
        {
            Tuple<int, int> lastNote = null;
            if (linesArray != null)
            {
                lastNote = GetLastNote(linesArray);
            }
            int rowLength = scaleFrets.GetLength(0);
            int maxColLength = 0;
            foreach (int[] row in scaleFrets)
            {
                if (maxColLength < row.GetLength(0))
                    maxColLength = row.GetLength(0);
            }
            rnd = new Random();
            int[][] pickedNotes = new int[4][];
            int existingFret;
            for (int i = 0; i < pickedNotes.Length; i++)
            {
                while (true)
                {
                    int rRand = rnd.Next(rowLength);
                    int cRand = rnd.Next(maxColLength);
                    try
                    {
                        existingFret = scaleFrets[rRand][cRand];
                        //if (existingFret < minFret && minFret != 0)
                        //    continue;

                        //if(minFret != 0 || maxFret != 0)
                        //{
                        //    if ((maxFret == 0 && existingFret < minFret) 
                        //        || (minFret == 0 && existingFret > maxFret) 
                        //        || !(Enumerable.Range(minFret, maxFret-minFret).Contains(existingFret)))
                        //        continue;
                        //}

                        if (minFret != 0 && maxFret == 0)
                        {
                            if (existingFret < minFret)
                                continue;
                        }
                        if (minFret == 0 && maxFret != 0)
                        {
                            if (existingFret > maxFret)
                                continue;
                        }
                        if (minFret != 0 && maxFret != 0)
                        {
                            if (!Enumerable.Range(minFret, maxFret - minFret + 1).Contains(existingFret))
                                continue;
                        }

                        int stringDif = 0;
                        int fretDif = 0;

                        if (i != 0)
                        {
                            stringDif = Math.Abs(pickedNotes[i - 1][0] - rRand);
                            fretDif = Math.Abs(existingFret - scaleFrets[pickedNotes[i - 1][0]][pickedNotes[i - 1][1]]);
                            if (stringDif > 2 || fretDif > 4)
                                continue;
                        }
                        else
                        {
                            if (lastNote != null)
                            {
                                stringDif = Math.Abs(lastNote.Item1 - rRand);
                                fretDif = Math.Abs(lastNote.Item2 - existingFret);
                                if (stringDif > 2 || fretDif > 4)
                                    continue;
                            }
                        }

                        pickedNotes[i] = new int[2] { rRand, cRand };
                        break;
                    }
                    catch
                    {

                    }
                }
            }
            return pickedNotes;
        }

        public static string[,] CreateEmptyTab()            // Tworzy tablice wypelniona "-"
        {
            string[,] fretboard = new string[6, 11];
            int rowLength = fretboard.GetLength(0);
            int colLength = fretboard.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    fretboard[i, j] = "-";
                }
            }
            return fretboard;
        }

        public static void InsertPickedNotes(string[,] fretboard,
            int[][] pickedNotes, int[][] scaleFrets)                    // Zamienia odpowiednie miejsca w tablicy wylosowanymi dzwiekami ze skali
        {
            for (int j = 0; j < 4; j++)
            {
                int x = pickedNotes[j][0];
                int y = pickedNotes[j][1];
                int value = scaleFrets[x][y];
                fretboard[x, 3 * j] = value.ToString();
                if (value.ToString().Length == 2)
                {
                    fretboard[x, (3 * j + 1)] = "";
                }
                else
                {
                    if (j == 3)
                    {
                        for (int i = 0; i < fretboard.GetLength(0); i++)
                        {
                            fretboard[i, 3 * j + 1] = "";
                        }
                    }
                }
            }
        }

        #region SKALE

        public static int[][] GetDMajorFrets()
        {
            int[] e2frets = { 2, 3, 5, 7, 9, 10, 12, 14, 15, 17, 19, 21, 22, 24 };
            int[] bfrets = { 2, 3, 5, 7, 8, 10, 12, 14, 15, 17, 19, 20, 22, 24 };
            int[] gfrets = { 2, 4, 6, 7, 9, 11, 12, 14, 16, 18, 19, 21, 23, 24 };
            int[] dfrets = { 2, 4, 5, 7, 9, 11, 12, 14, 16, 17, 19, 21, 23, 24 };
            int[] afrets = { 2, 4, 5, 7, 9, 10, 12, 14, 16, 17, 19, 21, 22, 24 };
            int[] efrets = { 2, 3, 5, 7, 9, 10, 12, 14, 15, 17, 19, 21, 22, 24 };

            return new int[][] { e2frets, bfrets, gfrets, dfrets, afrets, efrets };
        }

        public static int[][] GetCMajorFrets()
        {
            int[] e2frets = { 1, 3, 5, 7, 8, 10, 12, 13, 15, 17, 19, 20, 22, 24 };
            int[] bfrets = { 1, 3, 5, 6, 8, 10, 12, 13, 15, 17, 18, 20, 22, 24 };
            int[] gfrets = { 2, 4, 5, 7, 9, 10, 12, 14, 16, 17, 19, 21, 22, 24 };
            int[] dfrets = { 2, 3, 5, 7, 9, 10, 12, 14, 15, 17, 19, 21, 22, 24 };
            int[] afrets = { 2, 3, 5, 7, 8, 10, 12, 14, 15, 17, 19, 20, 22, 24 };
            int[] efrets = { 1, 3, 5, 7, 8, 10, 12, 19, 15, 17, 19, 20, 22, 24 };

            return new int[][] { e2frets, bfrets, gfrets, dfrets, afrets, efrets };
        }

        public static int[][] GetABluesFrets()
        {
            int[] e2frets = { 3, 5, 8, 10, 11, 12, 15, 17 };
            int[] bfrets = { 1, 3, 4, 5, 8, 10, 13, 15, 16, 17 };
            int[] gfrets = { 2, 5, 7, 8, 9, 12, 14, 17 };
            int[] dfrets = { 1, 2, 5, 7, 10, 12, 13, 14, 17 };
            int[] afrets = { 3, 5, 6, 7, 10, 12, 15, 17 };
            int[] efrets = { 3, 5, 8, 10, 11, 12, 15, 17 };

            return new int[][] { e2frets, bfrets, gfrets, dfrets, afrets, efrets };
        }

        #endregion
    }
}
