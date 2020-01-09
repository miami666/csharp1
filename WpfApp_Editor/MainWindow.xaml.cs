using System;
using System.Collections.Generic;
using System.Linq;
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
using System.IO;
using Microsoft.Win32;

namespace WpfApp_Editor
{
    public partial class RichTextEditorBeispiel : Window
    {
        public RichTextEditorBeispiel()
        {
            InitializeComponent();
            cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cmbFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
        }

        private void oldSkoolEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = oldSkoolEditor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btnBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            temp = oldSkoolEditor.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btnItalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
            temp = oldSkoolEditor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btnUnderline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            temp = oldSkoolEditor.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            cmbFontFamily.SelectedItem = temp;
            temp = oldSkoolEditor.Selection.GetPropertyValue(Inline.FontSizeProperty);
            cmbFontSize.Text = temp.ToString();
        }

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                string filename = dlg.FileName;
                UserInput.Text = filename;
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Open);
                TextRange range = new TextRange(oldSkoolEditor.Document.ContentStart, oldSkoolEditor.Document.ContentEnd);
                range.Load(fileStream, DataFormats.Rtf);
                fileStream.Close();
            }
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Create);
                TextRange range = new TextRange(oldSkoolEditor.Document.ContentStart, oldSkoolEditor.Document.ContentEnd);
                range.Save(fileStream, DataFormats.Rtf);
                fileStream.Close();
            }
        }

        private void cmbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontFamily.SelectedItem != null)
                oldSkoolEditor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbFontFamily.SelectedItem);
        }

        private void cmbFontSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            oldSkoolEditor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmbFontSize.Text);
        }
        private void fontcolor(RichTextBox rc)
        {
            var colorDialog = new System.Windows.Forms.ColorDialog();
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var wpfcolor = Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
                TextRange range = new TextRange(rc.Selection.Start, rc.Selection.End);
                range.ApplyPropertyValue(FlowDocument.ForegroundProperty, new SolidColorBrush(wpfcolor));
            }
        }
        private void btn_Font_Click(object sender, RoutedEventArgs e)
        {
            fontcolor(oldSkoolEditor);
        }
        private static FileAttributes RemoveAttribute(FileAttributes attributes, FileAttributes attributesToRemove)
        {
            return attributes & ~attributesToRemove;
        }
        private void btnSchreibschutz_Click(object sender,RoutedEventArgs e)
        {

            string dateiName = UserInput.Text;
            if (!File.Exists(dateiName))
            {
                MessageBox.Show($"{dateiName}Datei nicht vorhanden");
                return;
            }
            else
            {
                FileAttributes attributes = File.GetAttributes(dateiName);

                if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                {

                    attributes = RemoveAttribute(attributes, FileAttributes.ReadOnly);
                    File.SetAttributes((dateiName), attributes);
                    MessageBox.Show("Datei " + dateiName + " nicht mehr schreibgeschuetzt.");
                }
                else
                {

                    File.SetAttributes((dateiName), File.GetAttributes(dateiName) | FileAttributes.ReadOnly);
                    MessageBox.Show("Datei "+dateiName+" jetzt schreibgeschützt.");
                }
            }

        }

        private void buttonAnzeige_Click(object sender,RoutedEventArgs e)
        {
            if (UserInput.Text != "")
            {


                var window = new anzeige(this) { Owner = this };
                window.ShowDialog();
            }
            else
            {
                MessageBox.Show("keine Datei ausgewählt");
            }

        }
    }
}