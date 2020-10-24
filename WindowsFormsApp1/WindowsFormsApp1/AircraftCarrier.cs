using System.Drawing;

namespace Laboratornaya
{
    class AircraftCarrier : WarShip
    {
        private IAdditions additions;
        // дополнительные цыета
        public Color DopColor { private set; get; }

        // наличие самолётов
        public bool HasPlane { private set; get; }

        // наличие взлётной полосы
        public bool HasRunWay { private set; get; }

        // наличие радара
        public bool HasRadar { private set; get; }

        // Конструктор
        public AircraftCarrier(int maxSpeed, float weight, Color mainColor, Color dopColor, bool hasPlane, bool hasRunWay, bool hasRadar, int planesCount, int planeType) :
            base(maxSpeed, weight, mainColor, 150, 100)
        {
            DopColor = dopColor;
            HasPlane = hasPlane;
            HasRunWay = hasRunWay;
            HasRadar = hasRadar;
            additions = GetAdditions(planeType, planesCount);
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
                   new Point((int)(_startPosX), (int)(_startPosY + 22)),
                   new Point((int)(_startPosX + 150), (int)(_startPosY + 22)),
                   new Point((int)(_startPosX + 150), (int)(_startPosY + 78)),
                   new Point((int)(_startPosX  ), (int)(_startPosY + 78)),
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
            additions?.DrawAdditions(g, _startPosX, _startPosY);
        }

        private IAdditions GetAdditions(int planeType, int planesCount)
        {
            switch (planeType)
            {
                case 0:
                    return new Plane(planesCount);
                case 1:
                    return new Destroyer(planesCount);
                case 2:
                    return new Bomber(planesCount);
            }
            return null;
        }
    }
}
