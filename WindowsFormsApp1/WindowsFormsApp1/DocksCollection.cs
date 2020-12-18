using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Laboratornaya
{
    public class DocksCollection
    {
        // Словарь (хранилище) с парковками
        readonly Dictionary<string, Docks<Ship, IAdditions>> docksStages;

        // Возвращение списка названий парковок
        public List<string> Keys => docksStages.Keys.ToList();

        // Ширина окна отрисовки
        private readonly int pictureWidth;

        // Высота окна отрисоки
        private readonly int pictureHeight;

        // разделитель для записи информации в файл
        private readonly char separator = ':';

        // Конструктор
        public DocksCollection(int pictureWidth, int pictureHeight)
        {
            docksStages = new Dictionary<string, Docks<Ship, IAdditions>>();
            this.pictureWidth = pictureWidth;
            this.pictureHeight = pictureHeight;
        }

        // Добавление доков
        public void DocksAdd(string name)
        {
            if (docksStages.ContainsKey(name))
            {
                return;
            }
            docksStages.Add(name, new Docks<Ship, IAdditions>(pictureWidth, pictureHeight));
        }

        // Удаление доков
        public void DocksDel(string name)
        {
            if (docksStages.ContainsKey(name))
            {
                docksStages.Remove(name);
            }
        }

        // Доступ к докам
        public Docks<Ship, IAdditions> this[string ind]
        {
            get
            {
                if (docksStages.ContainsKey(ind))
                {
                    return docksStages[ind];
                }
                return null;
            }
        }

        // сохранение информации по кораблям в доках в файл
        public void SaveData(string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename, false, Encoding.Default))
            {
                sw.WriteLine($"DocksCollection");
                foreach (var level in docksStages)
                {
                    // начинаем парковку
                    sw.WriteLine($"Docks{separator}{level.Key}");
                    foreach (IWaterTransport ship in level.Value)
                    {
                        if (ship != null)
                        {
                            // если место не пустое
                            // записываем тип корабля
                            if (ship.GetType().Name == "WarShip")
                            {
                                sw.Write($"WarShip {separator}");
                            }
                            if (ship.GetType().Name == "AircraftCarrier")
                            {
                                sw.Write($"AircraftCarrier{separator}");
                            }
                            // записываем параметры
                            sw.WriteLine(ship);
                        }
                    }
                }
            }
        }

        // загрузка информации по кораблям в доках из файла
        public void LoadData(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException();
            }
            using (StreamReader sr = new StreamReader(filename, Encoding.Default))
            {
                string line = sr.ReadLine();
                if (line.Contains("DocksCollection"))
                {
                    docksStages.Clear();
                }
                else
                {
                    throw new FileLoadException();
                }
                string key = string.Empty;
                WarShip warShip = null;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains("Dock"))
                    {
                        key = line.Split(separator)[1];
                        docksStages.Add(key, new Docks<Ship, IAdditions>(pictureWidth, pictureHeight));
                    }
                    else if (line.Contains(separator))
                    {

                        if (line.Contains("WarShip"))
                        {
                            warShip = new WarShip(line.Split(separator)[1]);
                        }
                        else if (line.Contains("AircraftCarrier"))
                        {
                            warShip = new AircraftCarrier(line.Split(separator)[1]);
                        }
                        if (!(docksStages[key] + warShip))
                        {
                            throw new DocksOverflowException();
                        }
                    }
                }
            }
        }

        public void SaveDock(string filename, string key)
        {
            if (!docksStages.ContainsKey(key))
            {
                throw new KeyNotFoundException();
            }
            using (StreamWriter sw = new StreamWriter(filename, false, Encoding.Default))
            {
                // начинаем парковку
                sw.WriteLine($"Docks{separator}{key}");
                foreach (IWaterTransport ship in docksStages[key])
                {
                    if (ship != null)
                    {
                        // если место не пустое
                        // записываем тип корабля
                        if (ship.GetType().Name == "WarShip")
                        {
                            sw.Write($"WarShip {separator}");
                        }
                        if (ship.GetType().Name == "AircraftCarrier")
                        {
                            sw.Write($"AircraftCarrier{separator}");
                        }
                        // записываем параметры
                        sw.WriteLine(ship);
                    }
                }
            }
        }

        // загрузка информации по кораблям в доках из файла
        public void LoadDock(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException();
            }
            using (StreamReader sr = new StreamReader(filename, Encoding.Default))
            {
                string line = sr.ReadLine();
                if (!line.Contains("Docks:"))
                {
                    throw new FileLoadException();
                }
                string key = line.Split(separator)[1];
                if (docksStages.ContainsKey(key))
                {
                    docksStages[key].Clear();
                }
                else
                {
                    docksStages.Add(key, new Docks<Ship, IAdditions>(pictureWidth, pictureHeight));
                }
                WarShip warShip = null;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains(separator))
                    {

                        if (line.Contains("WarShip"))
                        {
                            warShip = new WarShip(line.Split(separator)[1]);
                        }
                        else if (line.Contains("AircraftCarrier"))
                        {
                            warShip = new AircraftCarrier(line.Split(separator)[1]);
                        }
                        if (!(docksStages[key] + warShip))
                        {
                            throw new DocksOverflowException();
                        }
                    }
                }
            }
        }

        public Ship this[string name, int ind]
        {
            get
            {
                if (docksStages.ContainsKey(name))
                {
                    return docksStages[name][ind];
                }
                return null;
            }
        }
    }
}