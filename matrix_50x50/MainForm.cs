using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace matrix_50x50
{
    public partial class MainForm : Form
    {
        public static int count = 0;
        public MainForm()
        {
            InitializeComponent();
            iterateMatrix(addButton);
        }
        void iterateMatrix(Action<int, int> fx)
        {
            for (int col = 0; col < tableLayoutPanel.ColumnCount; col++) {
                for (int row = 0; row < tableLayoutPanel.RowCount; row++) {
                    fx(col, row); }}
        }
        private void buttonClear_Click(object sender, EventArgs e) => iterateMatrix(clearBackColor);
        private void clearBackColor(int col, int row) => tableLayoutPanel.GetControlFromPosition(col, row).BackColor = Color.Cyan;
        private void addButton(int col, int row)
        {
            var upgradedPictureBox = new UpgradedPictureBox();
            upgradedPictureBox.BackColor = Color.Cyan;
            tableLayoutPanel.Controls.Add(upgradedPictureBox, col, row);
            upgradedPictureBox.Anchor = (AnchorStyles)0xF;
            upgradedPictureBox.Location = new Point(0, 0);
            upgradedPictureBox.Margin = new Padding(0);
            upgradedPictureBox.Name = $"pictureBox_{col}_{row}";
            upgradedPictureBox.Size = new Size(20, 20);
            upgradedPictureBox.TabStop = false;
        }
    }

    public class UpgradedPictureBox : PictureBox
    {
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            BackColor = Color.Fuchsia;
            Capture = false;
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (MouseButtons == MouseButtons.Left)
            {
                BackColor = Color.Fuchsia;
            }
        }
    }
}
