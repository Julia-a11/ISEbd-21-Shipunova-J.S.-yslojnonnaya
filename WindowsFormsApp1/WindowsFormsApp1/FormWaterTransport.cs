﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Laboratornaya
{
    public partial class FormWaterTransport : Form
    {
        private IWaterTransport ship;
       
        public FormWaterTransport()
        {
            InitializeComponent();
            comboBoxPlanesCount.Items.AddRange(new string[] { "3 самолёта", "4 самолёта", "5 самолётов" });
            comboBoxAdditions.Items.AddRange(new string[] { "Гражданские", "Истребители", "Бомбардировщики" });
            comboBoxPlanesCount.SelectedIndex = 0;
            comboBoxAdditions.SelectedIndex = 0;
        }

        // метод отрисовки гидросамолёта
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxShip.Width, pictureBoxShip.Height);
            Graphics gr = Graphics.FromImage(bmp);
            ship.DrawWaterTransport(gr);
            pictureBoxShip.Image = bmp;
        }

        private void buttonCreateAirctaft_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            ship = new AircraftCarrier(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.DarkGray, Color.DimGray, true, true, true, (comboBoxPlanesCount.SelectedIndex + 3),comboBoxAdditions.SelectedIndex);
            ship.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxShip.Width, pictureBoxShip.Height);
            Draw();
        }

        private void buttonCreateWarShip_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            ship = new WarShip(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.DarkGray);
            ship.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxShip.Width, pictureBoxShip.Height);
            Draw();
        }

        // Обработка нажатия кнопок управления
        private void buttonMove_Click(object sender, EventArgs e)
        {
            // получаем имя кнопки
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    ship.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    ship.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    ship.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    ship.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}
