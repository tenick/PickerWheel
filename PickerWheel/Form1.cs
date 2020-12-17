using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;

namespace PickerWheel
{
    public partial class Form1 : Form
    {
        PieContainerPanel pieContainer_pnl;
        public Form1()
        {
            InitializeComponent();
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            // Adding pie to form
            AcceptButton = Add_btn;
            pieContainer_pnl = new PieContainerPanel(new Point(15, 15), new Size(425, 425));
            pieContainer_pnl.Invalidate();
            Controls.Add(pieContainer_pnl);
        }
        private async void SpinClick_btn(object sender, EventArgs e)
        {
            UserInput_pnl.Enabled = false;
            if (InputContainer_flowLayoutPnl.Controls.Count == 0)
                MessageBox.Show("Please add an input.");
            else
                await pieContainer_pnl.Spin();
            UserInput_pnl.Enabled = true;
        }
        private void AddClick_btn(object sender, EventArgs e)
        {
            // there should be an input to add
            if (PieInput_txtBox.Text.Length == 0)
                return;

            // get target input
            int targetInput = 0;
            Regex regex = new Regex("(__)(\\d+)");
            if (regex.IsMatch(PieInput_txtBox.Text))
            {
                targetInput = Convert.ToInt32(regex.Match(PieInput_txtBox.Text).Groups[2].Value) - 1;
                pieContainer_pnl.TargetInput = targetInput;
                PieInput_txtBox.Text = "";
                return;
            }
            
            Color bg = RandomLightColor();
            Panel inputContainer_pnl = new Panel();
            inputContainer_pnl.Size = new Size(InputContainer_flowLayoutPnl.Size.Width - 30, 30);
            inputContainer_pnl.BackColor = bg;

            string label = PieInput_txtBox.Text;
            Label inputName_lbl = new Label();
            inputName_lbl.Font = new Font("Microsoft JhengHei UI", 12, FontStyle.Bold);
            inputName_lbl.Text = label;
            inputName_lbl.Location = new Point(5, 5);

            Button inputRemove_btn = new Button();
            inputRemove_btn.Text = "X";
            inputRemove_btn.Font = new Font("Microsoft JhengHei UI", 10, FontStyle.Bold);
            inputRemove_btn.Location = new Point(inputContainer_pnl.Size.Width-30, 0);
            inputRemove_btn.Size = new Size(30, inputContainer_pnl.Height);
            inputRemove_btn.BackColor = Color.FromArgb(214, 86, 86);
            inputRemove_btn.ForeColor = Color.White;
            inputRemove_btn.TabStop = false;
            inputRemove_btn.FlatStyle = FlatStyle.Flat;
            inputRemove_btn.FlatAppearance.BorderSize = 0;
            inputRemove_btn.MouseClick += RemoveInputClick_btn;

            // Add to panel
            inputContainer_pnl.Controls.Add(inputName_lbl);
            inputContainer_pnl.Controls.Add(inputRemove_btn);
            
            // Add to flowlayoutpanel
            InputContainer_flowLayoutPnl.Controls.Add(inputContainer_pnl);
            InputContainer_flowLayoutPnl.ScrollControlIntoView(inputContainer_pnl);

            // update pie
            pieContainer_pnl.AddPie(label, bg);

            // clear TextBox
            PieInput_txtBox.Text = "";
        }
        private void RemoveInputClick_btn(object sender, EventArgs e)
        {
            Panel parentPnl = (Panel)((Button)sender).Parent;
            FlowLayoutPanel parentFlowLayoutPanel = (FlowLayoutPanel)(parentPnl.Parent);
            parentFlowLayoutPanel.Controls.Remove(parentPnl);

            string label = "";
            foreach (Control ctrl in parentPnl.Controls)
            {
                // Check if control is of type label
                if (ctrl.GetType() == typeof(Label))
                {
                    label = ctrl.Text;
                }
            }

            pieContainer_pnl.RemovePie(label, parentPnl.BackColor);
            parentPnl.Dispose();
        }

        Random r = new Random();
        private Color RandomLightColor()
        {
            return ControlPaint.LightLight(Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256)));
        }
        
    }
}
