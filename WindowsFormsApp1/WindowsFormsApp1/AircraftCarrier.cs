﻿using System;
using System.Drawing;

namespace Laboratornaya
{
    class AircraftCarrier : WarShip
    {
        private IAdditions additions;

        // дополнительные цвета
        public Color DopColor { private set; get; }

        // наличие самолётов
        public bool HasPlane { private set; get; }

        // наличие взлётной полосы
        public bool HasRunWay { private set; get; }

        // наличие радара
        public bool HasRadar { private set; get; }

        // Конструктор
        public AircraftCarrier(int maxSpeed, float weight, Color mainColor, Color dopColor, bool hasPlane, bool hasRunWay, bool hasRadar) :
            base(maxSpeed, weight, mainColor, 150, 100)
        {
            DopColor = dopColor;
            HasPlane = hasPlane;
            HasRunWay = hasRunWay;
            HasRadar = hasRadar;
        }

        public AircraftCarrier(string info) : base(info)
        {
            string[] str = info.Split(separator);
            if (str.Length == 8)
            {
                MaxSpeed = Convert.ToInt32(str[0]);
                Weight = Convert.ToInt32(str[1]);
                MainColor = Color.FromName(str[2]);
                DopColor = Color.FromName(str[3]);
                HasPlane = Convert.ToBoolean(str[4]);
                HasRunWay = Convert.ToBoolean(str[5]);
                HasRadar = Convert.ToBoolean(str[6]);
                
                switch(str[7].Split('.')[0])
                {
                    case "Bomber":
                        additions = new Bomber(Convert.ToInt32(str[7].Split('.')[1]));
                        break;
                    case "Destroyer":
                        additions = new Destroyer(Convert.ToInt32(str[7].Split('.')[1]));
                        break;
                    case "Plane":
                        additions = new Plane(Convert.ToInt32(str[7].Split('.')[1]));
                        break;
                }
            }
        }

        // отрисовка авианосца
        public override void DrawWaterTransport(Graphics g)
        {
            // отрисовка тела
            base.DrawWaterTransport(g);

            // отрисовка взлётной полосы
            if (HasRunWay)
            {
                Point[] points = new Point[4]
                {
                   new Point((int)(_startPosX ), (int)(_startPosY + 22)),
                   new Point((int)(_startPosX + 150), (int)(_startPosY + 22)),
                   new Point((int)(_startPosX + 150), (int)(_startPosY + 78)),
                   new Point((int)(_startPosX ), (int)(_startPosY + 78)),
                };
                g.FillPolygon(new SolidBrush(DopColor), points);
                g.DrawLine(new Pen(Color.White), _startPosX, _startPosY + 47, _startPosX + 150, _startPosY + 47);
            }

            // отрисовка радара
            if (HasRadar)
            {
                g.FillRectangle(new SolidBrush(Color.Black), _startPosX + 95, _startPosY + 5, 20, 10);
                g.FillEllipse(new SolidBrush(Color.LightGray), _startPosX + 97, _startPosY + 8, 5, 5);
            }

            // отрисовка самолёта
            if (HasPlane)
            {
                if (additions != null)
                {
                    additions.DrawAdditions(g, _startPosX, _startPosY);
                }
                else
                {
                    g.DrawLine(new Pen(Color.Black), _startPosX + 104, _startPosY + 27, _startPosX + 104, _startPosY + 43);
                    g.DrawLine(new Pen(Color.Black), _startPosX + 104, _startPosY + 35, _startPosX + 120, _startPosY + 35);
                    g.FillRectangle(new SolidBrush(Color.LightSlateGray), _startPosX + 111, _startPosY + 26, 5, 20);
                }
            }
        }

        public void SetDopColor(Color color)
        {
            DopColor = color;
        }

        public void SetAdditions(IAdditions additions)
        {
            this.additions = additions;
        }

        public override string ToString()
        {
            return
           $"{base.ToString()}{separator}{DopColor.Name}{separator}{HasPlane}{separator}{HasRunWay}{separator}{HasRadar}{separator}{additions}";
        }
    }
}