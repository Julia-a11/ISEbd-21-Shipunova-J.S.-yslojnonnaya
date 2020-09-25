using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratornaya
{
    public partial class FormAircraftCarrier : Form
    {
        private AircraftCarrier aircraftCarrier;
        public FormAircraftCarrier()
        {
            InitializeComponent();
            comboBoxPlane.Items.AddRange(new string[] { "3 самолёта", "4 самолёта", "5 самолётов" });
        }

        // метод отрисовки гидросамолёта
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxAircraftCarrier.Width, pictureBoxAircraftCarrier.Height);
            Graphics gr = Graphics.FromImage(bmp);
            aircraftCarrier.DrawAircraftCarrier(gr);
            pictureBoxAircraftCarrier.Image = bmp;
        }

        // Обработка нажатия кнопки "Создать"
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            aircraftCarrier = new AircraftCarrier(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.DarkGray,
                Color.DimGray, true, true, true, (comboBoxPlane.SelectedIndex + 3));
            aircraftCarrier.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxAircraftCarrier.Width, pictureBoxAircraftCarrier.Height);
            Draw();
        }

        // Обработка нажатия кнопок управления
        private void buttonMove_Click(object sender, EventArgs e)
        {
            // получаем имя кнопки
            string name = (sender as Button).Name;
            switch(name)
            {
                case "buttonUp":
                    aircraftCarrier.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    aircraftCarrier.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    aircraftCarrier.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    aircraftCarrier.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}
