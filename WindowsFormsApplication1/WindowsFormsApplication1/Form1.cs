using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        bool ai_turn = true;
        static int turn = 0;
        List<Button> buttons;
        private int[][] ttt = new int[3][];
        public Form1()
        {
            InitializeComponent();
            buttons = new List<Button>();
            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            buttons.Add(button6);
            buttons.Add(button7);
            buttons.Add(button8);
            buttons.Add(button9);

            for(int i = 0; i < 3; i++)
            {
                if(ttt[i] == null)
                {
                    ttt[i] = new int[3];
                }
                for(int j = 0; j < 3; j++)
                {
                    if(ttt[i][j] == null)
                    {
                        ttt[i][j] = new int();
                        ttt[i][j] = 0;
                    }
                }
            }
        }

        private void MyButtonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;

            this.UserClick(sender);
            setXO(button, (turn % 2) + 1);
            turn++;
            if (AIClick())
            {
                //ok
            }
            if (is_winner())
            {
                Application.Restart();
            }
            turn++;

        }

        private void MyButtonClick_ai(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            int newSize = 40;
            clickedButton.Font = new Font(clickedButton.Font.FontFamily, newSize);
            clickedButton.Text = "O";
            clickedButton.Enabled = false;
            setXO(clickedButton, (turn % 2) + 1);
        }

        private void UserClick(object sender)
        {
            Button clickedButton = (Button)sender;
            int newSize = 40;
            clickedButton.Font = new Font(clickedButton.Font.FontFamily, newSize);
            clickedButton.Text = "X";
            clickedButton.Enabled = false;
        }

        private bool AIClick()
        {

            int[] move = alphaBeta(2, 1, int.MinValue, int.MaxValue);

            if (move[1] < 0 || move[2] < 0)
            {
                return false;
            }

            ttt[move[1]][move[2]] = 2;

            int b = 0;

            for( int i = 0; i < 3; i++ )
            {
                for (int j = 0; j < 3; j++ )
                {
                    if( i == move[1] && j == move[2])
                    {
                        Button my_b = buttons[b];
                        EventArgs e = new EventArgs();
                        MyButtonClick_ai(my_b, e);
                    }
                    b++;
                }
            }


            return true;
        }

        private bool is_winner()
        {
            bool won = false;
            int i = 0;
            string message = "";

            for (i = 0; i < 3; i++)
            {
                try
                {
                    if ((ttt[0][i] == ttt[1][i]) && (ttt[0][i] == ttt[2][i]) && (ttt[0][i] != 0) && !won)
                    {
                        if (ttt[0][i] == 1)
                        {
                            message = "You won! Congrats!";
                        }
                        else
                        {
                            message = "You lost! :(";
                        }
                        MessageBox.Show(message);
                        won = true;
                        break;
                    }
                }
                catch (Exception e)
                {
                    // do nothing
                }

                try
                {
                    if ((ttt[i][0] == ttt[i][1]) && (ttt[i][0] == ttt[i][2]) && (ttt[i][0] != 0) && !won)
                    {
                        if (ttt[i][0] == 1)
                        {
                            message = "You won! Congrats!";
                        }
                        else
                        {
                            message = "You lost! :(";
                        }
                        MessageBox.Show(message);
                        won = true;
                        break;
                    }
                }
                catch (Exception e)
                {
                    //do nothing
                }

                try
                {
                    if ((ttt[0][0] == ttt[1][1]) && (ttt[0][0] == ttt[2][2]) && (ttt[0][0] != 0) && !won)
                    {
                        if (ttt[0][0] == 1)
                        {
                            message = "You won! Congrats!";
                        }
                        else
                        {
                            message = "You lost! :(";
                        }
                        MessageBox.Show(message);
                        won = true;
                        break;
                    }
                }
                catch (Exception e)
                {
                    //do nothing
                }

                try
                {
                    if ((ttt[0][2] == ttt[1][1]) && (ttt[0][2] == ttt[2][0]) && (ttt[0][2] != 0) && !won)
                    {
                        if (ttt[0][2] == 1)
                        {
                            message = "You won! Congrats!";
                        }
                        else
                        {
                            message = "You lost! :(";
                        }
                        MessageBox.Show(message);
                        won = true;
                        break;
                    }
                }
                catch (Exception e)
                {
                    //do nothing
                }

            }
            int j = 0;
            bool draw = true;
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    try
                    {
                        if (ttt[i][j] == 0)
                        {
                            draw = false;
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        draw = false;
                        break;
                    }

                }
            }
            if (draw && !won)
            {
                message = "Draw!";
                MessageBox.Show(message);
                won = true;
            }
            return won;
        }

        private void setXO(Button b, int player)
        {
            //1 - user, 2 - AI
            if (b == button1)
            {
                if (ttt[0] == null)
                {
                    ttt[0] = new int[3];
                }
                ttt[0][0] = player;
            }
            else if (b == button2)
            {
                if (ttt[0] == null)
                {
                    ttt[0] = new int[3];
                }
                ttt[0][1] = player;
            }
            else if (b == button3)
            {
                if (ttt[0] == null)
                {
                    ttt[0] = new int[3];
                }
                ttt[0][2] = player;
            }
            else if (b == button4)
            {
                if (ttt[1] == null)
                {
                    ttt[1] = new int[3];
                }
                ttt[1][0] = player;
            }
            else if (b == button5)
            {
                if (ttt[1] == null)
                {
                    ttt[1] = new int[3];
                }
                ttt[1][1] = player;
            }
            else if (b == button6)
            {
                if (ttt[1] == null)
                {
                    ttt[1] = new int[3];
                }
                ttt[1][2] = player;
            }
            else if (b == button7)
            {
                if (ttt[2] == null)
                {
                    ttt[2] = new int[3];
                }
                ttt[2][0] = player;
            }
            else if (b == button8)
            {
                if (ttt[2] == null)
                {
                    ttt[2] = new int[3];
                }
                ttt[2][1] = player;
            }
            else if (b == button9)
            {
                if (ttt[2] == null)
                {
                    ttt[2] = new int[3];
                }
                ttt[2][2] = player;
            }

        }

        public List<KeyValuePair<int, int>> generateAvailableMoves()
        {
            var nextMoves = new List<KeyValuePair<int,int>>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(ttt[i][j] == 0)
                    {
                        nextMoves.Add(new KeyValuePair<int, int>(i, j));
                    }
                }
            }

            return nextMoves;
        }

        private int[] alphaBeta(int depth, int player, int alpha, int beta)
        {
            var availableMoves = generateAvailableMoves();
            int score;
            int row = -1;
            int col = -1;

            if(availableMoves.Count == 0 || depth == 0)
            {
                score = Evaluate();
                return new int[] { score, row, col };
            }

            foreach(KeyValuePair<int,int> m in availableMoves)
            {
                ttt[m.Key][m.Value] = player;

                if(player == 2) //AI - max
                {
                    score = alphaBeta(depth - 1, 1, alpha, beta)[0];
                    //row = m.Key;
                    //col = m.Value;
                    if (score > alpha)
                    {
                        alpha = score;
                        row = m.Key;
                        col = m.Value;
                    }
                }
                else //Human - min
                {
                    score = alphaBeta(depth - 1, 2, alpha, beta)[0];
                    if(score < beta)
                    {
                        beta = score;
                        row = m.Key;
                        col = m.Value;
                    }
                }

                //undo
                ttt[m.Key][m.Value] = 0;

                if (alpha >= beta) break;
            }

            return new int[] { alpha, row, col };
        }
        private int Evaluate()
        {
            int score = 0;
            score += EvaluateLine(0, 0, 0, 1, 0, 2);  // row 0
            score += EvaluateLine(1, 0, 1, 1, 1, 2);  // row 1
            score += EvaluateLine(2, 0, 2, 1, 2, 2);  // row 2
            score += EvaluateLine(0, 0, 1, 0, 2, 0);  // col 0
            score += EvaluateLine(0, 1, 1, 1, 2, 1);  // col 1
            score += EvaluateLine(0, 2, 1, 2, 2, 2);  // col 2
            score += EvaluateLine(0, 0, 1, 1, 2, 2);  // diagonal
            score += EvaluateLine(0, 2, 1, 1, 2, 0);  // alternate diagonal
            return score;

        }

        private int EvaluateLine(int row1, int col1, int row2, int col2, int row3, int col3)
        {
            int score = 0;

            //First Cell
            if (ttt[row1][col1] == 2) //AI
            {
                score = 1;
            }
            else if (ttt[row1][col1] == 1) // human
            {
                score = -1;
            }

            //Second Cell
            if (ttt[row2][col2] == 2) //AI
            {
                if (score == 1) score = 10;
                else if (score == -1) return 0;
                else score = 1;
            }
            else if (ttt[row2][col2] == 1) //human
            {
                if (score == -1) score = -10;
                else if (score == 1) return 0;
                else score = -1;
            }

            //Third Cell
            if (ttt[row3][col3] == 2)  //AI
            {
                if (score > 0) score *= 10;
                else if (score < 0) return 0;
                else score = 1;
            }
            else if (ttt[row3][col3] == 1)  //human
            {
                if (score < 0) score *= 10;
                else if (score > 1) return 0;
                else score = -1;
            }

            return score;
        }


    }
}
