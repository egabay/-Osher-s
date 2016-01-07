using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex02_New
{

    public delegate void ChangeButtonStatusDelegate(TableLayoutPanel i_Button);
    public partial class CheckersGui : Form
    {
        GameLogic m_Logic = new GameLogic();

        Button m_ButtonFrom = null;
        Button m_ButtonTo = null;
        bool v_IsSecondPick = false;
        Manager m_Manager;

        

        public CheckersGui()
        {
            InitializeComponent();
            m_Manager = new Manager(m_CheckersBoardTableLayOut);
            m_Manager.NotifyChangeButtonStatus += m_Manager_NotifyChangeButtonStatus;        
        }

        void m_Manager_NotifyChangeButtonStatus(TableLayoutPanel i_CheckersBoard)
        {
            
            this.m_CheckersBoardTableLayOut = i_CheckersBoard;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button wasClicked = sender as Button;
            m_Manager.ClickPerformed(wasClicked);
        }
    }
}
