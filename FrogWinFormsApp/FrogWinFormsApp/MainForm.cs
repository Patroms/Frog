using System.Xml.Serialization;

namespace FrogWinFormsApp
{
    public partial class MainForm : Form
    {
        private int countSteps = 0;


        public MainForm()
        {
            InitializeComponent();
        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            Swap((PictureBox)sender);
            countSteps++;
            countLabel.Text = countSteps.ToString();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void Swap(PictureBox clickedPicture)
        {
            var distance = Math.Abs(clickedPicture.Location.X - emptyPictureBox.Location.X) / emptyPictureBox.Size.Width;

            if (distance > 2)
            {
                MessageBox.Show("Taк нельзя! Лягушка прыгает на соседний листок или через лягушку на листок");
            }
            else
            {
                var location = clickedPicture.Location;

                clickedPicture.Location = emptyPictureBox.Location;

                emptyPictureBox.Location = location;
            }
            if (WinGameCondition())
            {
                if (countSteps == 24)
                {
                    MessageBox.Show("Вы выиграли, за наименьшее количество шагов. Игра пройдена!");
                }
                else
                {
                    MessageBox.Show("Вы выиграли! Но можно и лучше");
                }

            }
        }
        private bool WinGameCondition()
        {
            if (leftPictureBox1.Location.X >= 550 && leftPictureBox2.Location.X >= 550 && leftPictureBox3.Location.X >= 550 && leftPictureBox4.Location.X >= 550 && emptyPictureBox.Location.X==440)
            {
                return true;
            }
            return false;
        }

        private void RestartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShowRulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Цель игры поменять местами лягушек расположенных по две стороны вокруг болотца за наименьшее количество шагов");
        }


    }
}
