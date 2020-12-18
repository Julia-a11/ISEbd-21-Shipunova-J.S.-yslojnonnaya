using NLog;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Laboratornaya
{
    public partial class FormDocks : Form
    {
        //объект от класса - коллекции доков
        private readonly DocksCollection docksCollection;

        private readonly LinkedList<Ship> shipsList;

        // Логгер
        private readonly Logger logger;

        public FormDocks()
        {
            InitializeComponent();
            docksCollection = new DocksCollection(pictureBoxDocks.Width, pictureBoxDocks.Height);
            shipsList = new LinkedList<Ship>();
            logger = LogManager.GetCurrentClassLogger();
        }

        // Заполнение listBox
        private void ReloadLevels()
        {
            int index = listBoxDocks.SelectedIndex;
            listBoxDocks.Items.Clear();
            for (int i = 0; i < docksCollection.Keys.Count; i++)
            {
                listBoxDocks.Items.Add(docksCollection.Keys[i]);
            }
            if (listBoxDocks.Items.Count > 0 && (index == -1 || index >= listBoxDocks.Items.Count))
            {
                listBoxDocks.SelectedIndex = 0;
            }
            else if (listBoxDocks.Items.Count > 0 && index > -1 && index < listBoxDocks.Items.Count)
            {
                listBoxDocks.SelectedIndex = index;
            }
        }


        //метод отрисовки дока
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxDocks.Width, pictureBoxDocks.Height);
            Graphics gr = Graphics.FromImage(bmp);
            if (listBoxDocks.SelectedIndex > -1)
            {
                docksCollection[listBoxDocks.SelectedItem.ToString()].Draw(gr);
            }
            else
            {
                gr.FillRectangle(new SolidBrush(Color.Transparent), 0, 0, pictureBoxDocks.Width, pictureBoxDocks.Height);
            }
            pictureBoxDocks.Image = bmp;
        }



        //обработка кнопки "Забрать"
        private void buttonTakeShip_Click(object sender, EventArgs e)
        {
            if (listBoxDocks.SelectedItem == null)
            {
                MessageBox.Show("Выберите док", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Fatal("Ошибка! Док не выбран!");
                return;
            }
            if (maskedTextBoxNumber.Text != "")
            {
                try
                {
                    var ship = docksCollection[listBoxDocks.SelectedItem.ToString()] - Convert.ToInt32(maskedTextBoxNumber.Text);
                    if (ship != null)
                    {
                        shipsList.AddLast(ship);
                        logger.Info($"Корабль {ship} передан в список с места {maskedTextBoxNumber.Text}");
                    }
                    Draw();
                }
                catch (DocksNotFoundException ex)
                {
                    MessageBox.Show(ex.Message, "Не найдено", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    logger.Warn(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Fatal(ex.Message);
                }
            }
        }

        private void buttonAddDocks_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxDocks.Text))
            {
                MessageBox.Show("Введите название дока", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            logger.Info("Добавили док " + textBoxDocks.Text);
            docksCollection.DocksAdd(textBoxDocks.Text);
            ReloadLevels();
        }

        private void buttonDocksRemove_Click(object sender, EventArgs e)
        {
            if (listBoxDocks.SelectedItem == null)
            {
                MessageBox.Show("Выберите док", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Fatal("Ошибка! Док не выбран!");
                return;
            }
            if (MessageBox.Show($"Удалить док {listBoxDocks.SelectedItem.ToString()}?",
               "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                logger.Info($"Удалили док {listBoxDocks.SelectedItem.ToString()}");
                docksCollection.DocksDel(listBoxDocks.SelectedItem.ToString());
                ReloadLevels();
                Draw();
            }
        }

        private void listBoxDocks_SelectedIndexChanged(object sender, EventArgs e)
        {
            logger.Info($"Перешли на новую парковку {listBoxDocks.SelectedItem.ToString()}");
            Draw();
        }

        // Метод добавления корабля
        private void AddShip(Ship ship)
        {
            if (ship != null && listBoxDocks.SelectedIndex > -1)
            {
                try
                {
                    if ((docksCollection[listBoxDocks.SelectedItem.ToString()]) + ship)
                    {
                        Draw();
                        logger.Info($"Добавлен корабль {ship}");
                    }
                    else
                    {
                        MessageBox.Show("Корабль не удалось поставить");
                    }
                    Draw();
                }
                catch (DocksOverflowException ex)
                {
                    MessageBox.Show(ex.Message, "Переполнение", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    logger.Warn(ex.Message);
                }
                catch (DocksAlreadyHaveException ex)
                {
                    MessageBox.Show(ex.Message, "Дублирование", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    logger.Warn(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    logger.Fatal(ex.Message);
                }
            }
        }

        private void buttonAddWarShip_Click(object sender, EventArgs e)
        {
            if (listBoxDocks.SelectedItem == null)
            {
                MessageBox.Show("Выберите док", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Fatal("Ошибка! Док не выбран!");
                return;
            }
            FormWaterTransportConfig formWaterTransportConfig = new FormWaterTransportConfig();
            formWaterTransportConfig.AddEvent(AddShip);
            formWaterTransportConfig.ShowDialog();
        }

        // обработка нажатия пункта меню "Сохранить"
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    docksCollection.SaveData(saveFileDialog.FileName);
                    MessageBox.Show("Сохранение прошло успешно", "Результат",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Info("Сохранено в файл " + saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Fatal(ex.Message);
                }
            }
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    docksCollection.LoadData(openFileDialog.FileName);
                    MessageBox.Show("Загрузили", "Результат",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Info("Загружено из файла " + openFileDialog.FileName);
                    ReloadLevels();
                    Draw();
                }
                catch (DocksOverflowException ex)
                {
                    MessageBox.Show(ex.Message, "Переполнение",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Warn(ex.Message);
                }
                catch (DocksAlreadyHaveException ex)
                {
                    MessageBox.Show(ex.Message, "Дублирование", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    logger.Warn(ex.Message);
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show(ex.Message, "Файл не найден",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Error(ex.Message);
                }
                catch (FileLoadException ex)
                {
                    MessageBox.Show(ex.Message, "Файл не загружен",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Error(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Fatal(ex.Message);
                }
            }
        }
        private void сохранитьДокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    docksCollection.SaveDock(saveFileDialog.FileName, Convert.ToString(listBoxDocks.SelectedItem));
                    MessageBox.Show("Сохранение прoшло успешно", "Результат",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка при сохранении дока",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Fatal(ex.Message);
                }
            }
        }

        private void загрузитьДокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    docksCollection.LoadDock(openFileDialog.FileName);
                    MessageBox.Show("Загрузили", "Результат", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ReloadLevels();
                    Draw();
                }
                catch (DocksOverflowException ex)
                {
                    MessageBox.Show(ex.Message, "Переполнение",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Warn(ex.Message);
                }
                catch (DocksAlreadyHaveException ex)
                {
                    MessageBox.Show(ex.Message, "Дублирование", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    logger.Warn(ex.Message);
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show(ex.Message, "Файл не найден",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Error(ex.Message);
                }
                catch (FileLoadException ex)
                {
                    MessageBox.Show(ex.Message, "Файл не загружен",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Error(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Fatal(ex.Message);
                }
            }
        }

        private void buttonTransfer_Click(object sender, EventArgs e)
        { 
            if (shipsList.Count > 0)
            {
                FormWaterTransport formWaterTransport = new FormWaterTransport();
                formWaterTransport.SetShip(shipsList.Last.Value);
                logger.Info($"Корабль {shipsList.Last.Value} изъят из списка");
                shipsList.RemoveLast();
                formWaterTransport.ShowDialog();
            }
            else
            {
                MessageBox.Show("Коллекция пуста", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            if (listBoxDocks.SelectedIndex > -1)
            {
                docksCollection[listBoxDocks.SelectedItem.ToString()].Sort();
                Draw();
                logger.Info("Сортировка уровней");
            }
        }
    }
}