using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.Classes
{
    public class TestsButton:ATest
    {
        public override Control CreateButtons(string Answer)
        {
            CreateButton_Button Buttons = new CreateButton_Button();
            return Buttons.CreateButtons(Answer);
        }
    }

    public class TestsCheckBox : ATest
    {
        public override Control CreateButtons(string Answer)
        {
            CreateButton_CheckBox Buttons = new CreateButton_CheckBox();
            return Buttons.CreateButtons(Answer);
        }
    }

    public class TestsRadioButton : ATest
    {
        public override Control CreateButtons(string Answer)
        {
            CreateButton_RadioButtons Buttons = new CreateButton_RadioButtons();
            return Buttons.CreateButtons(Answer);
        }
    }
}
