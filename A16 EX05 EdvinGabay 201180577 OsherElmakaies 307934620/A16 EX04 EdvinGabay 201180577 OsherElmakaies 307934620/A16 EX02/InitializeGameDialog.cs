using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex02_New
{
    public enum eBoardSize
    {
        Six=6,
        Eight=8,
        Ten=10
    }

    public partial class InitializeGameDialog : Form
    {
        private eBoardSize m_BoardSizeResult;
        public event UpdateInfoFromSettingDialog NotifyInfoFromSettingDialog;
        public int shumdavar;

        public eBoardSize BoardSizeResult
        {
            get { return m_BoardSizeResult;  }
            set { m_BoardSizeResult = value; }
        }
        

        public string FirstPlayerName
        {
            get { return m_Player1NameTextBox.Text; }
        }
        public string SecondPlayerName
        {
            get { return m_Player2NameTextBox.Text; }
        }

        public InitializeGameDialog()
        {
            InitializeComponent();
        }
       

        private void m_EnableSecondPlayerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_Player2NameTextBox.Enabled = !m_Player2NameTextBox.Enabled;
        }

        private void m_BoardSize_CheckedChanged(object sender, EventArgs e)
        {
            if (m_6x6RadioButton.Checked)
            {
                m_BoardSizeResult = eBoardSize.Six;
            }
            else if (m_8x8RadioButton.Checked)
            {
                m_BoardSizeResult = eBoardSize.Eight;
            }
            else
            {
                m_BoardSizeResult = eBoardSize.Ten;
            }
        }

        private void m_DoneButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            int boardSize = Convert.ToInt32(BoardSizeResult);
            NotifyInfoFromSettingDialog(boardSize, FirstPlayerName, SecondPlayerName);
           this.Close();
        }

    }
}
