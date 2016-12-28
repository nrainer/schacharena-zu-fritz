using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

using SchacharenaZuFritz.Logic.Converter;
using SchacharenaZuFritz.Logic.Exceptions;
using SchacharenaZuFritz.Logic.Game;
using SchacharenaZuFritz.Persistence;

namespace SchacharenaZuFritz.View
{
    public partial class MainForm : Form
    {
        private TextBox mouseOverTextBox;

        public MainForm()
        {
            InitializeComponent();

            this.mouseOverTextBox = null;
        }
        
        public static string Version
        {
        	get
        	{
        		return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        	}
        }

        private void btn_Convert_Click(object sender, EventArgs e)
        {
            ConvertAndSetResult();
        }

        private void tbx_Schacharena_TextChanged(object sender, EventArgs e)
        {
            btn_Convert.Enabled = tbx_Schacharena.Text.Length != 0;

            if (mouseOverTextBox == sender)
            {
                btn_Clear.Visible = tbx_Schacharena.Text.Length != 0;
            }
        }

        private void tbx_Schacharena_MouseEnter(object sender, EventArgs e)
        {
            mouseOverTextBox = (TextBox)sender;
            btn_Paste.Visible = true;
            btn_Clear.Visible = tbx_Schacharena.Text.Length != 0;
        }

        private void tbx_Fritz_MouseEnter(object sender, EventArgs e)
        {
            mouseOverTextBox = (TextBox)sender;
            btn_Copy.Visible = btn_Save.Visible = tbx_Fritz.Text.Length != 0;
        }

        private void tbx_Fritz_TextChanged(object sender, EventArgs e)
        {
            btn_Copy.Visible = (mouseOverTextBox == sender && tbx_Fritz.Text.Length != 0);
        }

        private void btn_Paste_Click(object sender, EventArgs e)
        {
            PasteFromClipBoard(tbx_Schacharena);
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            tbx_Schacharena.Clear();
            tbx_Fritz.Clear();
        }

        private void btn_Copy_Click(object sender, EventArgs e)
        {
            CopyToClipBoard(tbx_Fritz);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "Partie";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SaveUtility.SaveToFile(saveFileDialog1.FileName, tbx_Fritz.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fehler: " + ex.Message, "Ein Fehler ist aufgetreten!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MainForm_MouseEnter(object sender, EventArgs e)
        {
            mouseOverTextBox = null;
            btn_Clear.Visible = btn_Copy.Visible = btn_Paste.Visible = btn_Save.Visible = false;
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F1)
            {
                MessageBox.Show("SchacharenaZuFritz" + Environment.NewLine + "Version " + Version);
            }
        }

        private void btn_ConvertAfterPasting_Click(object sender, EventArgs e)
        {
            PasteFromClipBoard(tbx_Schacharena);
            ConvertAndSetResult();
            CopyToClipBoard(tbx_Fritz);
        }

        private void ConvertAndSetResult()
        {
            tbx_Fritz.Clear();

            string input = tbx_Schacharena.Text;
            
            if (input.Length == 0)
            {
            	return;
            }
            
            try
            {
                tbx_Fritz.Text = ConverterUtility.ConvertFromSchacharenaToFritz(input);
                tbx_Fritz.BackColor = SystemColors.Control;
            }
            catch (ConverterException ex)
            {
                tbx_Fritz.Text = ex.Message + Environment.NewLine + Environment.NewLine 
                	+ ex.StackTrace + Environment.NewLine + Environment.NewLine 
                	+ "In SchacharenaZuFritz " + Version + Environment.NewLine + Environment.NewLine
                	+ "Input was:" + Environment.NewLine + input;
                tbx_Fritz.BackColor = Color.Tomato;
            }
        }

        private void PasteFromClipBoard(TextBox destination)
        {
        	string text = Clipboard.GetText();
        		
        	if (text == null)
        	{
        		text = string.Empty;
        	}
        		
            destination.Text = text;
        }

        private void CopyToClipBoard(TextBox source)
        {
        	string text = source.Text;
        	
        	if (text.Length == 0)
        	{
        		Clipboard.Clear();
        	}
        	else
        	{
            	Clipboard.SetText(source.Text, TextDataFormat.Text);
        	}
        }

        private void btn_do_all_Click(object sender, EventArgs e)
        {
            btn_ConvertAfterPasting_Click(sender, e);
            this.Close();
        }
    }
}