using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Ex02_New
{
    public class GameLogic
    {
        public void Move(Button i_From,Button i_To)
        {
           // if (IsGoodMoveData(i_MoveFromTo))//To create new method
           // {

            i_To.Text = i_From.Text;
            i_From.Text = string.Empty;
          //  }
          //  else
          //  {
            //    throw new System.ArgumentException(
             //       "Parameters Format incorrect please re-enter new parameters in the correct format");
           // }
        }
    }
}
