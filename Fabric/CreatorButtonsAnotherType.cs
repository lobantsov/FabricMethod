using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.Classes
{
    public class CreateButton_RadioButtons : CreatorButtons
    {
        public override Control CreateButtons(string Answer)
        {
            
            RadioButton radioButton = new RadioButton();
            radioButton.Content = Answer;
            radioButton.Tag = 1;
            return radioButton;
        }
    }

    public class CreateButton_CheckBox : CreatorButtons
    {
        public override Control CreateButtons(string Answer)
        {
            CheckBox CheckBox = new CheckBox();
            CheckBox.Content = Answer;
            CheckBox.Tag = 1;
            return CheckBox;
        }
    }

    public class CreateButton_Button : CreatorButtons
    {
        public override Control CreateButtons(string Answer)
        {
            Button Button = new Button();
            Button.Content = Answer;
            Button.Tag = 1;
            return Button;
        }
    }
}
