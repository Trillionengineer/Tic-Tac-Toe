﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int player = 2;
        public int turns = 0;
        public int wins1 = 0;
        public int wins2 = 0;
        public int winsd = 0;

        private void buttonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.Text == "")
            {
                if (player % 2 == 0)
                {
                    button.Text = "X";
                    player++;
                    turns++;
                }
                else
                {
                    button.Text = "O";
                    player++;
                    turns++;
                }
                if (CheckDraw() == true)
                {
                    MessageBox.Show("Tie Game1");
                    winsd++;
                    NewGame();
                }

                if (CheckWin() == true)
                {
                    if (button.Text == "X")
                    {
                        MessageBox.Show("X Wins.");
                        wins1++;
                        NewGame();
                    }
                    else
                    {
                        MessageBox.Show("O Wins.");
                        wins2++;
                        NewGame();
                    }                    
                }
            }           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XWin.Text = "X: " + wins1;
            OWin.Text = "O: " + wins2;
            Draws.Text = "Draws: " + winsd;
        }

        private void EButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        void NewGame()
        {
            player = 2;
            turns = 0;
            A00.Text = A01.Text = A02.Text = A10.Text = A11.Text = A12.Text = A20.Text = A21.Text = A22.Text = "";
            XWin.Text = "X: " + wins1;
            OWin.Text = "O: " + wins2;
            Draws.Text = "Draws: " + winsd;
        }

        private void NGButton_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        bool CheckDraw()
        {
            if((turns == 9) && CheckWin() == false)            
                return true;
            else
                return false;           
        }

        bool CheckWin()
        {
            //Horizontal Checks
            if ((A00.Text != "") && (A00.Text == A01.Text) && (A01.Text == A02.Text))
                return true;
            else if ((A10.Text != "") && (A10.Text == A11.Text) && (A11.Text == A12.Text))
                return true;
            else if ((A20.Text != "") && (A20.Text == A21.Text) && (A21.Text == A22.Text))
                return true;

            //Vertical Checks
            if ((A00.Text != "") && (A00.Text == A10.Text) && (A10.Text == A20.Text))
                return true;
            else if ((A01.Text != "") && (A01.Text == A11.Text) && (A11.Text == A21.Text))
                return true;
            else if ((A02.Text != "") && (A02.Text == A22.Text) && (A02.Text == A22.Text))
                return true;

            //Diagonal Checks
            if ((A00.Text != "") && (A00.Text == A11.Text) && (A11.Text == A22.Text))
                return true;
            else if ((A02.Text != "") && (A02.Text == A11.Text) && (A11.Text == A20.Text))
                return true;
            else
                return false;
        }

        private void RButton_Click(object sender, EventArgs e)
        {
            wins1 = wins2 = winsd = 0;
            NewGame();

        }
    }
}
