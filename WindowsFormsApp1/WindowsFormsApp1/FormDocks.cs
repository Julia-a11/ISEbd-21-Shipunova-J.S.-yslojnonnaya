using System;
using System.Drawing;
using System.Windows.Forms;

namespace Laboratornaya
{
    public partial class FormDocks : Form
    {
        private readonly Docks<WarShip,IAdditions> docks;

        public FormDocks()
        {
            InitializeComponent();
            docks = new Docks<WarShip,IAdditions>(pictureBoxDocks.Width, pictureBoxDocks.Height);
            Draw();
        }

        //метод отрисовки дока
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxDocks.Width, pictureBoxDocks.Height);
            Graphics gr = Graphics.FromImage(bmp);
            docks.Draw(gr);
            pictureBoxDocks.Image = bmp;
        }

        //обработка нажатия кнопки "Припарковать военный корабль"
        private void buttonParkingWarShip_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                WarShip ship = new WarShip(100, 1000, dialog.Color);
                if (docks + ship )
                {
                    Draw();
                }
                else
                {
                    MessageBox.Show("Доки переполнены");
                }
            }
        }

        //обработка нажатия кнопки "Припарковать авианосец"
        private void buttonParkingAircraftCarrier_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ColorDialog dialogDop = new ColorDialog();
                if (dialogDop.ShowDialog() == DialogResult.OK)
                {
                     WarShip ship = new AircraftCarrier(100, 1000, dialog.Color, dialogDop.Color, true, true, true);
                    if (docks + ship)
                    {
                        Draw();
                    }
                    else
                    {
                        MessageBox.Show("Доки переполнены");
                    }
                }
            }
        }

        //обработка кнопки "Забрать"
        private void buttonTakeShip_Click(object sender, EventArgs e)
        {
            if (maskedTextBoxNumber.Text != "")
            {
                var ship = docks - Convert.ToInt32(maskedTextBoxNumber.Text);
                if (ship != null )
                {
                    FormWaterTransport form = new FormWaterTransport();
                    form.SetShip(ship);

                    form.ShowDialog();
                }
                Draw();
            }
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            int _countOfPlace = Convert.ToInt32(maskedTextBoxCountOfWarShips.Text);
            if (maskedTextBoxCountOfWarShips.Text != "")
            {
                if (docks ==  _countOfPlace)
                {
                    MessageBox.Show("Количество занятых мест равно  " + _countOfPlace + " (истина)");
                }
                else
                {
                    MessageBox.Show("Количество занятых мест не равно  " + _countOfPlace + " (ложь)");
                }
            }
        }

        private void buttonNotEqual_Click(object sender, EventArgs e)
        {
            int _countOfPlace = Convert.ToInt32(maskedTextBoxCountOfWarShips.Text);
            if (maskedTextBoxCountOfWarShips.Text != "")
            {
                if (docks != _countOfPlace)
                {
                    MessageBox.Show("Количество занятых мест не равно  " + _countOfPlace + " (истина)");
                }
                else
                {
                    MessageBox.Show("Количество занятых мест равно  " + _countOfPlace + " (ложь)");
                }
            }
        }
    }
}
    
      
      
    

