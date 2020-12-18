﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace Laboratornaya
{
    //базовый класс
    public class WarShip : Ship, IEquatable<WarShip>, IComparable<WarShip>, IEnumerator<string>, IEnumerable<string>
    {
        // ширина отрисовки корабля
        protected readonly int shipWidth = 150;

        // высота отрисовки корабля
        protected readonly int shipHeight = 100;

        // разделитель для записи информации по объекту в файл
        protected readonly char separator = ';';

        protected int currentIndex;

        public string Current
        {
            get
            {
                switch (currentIndex)
                {
                    case 0: return MaxSpeed.ToString();
                    case 1: return Weight.ToString();
                    case 2: return MainColor.Name;
                }
                return null;
            }
        }

        object IEnumerator.Current => Current;
        
        //конструктор
        public WarShip(int maxSpeed, float weight, Color mainColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            currentIndex = -1;
        }

        // конструктор для загрузки с файла
        public WarShip(string info)
        {
            string[] str = info.Split(separator);
            if (str.Length == 3)
            {
                MaxSpeed = Convert.ToInt32(str[0]);
                Weight = Convert.ToInt32(str[1]);
                MainColor = Color.FromName(str[2]);
                currentIndex = -1;
            }
        }

        //конструктор с изменением размеров корабля
        protected WarShip(int maxSpeed, float weight, Color mainColor, int shipWidth, int shipHeight)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            this.shipWidth = shipWidth;
            this.shipHeight = shipHeight;
        }

        public override void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                // вправо
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - shipWidth)
                    {
                        _startPosX += step;
                    }
                    break;
                // влево
                case Direction.Left:
                    if (_startPosX - step > 0)
                    {
                        _startPosX -= step;
                    }
                    break;
                // вверх
                case Direction.Up:
                    if (_startPosY - step > 0)
                    {
                        _startPosY -= step;
                    }
                    break;
                // вниз
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - shipHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }

        public override void DrawWaterTransport(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Red), _startPosX + 5, _startPosY + 10, 140, 80);

            // отрисовка тела корабля
            Point[] points = new Point[10]
            {
                   new Point((int)(_startPosX ), (int)(_startPosY + 22)),
                   new Point((int)(_startPosX + 40), (int)(_startPosY )),
                   new Point((int)(_startPosX + 120), (int)(_startPosY)),
                   new Point((int)(_startPosX + 120), (int)(_startPosY + 22)),
                   new Point((int)(_startPosX + 150), (int)(_startPosY + 22)),
                   new Point((int)(_startPosX + 150), (int)(_startPosY + 78)),
                   new Point((int)(_startPosX + 120), (int)(_startPosY + 78)),
                   new Point((int)(_startPosX + 120), (int)(_startPosY + 100)),
                   new Point((int)(_startPosX + 40), (int)(_startPosY + 100)),
                   new Point((int)(_startPosX ), (int)(_startPosY + 78)),
            };
            g.FillPolygon(new SolidBrush(MainColor), points);

            //отрисовка запасной лодки
            Point[] points1 = new Point[12]
            {
                   new Point((int)(_startPosX + 30), (int)(_startPosY + 22)),
                   new Point((int)(_startPosX + 65), (int)(_startPosY  + 22)),
                   new Point((int)(_startPosX + 65), (int)(_startPosY + 17)),
                   new Point((int)(_startPosX + 85), (int)(_startPosY + 17)),
                   new Point((int)(_startPosX + 85), (int)(_startPosY + 22)),
                   new Point((int)(_startPosX + 110), (int)(_startPosY + 22)),
                   new Point((int)(_startPosX + 110), (int)(_startPosY + 78)),
                   new Point((int)(_startPosX + 85), (int)(_startPosY + 78)),
                   new Point((int)(_startPosX + 85), (int)(_startPosY + 83)),
                   new Point((int)(_startPosX + 65), (int)(_startPosY + 83)),
                   new Point((int)(_startPosX + 65), (int)(_startPosY + 78)),
                   new Point((int)(_startPosX + 30), (int)(_startPosY + 78)),
            };
            g.FillPolygon(new SolidBrush(Color.Gray), points1);
            g.FillEllipse(new SolidBrush(Color.Brown), _startPosX + 35, _startPosY + 40, 70, 20);

            //отрисовка оружия
            g.FillRectangle(new SolidBrush(Color.Gray), _startPosX + 122, _startPosY + 35, 25, 25);
            g.FillEllipse(new SolidBrush(Color.Green), _startPosX + 127, _startPosY + 40, 15, 15);
            g.DrawLine(new Pen(Color.Black), _startPosX + 139, _startPosY + 47, _startPosX + 149, _startPosY + 47);
        }

        public override string ToString()
        {
            return $"{MaxSpeed}{separator}{Weight}{separator}{MainColor.Name}";
        }

        // метод интерфейса IEquatable для класса WarShip
        public bool Equals(WarShip other)
        {
            if (other == null)
            {
                return false;
            }
            if (GetType().Name != other.GetType().Name)
            {
                return false;
            }
            if (MaxSpeed != other.MaxSpeed)
            {
                return false;
            }
            if (Weight != other.Weight)
            {
                return false;
            }
            if (MainColor != other.MainColor)
            {
                return false;
            }
            return true;
        }

        // перегрузка метода от object
        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is WarShip warShipObj))
            {
                return false;
            }
            else
            {
                return Equals(warShipObj);
            }
        }

        public int CompareTo(WarShip other)
        {
            if (MaxSpeed != other.MaxSpeed)
            {
                return MaxSpeed.CompareTo(other.MaxSpeed);
            }
            if (Weight != other.Weight)
            {
                return Weight.CompareTo(other.Weight);
            }
            if (MainColor != other.MainColor)
            {
                return MainColor.Name.CompareTo(other.MainColor.Name);
            }
            return 0;
        }

        public void Dispose()
        {
     
        }

        public bool MoveNext()
        {
            currentIndex++;
            return currentIndex < 3;
        }

        public void Reset()
        {
            currentIndex = -1;
        }

        private void PrintInfo()
        {
            foreach(string info in this)
            {
                Console.WriteLine(info);
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
    }
}