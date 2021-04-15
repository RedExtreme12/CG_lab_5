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

namespace Lab5
{
    public partial class MainForm : Form
    {
        private Drawer drawer = new Drawer();

        public MainForm()
        {
            InitializeComponent();
        }

        private List<int> ParseConfigurationScript()
        {
            List<int> config = new List<int>();
            foreach (string part in configurationScriptInputBox.Text.Replace('\n', ' ').
                Replace('\r', ' ').Replace('\t', ' ').Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
            {
                int value;
                if (!Int32.TryParse(part, out value))
                {
                    MessageBox.Show("Unable to parse " + part + " as integer!", "Error!");
                    return null;
                }

                config.Add(value);
            }

            return config;
        }

        private void lineClipButton_Click(object sender, EventArgs e)
        {
            List<int> config = ParseConfigurationScript();
            if (config == null)
            {
                return;
            }

            if (config.Count % 4 != 0 || config.Count < 8)
            {
                MessageBox.Show("Incorrect configuration format, check readme!", "Error!");
                return;
            }

            drawer.Start(parseClippingRect(config));
            int lineStartIndex = 0;

            while (lineStartIndex < config.Count - 4)
            {
                drawer.DrawLine(config[lineStartIndex], config[lineStartIndex + 1], 
                    config[lineStartIndex + 2], config[lineStartIndex + 3]);
                lineStartIndex += 4;
            }

            resultPictureBox.Image = drawer.End();
            resultPictureBox.Invalidate();
        }

        private Rectangle parseClippingRect(List<int> config)
        {
            int x1 = config[config.Count - 4];
            int y1 = config[config.Count - 3];
            int x2 = config[config.Count - 2];
            int y2 = config[config.Count - 1];

            x1 = Math.Min(x1, x2);
            y1 = Math.Min(y1, y2);
            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

        private void polygonClipButton_Click(object sender, EventArgs e)
        {
            List<int> config = ParseConfigurationScript();
            if (config == null)
            {
                return; 
            }

            if (config.Count % 2 != 0 || config.Count < 6)
            {
                MessageBox.Show("Incorrect configuration format, check readme!", "Error!");
                return;
            }

            drawer.Start(parseClippingRect(config));
            List<Point> points = new List<Point>();
            int pointStartIndex = 0;

            while (pointStartIndex < config.Count - 4)
            {
                points.Add(new Point(config[pointStartIndex], config[pointStartIndex + 1]));
                pointStartIndex += 2;
            }

            drawer.DrawPolygon(points);
            resultPictureBox.Image = drawer.End();
            resultPictureBox.Invalidate();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        
    }
}
