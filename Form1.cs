using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1
{

    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        stGameStatus GameStatus;
        enPlayer PlayerRun = enPlayer.Player1;
        enum enPlayer { Player1, Player2 }
        enum enWinner { Player1, Player2, Draw, GameInProgress }
        struct stGameStatus
        {
            public short PlyerCount;
            public enWinner Winner;

            public bool GameOver;

        }

        public void EndGame()
        {
            lblPlayer.Text = "Game Over";

            
            switch(GameStatus.Winner)
            {
                case enWinner.Player1:
                 label2.Text = "Player 1";
                    break;

                case enWinner.Player2:
                    label2.Text = "Player 2";
                    break;

                default:
                    label2.Text = "Draw";
                    break;

            }
            MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public bool CheckValues(Button btn1, Button btn2, Button btn3)
        {
            if(btn1.Tag.ToString()!="?" && btn1.Tag.ToString()== btn2.Tag.ToString()
                && btn1.Tag.ToString()== btn3.Tag.ToString())

            {
                btn1.BackColor = Color.Yellow;
                btn2.BackColor = Color.Yellow;
                btn3.BackColor = Color.Yellow;
               
                if(btn1.Tag.ToString()=="X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }

                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;

                }


            }

            GameStatus.GameOver = false;
            return false;

        }


        public void CheckWinner()
        {


            //checked rows
            //check Row1
            if (CheckValues(button1, button2, button3))
                return;

            //check Row2
            if (CheckValues(button4, button5, button6))
                return;

            //check Row3
            if (CheckValues(button7, button8, button9))
                return;

            //checked cols
            //check col1
            if (CheckValues(button1, button4, button7))
                return;

            //check col2
            if (CheckValues(button2, button5, button8))
                return;

            //check col3
            if (CheckValues(button3, button6, button9))
                return;

            //check Diagonal

            //check Diagonal1
            if (CheckValues(button1, button5, button9))
                return;

            //check Diagonal2
            if (CheckValues(button3, button5, button7))
                return;


        }


        public void ChangImage(Button btn)
        {
           if(btn.Tag.ToString()=="?")
            {
                switch(PlayerRun)
                {
                    case enPlayer.Player1:
                        btn.Image = Resources.X;
                        PlayerRun = enPlayer.Player2;
                        lblPlayer.Text = "Player 2";
                        GameStatus.PlyerCount++;
                        btn.Tag = "X";
                        CheckWinner();
                        break;
                    case enPlayer.Player2:
                        btn.Image = Resources.O;
                        PlayerRun = enPlayer.Player1;
                        lblPlayer.Text = "Player 1";
                        GameStatus.PlyerCount++;
                        btn.Tag = "O";
                        CheckWinner();
                        break;
                }
             
            }
           else
            {
                MessageBox.Show("Wrong Choice", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            if (GameStatus.PlyerCount==9)
            {

                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();
            }

            
        }


        private void Form_Draw(object sender, PaintEventArgs e)
        {
            Color White = Color.FromArgb(250, 250, 250, 250);
            Pen WhiltPen = new Pen(White);
            WhiltPen.Width = 15;

            e.Graphics.DrawLine(WhiltPen, 400, 300, 1050, 300);
            e.Graphics.DrawLine(WhiltPen, 400, 460, 1050, 460);
            e.Graphics.DrawLine(WhiltPen, 610, 140, 610, 620);
            e.Graphics.DrawLine(WhiltPen, 840, 140, 840, 620);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangImage(button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangImage(button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangImage(button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangImage(button4);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChangImage(button5);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChangImage(button6);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChangImage(button7);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            ChangImage(button8);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            ChangImage(button9);

        }


        public void Restart(Button btn)
        {
            btn.Tag = "?";
            btn.Image = Resources.question_mark_96;
            btn.BackColor = Color.Transparent;
           

        }
        private void button11_Click(object sender, EventArgs e)
        {
            Restart(button1);
            Restart(button2);
            Restart(button3);
            Restart(button4);
            Restart(button5);
            Restart(button6);
            Restart(button7);
            Restart(button8);
            Restart(button9);
            PlayerRun = enPlayer.Player1;
            GameStatus.GameOver = false;
            GameStatus.PlyerCount = 0;
            GameStatus.Winner = enWinner.GameInProgress;
            label2.Text = "In Progress";
            lblPlayer.Text = "Player 1";
        }


        //private void button_Cilck(object sender, EventArgs e)
        //{
        //    ChangImage((Button)sender);
        //}


    }
}
