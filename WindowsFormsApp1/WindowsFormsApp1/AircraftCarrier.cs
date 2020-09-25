using System.Drawing;

namespace Laboratornaya
{
    class AircraftCarrier
    {
        private Plane plane;

        //левая координата отрисовки авианосца
        private float _startPosX;

        //правая координата отрисовки авианосца
        private float _startPosY;

        //ширина окна отрисовки
        private int _pictureWidth;

        //высота окна отрисовки
        private int _pictureHeight;

        // ширина отрисовки авианосца
        private readonly int aircraftCarrierWidth = 150;

        // высота отрисовки авианосца
        private readonly int aircraftCarrierHeight = 100;

        // максимальная скорость
        public int MaxSpeed { private set; get; }

        // вес
        public float Weight { private set; get; }

        // главный цвет
        public Color MainColor { private set; get; }

        // дополнительные цыета
        public Color DopColor { private set; get; }

        // наличие самолётов
        public bool HasPlane { private set; get; }

        // наличие взлётной полосы
        public bool HasRunWay { private set; get; }

        // наличие радара
        public bool HasRadar { private set; get; }

        // Конструктор
        public AircraftCarrier(int maxSpeed, float weight, Color mainColor, Color dopColor, bool hasPlane, bool hasRunWay, bool hasRadar, int planesCount)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            DopColor = dopColor;
            HasPlane = hasPlane;
            HasRunWay = hasRunWay;
            HasRadar = hasRadar;
            plane = new Plane(planesCount);
        }

        // установка позиции авианосца
        public void SetPosition(int x, int y, int width, int height)
        {
            if ((_startPosX >= 0 && _startPosX + aircraftCarrierWidth < _pictureWidth) &&
                (_startPosY >= 0 && _startPosY + aircraftCarrierHeight < _pictureHeight))
            {
                _startPosX = x;
                _startPosY = y;
            }
            _pictureHeight = height;
            _pictureWidth = width;
        }

        // Изменение направления перемещения
        public void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                // вправо
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - aircraftCarrierWidth)
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
                    if (_startPosY + step < _pictureHeight - aircraftCarrierHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }

        // отрисовка авианосца
        public void DrawAircraftCarrier(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Red), _startPosX + 5, _startPosY + 10, 140, 80);

            // отрисовка тела авианосца
            Point[] points = new Point[10]
            {
                   new Point((int)(_startPosX), (int)(_startPosY + 22)),
                   new Point((int)(_startPosX + 40), (int)(_startPosY )),
                   new Point((int)(_startPosX + 120), (int)(_startPosY)),
                   new Point((int)(_startPosX + 120), (int)(_startPosY + 22)),
                   new Point((int)(_startPosX + 150), (int)(_startPosY + 22)),
                   new Point((int)(_startPosX + 150), (int)(_startPosY + 62)),
                   new Point((int)(_startPosX + 120), (int)(_startPosY + 62)),
                   new Point((int)(_startPosX + 120), (int)(_startPosY + 100)),
                   new Point((int)(_startPosX + 40), (int)(_startPosY + 100)),
                   new Point((int)(_startPosX), (int)(_startPosY + 78)),
            };
            g.FillPolygon(new SolidBrush(MainColor), points);

            // отрисовка взлётной полосы
            if (HasRunWay)
            {
                points = new Point[4]
                {
                   new Point((int)(_startPosX), (int)(_startPosY + 22)),
                   new Point((int)(_startPosX + 150), (int)(_startPosY + 22)),
                   new Point((int)(_startPosX + 150), (int)(_startPosY + 72)),
                   new Point((int)(_startPosX  ), (int)(_startPosY + 72)),

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
                g.DrawLine(new Pen(Color.Black), _startPosX + 104, _startPosY + 27, _startPosX + 104, _startPosY + 43);
                g.DrawLine(new Pen(Color.Black), _startPosX + 104, _startPosY + 35, _startPosX + 120, _startPosY + 35);
                g.FillRectangle(new SolidBrush(Color.LightSlateGray), _startPosX + 111, _startPosY + 26, 5, 20);
            }
            plane.Draw(g, _startPosX, _startPosY);
        }
    }
}
