using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex02_New
{
    public partial class CheckersGui : Form
    {
        GameLogic m_Logic = new GameLogic();

        Button m_ButtonFrom = null;
        Button m_ButtonTo = null;
        bool v_IsSecondPick = false;
        public CheckersGui()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button wasClicked = sender as Button;
            if (wasClicked.BackColor == Color.LightBlue)
            {
                v_IsSecondPick = false;
                wasClicked.BackColor = Color.White;
            }
            if (wasClicked.BackColor == Color.White)
            {
                if(v_IsSecondPick==true)
                {
                    m_Logic.Move(m_ButtonFrom, wasClicked);
                    m_ButtonFrom.BackColor = Color.White;
                    v_IsSecondPick = false;
                }
                else
                {
                    m_ButtonFrom=wasClicked;
                    v_IsSecondPick = true;
                    wasClicked.BackColor = Color.LightBlue;
                }
            }

        }
    }
}
