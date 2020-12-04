﻿using System.Collections.Generic;
using System.Drawing;

namespace Laboratornaya
{
    // Параметризованный класс для хранения набора объектов от интерфейса IWaterTrnsport
    public class Docks<T, U> where T : class, IWaterTransport
                             where U : class, IAdditions
    {
        //Список объектов, которые храним
        private readonly List<T> _places;

        //Максимальное количество мест в доках
        private readonly int _maxDocksPlaces;

        // Ширина окна отрисовки
        private readonly int pictureWidth;

        // Высота окна отрисовки
        private readonly int pictureHeight;

        // Размер парковочного места (ширина)
        private readonly int _placeSizeWidth = 210;

        // Размер парковочного места (высота)
        private readonly int _placeSizeHeight = 130;

        public Docks(int picWidth, int picHeight)
        {
            int width = picWidth / _placeSizeWidth;
            int height = picHeight / _placeSizeHeight;
            _maxDocksPlaces = width * height;
            pictureWidth = picWidth;
            pictureHeight = picHeight;
            _places = new List<T>();
        }

        //Перегрузка оператора сложения
        public static bool operator +(Docks<T,U> d, T ship)
        {
            if (d._places.Count >= d._maxDocksPlaces)
            {
                return false;
            }
            d._places.Add(ship);
            return true;
        }

        // Перегрузка оператора вычитания
        public static T operator -(Docks<T,U> d, int index)
        {
            if (index < -1 || index >= d._places.Count)
            {
                return null;
            }
            T ship = d._places[index];
            d._places.RemoveAt(index);
            return ship;
        }

        // Метод отрисовки дока
        public void Draw(Graphics g)
        {
            DrawMarking(g);
            for (int i = 0; i < _places.Count; ++i)
            {
                _places[i].SetPosition(_placeSizeWidth * (i / (pictureHeight / _placeSizeHeight)),
                       20 + _placeSizeHeight * (i % (pictureHeight / _placeSizeHeight)), pictureWidth, pictureHeight);
                _places[i].DrawWaterTransport(g);
            }
        }

        //метод отрисовки мест
        private void DrawMarking(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);
            for (int i = 0; i < pictureWidth / _placeSizeWidth; i++)
            {
                for (int j = 0; j < pictureHeight / _placeSizeHeight + 1; ++j)
                {
                    //линия разметки места
                    g.DrawLine(pen, i * _placeSizeWidth, j * _placeSizeHeight,
                        i * _placeSizeWidth + _placeSizeWidth / 2, j * _placeSizeHeight);
                }
                g.DrawLine(pen, i * _placeSizeWidth, 0, i * _placeSizeWidth,
                    (pictureHeight / _placeSizeHeight) * _placeSizeHeight);
            }
        }
        public T this [int index]
        {
            get
            {
                if (index >= 0 && index < _places.Count)
                {
                    return _places[index];
                }
                return null;
            }
        }
    }
}