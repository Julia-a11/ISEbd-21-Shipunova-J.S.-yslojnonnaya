using System.Drawing;

namespace Laboratornaya
{
    class Destroyer : IAdditions
    {
        public void DrawAdditions(Graphics g, float _startPosX, float _startPosY)
        {
            switch (planeEnum)
            {
                case PlanesEnum.Three:
                    DrawDestroyerThree(g, _startPosX, _startPosY);
                    break;
                case PlanesEnum.Four:
                    DrawDestroyerFour(g, _startPosX, _startPosY);
                    break;
                case PlanesEnum.Five:
                    DrawDestroyerFive(g, _startPosX, _startPosY);
                    break;
            }
        }

        public int Digit { set => planeEnum = (PlanesEnum)value; }

        private PlanesEnum planeEnum;

        public Destroyer(int digit)
        {
            Digit = digit;
        }

        private void DrawDestroyer(Graphics g, float _startPosX, float _startPosY)
        {
            g.FillEllipse(new SolidBrush(Color.Black), _startPosX + 10, _startPosY + 30, 20, 5);
            Point[] points = new Point[4]
            {
                   new Point((int)(_startPosX + 15), (int)(_startPosY + 35)),
                   new Point((int)(_startPosX + 21), (int)(_startPosY + 26)),
                   new Point((int)(_startPosX + 27), (int)(_startPosY + 24 )),
                   new Point((int)(_startPosX + 19 ), (int)(_startPosY + 35)),
            };
            g.FillPolygon(new SolidBrush(Color.Black), points);

            points = new Point[4]
            {
                   new Point((int)(_startPosX + 15), (int)(_startPosY + 35)),
                   new Point((int)(_startPosX + 10), (int)(_startPosY + 42)),
                   new Point((int)(_startPosX + 16), (int)(_startPosY + 40)),
                   new Point((int)(_startPosX + 22 ), (int)(_startPosY + 35)),
            };
            g.FillPolygon(new SolidBrush(Color.Black), points);

            points = new Point[4]
            {
                   new Point((int)(_startPosX + 14), (int)(_startPosY + 30)),
                   new Point((int)(_startPosX + 8 ), (int)(_startPosY + 26 )),
                   new Point((int)(_startPosX + 8), (int)(_startPosY + 38)),
                   new Point((int)(_startPosX + 14 ), (int)(_startPosY + 34)),
            };
            g.FillPolygon(new SolidBrush(Color.Black), points);
        }

        private void DrawDestroyerThree(Graphics g, float _startPosX, float _startPosY)
        {
            DrawDestroyer(g, _startPosX + 16, _startPosY + 3);
            DrawDestroyer(g, _startPosX + 40, _startPosY + 27);
            DrawDestroyer(g, _startPosX + 54, _startPosY + 3);
        }

        private void DrawDestroyerFour(Graphics g, float _startPosX, float _startPosY)
        {
            DrawDestroyerThree(g, _startPosX, _startPosY);
            DrawDestroyer(g, _startPosX + 74, _startPosY + 27);
        }

        private void DrawDestroyerFive(Graphics g, float _startPosX, float _startPosY)
        {
            DrawDestroyerFour(g, _startPosX, _startPosY);
            DrawDestroyer(g, _startPosX + 88, _startPosY + 3);
        }
    }
}