using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Classes;
using Microsoft.Win32;
using System.IO;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private OpenFileDialog openFileDialog;
        private string[] lines;
        private StackPanel stackPanel;
        private Brush tmpColor;
        public MainWindow()
        {
            InitializeComponent();
            CBButtonsType.Items.Add("Buttons");
            CBButtonsType.Items.Add("CheckBox");
            CBButtonsType.Items.Add("RadioButtons");
            openFileDialog = new OpenFileDialog();
            stackPanel = new StackPanel();
        }

        private void BTCreate_OnClick(object sender, RoutedEventArgs e)
        {
            ATest test = null;
            Control control;
            ContentControl contentControl = new ContentControl();

            switch (CBButtonsType.SelectionBoxItem)
            {
                case "Buttons":
                    test = new TestsButton();
                    break;


                case "CheckBox":
                    test = new TestsCheckBox();
                    break;


                case "RadioButtons":
                    test = new TestsRadioButton();
                    break;
            }

            if (lines != null)
            {
                Label LBQuastion = new Label();
                LBQuastion.Content = lines[0];
                LBQuastion.Tag = 1;
                stackPanel.Children.Add(LBQuastion);
                contentControl.Content = stackPanel;
                MainWindows.ContentControl.Content=contentControl;

                for (int i = 1; i < lines.Length; i++)
                {
                    control = test.CreateButtons(lines[i]);
                    stackPanel.Children.Add(control);

                    contentControl.Content = stackPanel;

                    MainWindows.ContentControl.Content = contentControl;
                }
            }
        }

        private void BTLoadFile_OnClick_(object sender, RoutedEventArgs e)
        {
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                BTLoadFile.Content = "Loaded";
                tmpColor = BTLoadFile.Background;
                BTLoadFile.Background=Brushes.Green;
                BTClearFile.IsEnabled = true;
                lines = File.ReadAllLines(openFileDialog.FileName);
            }
        }

        private void BTDelete_OnClick(object sender, RoutedEventArgs e)
        {
            for (int i = stackPanel.Children.Count - 1; i >= 0; i--)
            {
                UIElement child = stackPanel.Children[i];

                if (child is FrameworkElement frameworkElement &&
                    frameworkElement.Tag != null && frameworkElement.Tag.ToString() == "1")
                {
                    stackPanel.Children.Remove(child);
                }
            }
        }

        private void BTClearFile_OnClick(object sender, RoutedEventArgs e)
        {
            lines = null;
            BTLoadFile.Content = "Load";
            BTLoadFile.Background = tmpColor;
            BTClearFile.IsEnabled = false;
        }
    }
}
