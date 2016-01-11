using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex02_New
{

    public delegate void MovedOccuredDelegate(int i_FromLine, int i_FromRow, int i_ToLine, int i_ToRow);
    public delegate void NotifyEatingOccuredDelegate(int i_FromLine, int i_FromRow, int i_ToLine, int i_ToRow,int i_EatenLine,int i_EatenRow);
    public delegate void UpdateInfoFromSettingDialogDelegate(int i_BoardSize, string i_FirstPlayerName, string i_SecondPlayerName);
    public delegate void NotifyInvalidMove(string i_InvalidMoveMsg);

    public partial class CheckersGui : Form
    {
        private int m_BoardSize;
        private string m_FirstPlayerName;
        private string m_SecondPlayerName;

        private GameLogic m_Logic;

        private Button m_ButtonFrom = null;
        private Button m_ButtonTo = null;
        private bool v_IsSecondPick = false;
        private Point m_FromPoint;
        private Point m_ToPoint;
        private Manager m_Manager;
        int turns = 0;
        ePlayer playerTurnForCheck = ePlayer.O;



        public CheckersGui()
        {
            InitializeComponent();
            InitializeGameDialog GameSettings = new InitializeGameDialog();
            GameSettings.NotifyInfoFromSettingDialog += GameSettings_NotifyInfoFromSettingDialog;
            GameSettings.ShowDialog();
            GameSettings.NotifyInfoFromSettingDialog -= GameSettings_NotifyInfoFromSettingDialog;
            m_Logic = new GameLogic(m_BoardSize);
            m_Logic.NotifyEat += m_Logic_NotifyEat;
            m_Logic.NotifyMovement += m_NotifyMovement;
            m_Logic.NotifyInvalidMove += m_Logic_NotifyInvalidMove;
            InitializeTableLayOut();
        }

        private void m_Logic_NotifyInvalidMove(string i_InvalidMoveMsg)
        {
            MessageBox.Show(i_InvalidMoveMsg);
        }

        private void m_Logic_NotifyEat(int i_FromLine, int i_FromRow, int i_ToLine, int i_ToRow, int i_EatenLine, int i_EatenRow)
        {
            m_NotifyMovement(i_FromLine, i_FromRow, i_ToLine, i_ToRow);
            Button eaten = m_CheckersBoardTableLayOut.GetControlFromPosition(i_EatenRow, i_EatenLine) as Button;
            eaten.Text = string.Empty;

        }

        private void GameSettings_NotifyInfoFromSettingDialog(int i_BoardSize, string i_FirstPlayerName, string i_SecondPlayerName)
        {
            m_BoardSize = i_BoardSize;
            m_FirstPlayerName = i_FirstPlayerName;
            m_SecondPlayerName = i_SecondPlayerName;
            m_Player1ScoreLabel.Text = m_FirstPlayerName;
            m_Player2ScoreLabel.Text = m_SecondPlayerName;
        }

        private void m_NotifyMovement(int i_FromLine, int i_FromRow, int i_ToLine, int i_ToRow)
        {
            Button fromButton = m_CheckersBoardTableLayOut.GetControlFromPosition(i_FromRow, i_FromLine) as Button;
            Button toButton = m_CheckersBoardTableLayOut.GetControlFromPosition(i_ToRow, i_ToLine) as Button;
            toButton.Text = fromButton.Text;
            fromButton.Text = string.Empty;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button wasClicked = sender as Button;
            if (!v_IsSecondPick)
            {
                wasClicked.BackColor = Color.LightBlue;
                v_IsSecondPick = true;
                m_ButtonFrom = wasClicked;
                m_FromPoint.X = m_CheckersBoardTableLayOut.GetCellPosition(wasClicked).Row;
                m_FromPoint.Y = m_CheckersBoardTableLayOut.GetCellPosition(wasClicked).Column;

            }
            else if (wasClicked.BackColor == Color.LightBlue)
            {
                wasClicked.BackColor = Color.White;
                m_ButtonFrom = null;
                v_IsSecondPick = false;

            }
            else
            {
                //X= Row, Y= Line
                m_ButtonTo = wasClicked;
                m_ButtonFrom.BackColor = Color.White;
                v_IsSecondPick = false;
                m_ToPoint.X = m_CheckersBoardTableLayOut.GetCellPosition(wasClicked).Row;
                m_ToPoint.Y = m_CheckersBoardTableLayOut.GetCellPosition(wasClicked).Column;
                if (turns % 2 == 0)
                {
                    m_Logic.CheckWhichMoveIsIt(m_FromPoint.X, m_FromPoint.Y, m_ToPoint.X, m_ToPoint.Y, ePlayer.O, false);
                    turns++;
                }
                else
                {
                    m_Logic.CheckWhichMoveIsIt(m_FromPoint.X, m_FromPoint.Y, m_ToPoint.X, m_ToPoint.Y, ePlayer.X, false);
                    turns++;
                }

            }
        }

        private void InitializeTableLayOut()
        {
            m_CheckersBoardTableLayOut.Controls.Clear();
            m_CheckersBoardTableLayOut.RowCount = m_BoardSize;
            m_CheckersBoardTableLayOut.ColumnCount = m_BoardSize;

            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    Button buttonToAdd = InitializeButton();
                    m_CheckersBoardTableLayOut.Controls.Add(buttonToAdd, j, i);
                }
            }
            EnterAPlayersIntoGuiMatrix();
        }
        private void EnterAPlayersIntoGuiMatrix()
        {
            EnterGuiTablePlayerOneCoins();
            EnterGuiTablePlayerTwoCoins();
            EnterGuiTableSpacers();
        }
        private void EnterGuiTablePlayerOneCoins()
        {
                        for (int i = 0; i < m_BoardSize / 2 - 1; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    if (i % 2 == 1)
                    {
                        Button innerButton = m_CheckersBoardTableLayOut.GetControlFromPosition(j, i) as Button;
                        innerButton.Text = "O";
                        j++;
                         innerButton = m_CheckersBoardTableLayOut.GetControlFromPosition(j, i) as Button;
                        innerButton.Enabled = false;
                        innerButton.UseVisualStyleBackColor = true;
                    }
                    else
                    {
                        Button innerButton = m_CheckersBoardTableLayOut.GetControlFromPosition(j, i) as Button;
                        innerButton.Enabled = false;
                        innerButton.UseVisualStyleBackColor = true;
                        j++;
                         innerButton = m_CheckersBoardTableLayOut.GetControlFromPosition(j, i) as Button;
                        innerButton.Text = "O";

                    }
                }
            }
        }
        private void EnterGuiTablePlayerTwoCoins()
        {
                        for (int i = m_BoardSize - 1; i > m_BoardSize / 2; i--)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    if (i % 2 == 1)
                    {
                        Button innerButton = m_CheckersBoardTableLayOut.GetControlFromPosition(j, i) as Button;
                        innerButton.Text = "X";
                        j++;
                        innerButton = m_CheckersBoardTableLayOut.GetControlFromPosition(j, i) as Button;
                        innerButton.Enabled = false;
                        innerButton.UseVisualStyleBackColor = true;
                    }
                    else
                    {
                        Button innerButton = m_CheckersBoardTableLayOut.GetControlFromPosition(j, i) as Button;
                        innerButton.Enabled = false;
                        innerButton.UseVisualStyleBackColor = true;
                        j++;
                        innerButton = m_CheckersBoardTableLayOut.GetControlFromPosition(j, i) as Button;
                        innerButton.Text = "X";
                    }
                }
            }
        }
        private void EnterGuiTableSpacers()
        {
            for (int i = m_BoardSize / 2 - 1; i <= m_BoardSize / 2; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    if (i % 2 == 1)
                    {
                        j++;
                        Button innerButton = m_CheckersBoardTableLayOut.GetControlFromPosition(j, i) as Button;
                        innerButton.Enabled = false;
                        innerButton.UseVisualStyleBackColor = true;
                    }
                    else
                    {
                        Button innerButton = m_CheckersBoardTableLayOut.GetControlFromPosition(j, i) as Button;
                        innerButton.Enabled = false;
                        innerButton.UseVisualStyleBackColor = true;
                        j++;
                    }
                }
            }
        }

        private Button InitializeButton()
        {
            Button inner = new Button();
            inner.BackColor = System.Drawing.Color.White;
            inner.Dock = System.Windows.Forms.DockStyle.Fill;
            inner.Location = new System.Drawing.Point(311, 2);
            inner.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            inner.TabIndex = 4;
            inner.UseVisualStyleBackColor = false;
            inner.Click += new System.EventHandler(this.button1_Click);
            return inner;
        }

    }
}
