using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex02_New
{

    public delegate void MovedOccuredDelegate(int i_FromLine,int i_FromRow,int i_ToLine,int i_ToRow);
    public partial class CheckersGui : Form
    {
        GameLogic m_Logic = new GameLogic();

        Button m_ButtonFrom = null;
        Button m_ButtonTo = null;
        bool v_IsSecondPick = false;
        Point m_FromPoint;
        Point m_ToPoint;
        Manager m_Manager;

        

        public CheckersGui()
        {
            InitializeComponent();
            m_Manager = new Manager(6);
            m_Logic.NotifyMovement += m_Manager_NotifyMovement;  
        }

        private void m_Manager_NotifyMovement(int i_FromLine, int i_FromRow, int i_ToLine, int i_ToRow)
        {
            Button fromButton = m_CheckersBoardTableLayOut.GetControlFromPosition(i_FromRow, i_FromLine) as Button;
            Button toButton = m_CheckersBoardTableLayOut.GetControlFromPosition(i_ToRow, i_ToLine) as Button; 
            toButton.Text = fromButton.Text;
            fromButton.Text = string.Empty;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button wasClicked = sender as Button;
            if(!v_IsSecondPick)
            {
                wasClicked.BackColor = Color.LightBlue;
                v_IsSecondPick = true;
                m_ButtonFrom = wasClicked;
                m_FromPoint.X=m_CheckersBoardTableLayOut.GetCellPosition(wasClicked).Row;
                m_FromPoint.Y = m_CheckersBoardTableLayOut.GetCellPosition(wasClicked).Column;

            }
            else if(wasClicked.BackColor==Color.LightBlue)
            {
                wasClicked.BackColor = Color.White;
                v_IsSecondPick = false;

            }
            else
            {
                m_ButtonTo = wasClicked;
                m_ButtonFrom.BackColor = Color.White;
                v_IsSecondPick = false;
                m_ToPoint.X = m_CheckersBoardTableLayOut.GetCellPosition(wasClicked).Row;
                m_ToPoint.Y = m_CheckersBoardTableLayOut.GetCellPosition(wasClicked).Column;
                m_Logic.Move(ePlayer.O, m_FromPoint.X, m_FromPoint.Y, m_ToPoint.X, m_ToPoint.Y);
            }
        }
    }
}
