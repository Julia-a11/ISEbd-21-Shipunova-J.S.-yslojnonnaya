using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace Laboratornaya
{
    class AircraftCarrier : WarShip, IEquatable<AircraftCarrier>, IComparable<AircraftCarrier>, IEnumerator<string>, IEnumerable<string>
    {
        public IAdditions Additions { set; get; }

        // дополнительные цвета
        public Color DopColor { private set; get; }

        // наличие самолётов
        public bool HasPlane { private set; get; }

        // наличие взлётной полосы
        public bool HasRunWay { private set; get; }

        // наличие радара
        public bool HasRadar { private set; get; }

        public new string Current
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

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

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

                switch (str[7].Split('.')[0])
                {
                    case "Bomber":
                        Additions = new Bomber(Convert.ToInt32(str[7].Split('.')[1]));
                        break;
                    case "Destroyer":
                        Additions = new Destroyer(Convert.ToInt32(str[7].Split('.')[1]));
                        break;
                    case "Plane":
                        Additions = new Plane(Convert.ToInt32(str[7].Split('.')[1]));
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
                if (Additions != null)
                {
                    Additions.DrawAdditions(g, _startPosX, _startPosY);
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

        public override string ToString()
        {
            return
           $"{base.ToString()}{separator}{DopColor.Name}{separator}{HasPlane}{separator}{HasRunWay}{separator}{HasRadar}{separator}{Additions}";
        }

        // метод интерфейса IEquatable для класса AircraftCarrier
        public bool Equals(AircraftCarrier other)
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
            if (DopColor != other.DopColor)
            {
                return false;
            }
            if (HasPlane != other.HasPlane)
            {
                return false;
            }
            if (HasRadar != other.HasRadar)
            {
                return false;
            }
            if (HasRunWay != other.HasRunWay)
            {
                return false;
            }
            if (Additions != null && other.Additions != null && Additions.ToString() != other.Additions.ToString())
            {
                return false;
            }
            if (Additions == null ^ other.Additions == null)
            {
                return false;
            }
            return true;
        }

        // Перегрузка метода от object
        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is AircraftCarrier warShipObj))
            {
                return false;
            }
            else
            {
                return Equals(warShipObj);
            }
        }

        public int CompareTo(AircraftCarrier other)
        {
            var res = base.CompareTo(other);
            if (res != 0)
            {
                return res;
            }
            if (DopColor != other.DopColor)
            {
                return DopColor.Name.CompareTo(other.DopColor.Name);
            }
            if (HasPlane != other.HasPlane)
            {
                return HasPlane.CompareTo(other.HasPlane);
            }
            if (HasRadar != other.HasRadar)
            {
                return HasRadar.CompareTo(other.HasRadar);
            }
            if (HasRunWay != other.HasRunWay)
            {
                return HasRunWay.CompareTo(other.HasRunWay);
            }
            if (Additions != null && other.Additions != null && Additions.ToString() != other.Additions.ToString())
            {
                return Additions.ToString().CompareTo(other.Additions.ToString());
            }
            if (Additions != null && other.Additions == null)
            {
                return -1;
            }
            if (Additions == null && other.Additions != null)
            {
                return 1;
            }
            return 0;
        }

        public new bool MoveNext()
        {
            currentIndex++;
            return currentIndex < 7 ;
        }

        public void Dispose()
        {

        }

        public new void Reset()
        {
            currentIndex = -1;
        }

        private void PrintInfo()
        {
            foreach (string info in this)
            {
                Console.WriteLine(info);
            }
        }

        public new IEnumerator<string> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
    }
}