using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EverClone.View
{
    /// <summary>
    /// Lógica interna para NoteWin.xaml
    /// </summary>
    public partial class NoteWin : Window
    {
        public NoteWin()
        {
            InitializeComponent();

            var fontFamilies = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            FontCB.ItemsSource = fontFamilies;

            List<double> fontSizes = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 28, 36, 48 };
            SizeCB.ItemsSource = fontSizes;
            //List<Color> stnColor = new List<Color>() {  }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Speech_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ContentRichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int ammountChar = (new TextRange(contentRichTextBox.Document.ContentStart, contentRichTextBox.Document.ContentEnd)).Text.Length;

            statusTextBlock.Text = $"Tamanho do Documento: {ammountChar} caracteres.";
        }

        private void boldButton_Click(object sender, RoutedEventArgs e)
        {
            bool isButtonChecked = (sender as ToggleButton).IsChecked ?? false;
            if (isButtonChecked)
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Bold);
            else
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Normal);
        }

        private void itallicButton_Click(object sender, RoutedEventArgs e)
        {
            bool isButtonChecked = (sender as ToggleButton).IsChecked ?? false;
            if (isButtonChecked)
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Italic);
            else
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Normal);
        }

        private void underButton_Click(object sender, RoutedEventArgs e)
        {
            bool isButtonChecked = (sender as ToggleButton).IsChecked ?? false;
            if (isButtonChecked)
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            else
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, null);
        }

        private void ContentRichTextBox_SelChanged(object sender, RoutedEventArgs e)
        {
            var selWeight = contentRichTextBox.Selection.GetPropertyValue(FontWeightProperty);
            var selStyle = contentRichTextBox.Selection.GetPropertyValue(FontStyleProperty);
            var selDecoration = contentRichTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty);

            boldButton.IsChecked = (selWeight != DependencyProperty.UnsetValue) && (selWeight.Equals(FontWeights.Bold));
            itallicButton.IsChecked = (selStyle != DependencyProperty.UnsetValue) && (selStyle.Equals(FontStyles.Italic));
            underButton.IsChecked = (selStyle != DependencyProperty.UnsetValue) && (selDecoration.Equals(TextDecorations.Underline));

            FontCB.SelectedItem = contentRichTextBox.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            SizeCB.Text = (contentRichTextBox.Selection.GetPropertyValue(Inline.FontSizeProperty)).ToString();
        }

        private void FontCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(FontCB.SelectedItem != null)
            {
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, FontCB.SelectedItem);
            }
        }

        private void SizeCB_TextChanged(object sender, TextChangedEventArgs e)
        {
            contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontSizeProperty, SizeCB.Text);
        }

        private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (ColorPicker.SelectedColor != null)
            {                
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.ForegroundProperty, new SolidColorBrush(ColorPicker.SelectedColor.Value));
            }
        }
    }
}
