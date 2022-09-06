using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Xml;
using Microsoft.Office.Interop.Excel;
using MSO.Excel;
using System.IO;


namespace MEGATRON
{
    public partial class Form1 : Form
    {
        object missingParam = Type.Missing;

        public Form1()
        {
            InitializeComponent();

            if (!File.Exists("Megatron.xml"))
            {
                using (XmlWriter writer = XmlWriter.Create("Megatron.xml"))
                {
                    // Write XML data.
                    writer.WriteStartElement("Settings");
                    writer.WriteEndElement();

                    writer.Flush();
                }

                XmlDocument settings = new XmlDocument();
                settings.Load("Megatron.xml");
                XmlNode node = settings.DocumentElement;
                XmlElement element;
                #region Наполнение xml настройки
                int[] BC = { 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 145, 146, 147, 148, 149, 150, 151, 152, 153, 154, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170 };
                for (int i = 1; i <= 10; i++)
                {
                    for (int j = 1; j <= 10; j++)
                    {
                        int index = int.Parse(i.ToString() + j.ToString()) - 11;
                        if (j == 10)
                        {
                            index = (i * j) - 1;
                        }
                        element = settings.CreateElement("BlockChannel");
                        element.SetAttribute("Block", i.ToString());
                        element.SetAttribute("Channel", j.ToString());
                        element.SetAttribute("BC", BC[index].ToString());
                        node.AppendChild(element);
                    }
                }
                
                #endregion
                settings.Save("Megatron.xml");

            }
            

            dataGridViewMount.Columns.Add("Number", "№ п/п");
            dataGridViewMount.Columns["Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewMount.Columns.Add("Block", "Блок");
            dataGridViewMount.Columns["Block"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewMount.Columns.Add("Channel", "Канал");
            dataGridViewMount.Columns["Channel"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewMount.Columns.Add("Caliber", "Калибр");
            dataGridViewMount.Columns["Caliber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewMount.Columns.Add("Name", "Название");
            dataGridViewMount.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewMount.Columns.Add("Delay", "Время");
            dataGridViewMount.Columns["Delay"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            

            if (!File.Exists("Program.xml"))
            {
                using (XmlWriter writer = XmlWriter.Create("Program.xml"))
                {
                    // Write XML data.
                    writer.WriteStartElement("Program");
                    writer.WriteEndElement();

                    writer.Flush();
                }
            }
            
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dataGridViewProgram.Rows.Clear();
                DeleteRows();
                AddRows();
                
                DelFiles();
            }
        }

        

        private void AddRows()
        {
            listBoxInfo.Items.Clear();
            buttonSaveTxt.Enabled = false;
            Excel ex = new Excel();
            System.Globalization.CultureInfo info = System.Globalization.CultureInfo.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            ex.OpenDocument(openFileDialog1.FileName);
            int x = 0;
            string _Range = "B" + (x + 1).ToString();
            XmlDocument program = new XmlDocument();
            program.Load("Program.xml");
            XmlNode node = program.DocumentElement;
            node.RemoveAll();
            XmlElement shot;
            string[] timelst = new string[1];
            timelst[0] = "start";
            while (ex.GetValue(_Range) != null)
            {
                dataGridViewMount.Rows.Add();
                shot = program.CreateElement("Shot");
                shot.SetAttribute("ID", (x + 1).ToString());
                dataGridViewMount.Rows[x].Cells["Number"].Value = (x + 1).ToString();
                string[] time = new string[1];
                time[0] = ex.GetValue(_Range);
                shot.SetAttribute("Time", time[0]);
                dataGridViewMount.Rows[x].Cells["Delay"].Value = ex.GetValue(_Range);
                time[0] = ((Int32.Parse(time[0].Substring(1, 1)) * 100 * 60 * 60) + (Int32.Parse(time[0].Substring(3, 2)) * 100 * 60) + (Int32.Parse(time[0].Substring(6, 2)) * 100) + Int32.Parse(time[0].Substring(9, 2))).ToString();
                shot.InnerText = time[0];
                timelst = timelst.Concat(time).ToArray();
                _Range = "C" + (x + 1).ToString();
                shot.SetAttribute("Block", ex.GetValue(_Range));
                dataGridViewMount.Rows[x].Cells["Block"].Value = ex.GetValue(_Range);
                _Range = "D" + (x + 1).ToString();
                shot.SetAttribute("Channel", ex.GetValue(_Range));
                dataGridViewMount.Rows[x].Cells["Channel"].Value = ex.GetValue(_Range);
                _Range = "E" + (x + 1).ToString();
                shot.SetAttribute("Caliber", ex.GetValue(_Range));
                dataGridViewMount.Rows[x].Cells["Caliber"].Value = ex.GetValue(_Range);
                _Range = "F" + (x + 1).ToString();
                shot.SetAttribute("Name", ex.GetValue(_Range));
                dataGridViewMount.Rows[x].Cells["Name"].Value = ex.GetValue(_Range);
                node.AppendChild(shot);
                                /*dataGridViewMount.Rows.Add();
                dataGridViewMount.Rows[x].Cells["Delay"].Value = ex.GetValue(_Range);
                _Range = "A" + (x + 1).ToString();
                dataGridViewMount.Rows[x].Cells["Number"].Value = x + 1;
                _Range = "C" + (x + 1).ToString();
                dataGridViewMount.Rows[x].Cells["Block"].Value = ex.GetValue(_Range);
                _Range = "D" + (x + 1).ToString();
                dataGridViewMount.Rows[x].Cells["Channel"].Value = ex.GetValue(_Range);
                */
                
                x = x + 1;
                _Range = "B" + (x + 1).ToString();

            }
            program.Save("Program.xml");
            ex.CloseDocument();
            System.Threading.Thread.CurrentThread.CurrentCulture = info;
            
            
            XmlNodeList nodelst = program.SelectNodes("/Program/Shot");
            int error = 0;
            foreach (XmlNode node1 in nodelst)
            {
                foreach (XmlNode node2 in nodelst)
                {
                    if (node1.Attributes["ID"].Value != node2.Attributes["ID"].Value)
                    {
                        if (node1.InnerText == node2.InnerText & (node1.Attributes["Block"].Value != node2.Attributes["Block"].Value || node1.Attributes["Channel"].Value != node2.Attributes["Channel"].Value))
                        {
                            listBoxInfo.Items.Add("Ошибка : Строки " + node1.Attributes["ID"].Value + " и " + node2.Attributes["ID"].Value + ". Одинаковое время разные блоки и/или каналы.");
                            error = error + 1;
                        }
                        if (node1.Attributes["Block"].Value == node2.Attributes["Block"].Value & node1.Attributes["Channel"].Value == node2.Attributes["Channel"].Value & node1.InnerText != node2.InnerText)
                        {
                            listBoxInfo.Items.Add("Ошибка : Строки " + node1.Attributes["ID"].Value + " и " + node2.Attributes["ID"].Value + ". Одинаковые блоки и/или каналы разное время.");
                            error = error + 1;
                        }

                    }
                }
                if (int.Parse(node1.Attributes["Block"].Value) == 0 || int.Parse(node1.Attributes["Channel"].Value) == 0 || int.Parse(node1.InnerText) == 0)
                {
                    listBoxInfo.Items.Add("Ошибка : Строка " + node1.Attributes["ID"].Value + " есть значение \"0\"");
                    error = error + 1;
                }
            }

            if (error == 0)
            {
                listBoxInfo.Items.Add("Ошибок нет");
                dataGridViewMount.Rows.Clear();
                buttonSaveTxt.Enabled = true;
                timelst = timelst.Distinct().ToArray();
                timelst = timelst.Skip(1).ToArray();
                string[] tmp = new string[timelst.Count()];
                
                for (int i = 0; i < timelst.Count(); i++)
                {
                    int min = int.MaxValue;
                    for (int j = 0; j < timelst.Count(); j++)
                    {
                        if (int.Parse(timelst[j]) < min & i == 0)
                        {
                            min = int.Parse(timelst[j]);
                        }
                        if (i != 0 && int.Parse(timelst[j]) > int.Parse(tmp[i-1]) & int.Parse(timelst[j]) < min)
                        {
                            min = int.Parse(timelst[j]);
                        }
                    }

                    tmp[i] = min.ToString();
                }

                timelst = tmp;

                int rowIndex = 0;
                for (int i = 0; i < timelst.Count(); i++)
                {
                    foreach (XmlNode nodetmp in nodelst)
                    {
                        if (int.Parse(nodetmp.InnerText) == int.Parse(timelst[i]))
                        {
                            dataGridViewMount.Rows.Add();
                            dataGridViewMount.Rows[rowIndex].Cells["Number"].Value = rowIndex + 1;
                            nodetmp.Attributes["ID"].Value = (rowIndex + 1).ToString();
                            dataGridViewMount.Rows[rowIndex].Cells["Block"].Value = nodetmp.Attributes["Block"].Value;
                            dataGridViewMount.Rows[rowIndex].Cells["Channel"].Value = nodetmp.Attributes["Channel"].Value;
                            dataGridViewMount.Rows[rowIndex].Cells["Delay"].Value = nodetmp.Attributes["Time"].Value;
                            dataGridViewMount.Rows[rowIndex].Cells["Caliber"].Value = nodetmp.Attributes["Caliber"].Value;
                            dataGridViewMount.Rows[rowIndex].Cells["Name"].Value = nodetmp.Attributes["Name"].Value;
                            rowIndex = rowIndex + 1;
                        }
                    }
                   
                }
                program.Save("Program.xml");
                listBoxInfo.Items.Add("Список отсортирован по времени.");
                CreateProgram(program);
                    
            }
            ex.Dispose();
        }

        private void CreateProgram(XmlDocument program)
        {
            dataGridViewProgram.Rows.Clear();
            dataGridViewProgram.Columns.Clear();
            dataGridViewProgram.Columns.Add("Number", "№ п/п");
            dataGridViewProgram.Columns["Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewProgram.Columns["Number"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewProgram.Columns.Add("Block", "Блок");
            dataGridViewProgram.Columns["Block"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewProgram.Columns["Block"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewProgram.Columns.Add("Channel", "Канал");
            dataGridViewProgram.Columns["Channel"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewProgram.Columns["Channel"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewProgram.Columns.Add("Delay", "Задержка");
            dataGridViewProgram.Columns["Delay"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewProgram.Columns["Delay"].SortMode = DataGridViewColumnSortMode.NotSortable;
            XmlNodeList nodelst = program.SelectNodes("/Program/Shot");
            XmlNode node;
            int rowIndex = 0;
            int _point = 0;
            for (int i = 1; i <= nodelst.Count; i++)
            {
                if (i == 1)
                {
                    dataGridViewProgram.Rows.Add();
                    node = program.SelectSingleNode("/Program/Shot[@ID = " + i + "]");
                    dataGridViewProgram.Rows[rowIndex].Cells["Number"].Value = rowIndex + 1;
                    dataGridViewProgram.Rows[rowIndex].Cells["Block"].Value = node.Attributes["Block"].Value;
                    dataGridViewProgram.Rows[rowIndex].Cells["Channel"].Value = node.Attributes["Channel"].Value;
                    dataGridViewProgram.Rows[rowIndex].Cells["Delay"].Value = Int32.Parse(node.InnerText);
                    _point = Int32.Parse(node.InnerText);
                    rowIndex = rowIndex + 1;
                }
                else
                {
                    node = program.SelectSingleNode("/Program/Shot[@ID = " + i + "]");
                    if (Int32.Parse(node.InnerText) - _point != 0)
                    {
                        dataGridViewProgram.Rows.Add();
                        dataGridViewProgram.Rows[rowIndex].Cells["Number"].Value = rowIndex + 1;
                        dataGridViewProgram.Rows[rowIndex].Cells["Block"].Value = node.Attributes["Block"].Value;
                        dataGridViewProgram.Rows[rowIndex].Cells["Channel"].Value = node.Attributes["Channel"].Value;
                        dataGridViewProgram.Rows[rowIndex].Cells["Delay"].Value = Int32.Parse(node.InnerText) - _point;
                        _point = Int32.Parse(node.InnerText);
                        rowIndex = rowIndex + 1;
                    }
                }
            }
            listBoxInfo.Items.Add("Программа для пульта созданна");
            listBoxInfo.SelectedIndex = listBoxInfo.Items.Count - 1;
            buttonCountPiro.Enabled = true;
            buttonCreateProgram.Enabled = false;
            button100Channel.Enabled = true;
            
        }

        private void CreateProgram100(XmlDocument program, XmlDocument table)
        {
            dataGridViewProgram.Rows.Clear();
            dataGridViewProgram.Columns.Clear();
            dataGridViewProgram.Columns.Add("Number", "№ п/п");
            dataGridViewProgram.Columns["Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewProgram.Columns["Number"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewProgram.Columns.Add("BlockChannel", "Блок | Канал");
            dataGridViewProgram.Columns["BlockChannel"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewProgram.Columns["BlockChannel"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewProgram.Columns.Add("Delay", "Задержка");
            dataGridViewProgram.Columns["Delay"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewProgram.Columns["Delay"].SortMode = DataGridViewColumnSortMode.NotSortable;
            XmlNodeList nodelst = program.SelectNodes("/Program/Shot");
            XmlNode node, nodetbl;
            int rowIndex = 0;
            int _point = 0;

            for (int i = 1; i <= nodelst.Count; i++)
            {
                if (i == 1)
                {
                    dataGridViewProgram.Rows.Add();
                    node = program.SelectSingleNode("/Program/Shot[@ID = " + i + "]");
                    dataGridViewProgram.Rows[rowIndex].Cells["Number"].Value = rowIndex + 1;
                    if (int.Parse(node.Attributes["Block"].Value) > 10)
                    {
                        rowIndex = -1;
                        break;
                    }
                    nodetbl = table.SelectSingleNode("/Settings/BlockChannel[@Block = " + node.Attributes["Block"].Value + " and @Channel = " + node.Attributes["Channel"].Value + "]");
                    dataGridViewProgram.Rows[rowIndex].Cells["BlockChannel"].Value = nodetbl.Attributes["BC"].Value;
                    dataGridViewProgram.Rows[rowIndex].Cells["Delay"].Value = Int32.Parse(node.InnerText);
                    _point = Int32.Parse(node.InnerText);
                    rowIndex = rowIndex + 1;
                }
                else
                {
                    node = program.SelectSingleNode("/Program/Shot[@ID = " + i + "]");
                    if (Int32.Parse(node.InnerText) - _point != 0)
                    {
                        dataGridViewProgram.Rows.Add();
                        dataGridViewProgram.Rows[rowIndex].Cells["Number"].Value = rowIndex + 1;
                        if (int.Parse(node.Attributes["Block"].Value) > 10)
                        {
                            rowIndex = -1;
                            break;
                        }
                        nodetbl = table.SelectSingleNode("/Settings/BlockChannel[@Block = " + node.Attributes["Block"].Value + " and @Channel = " + node.Attributes["Channel"].Value + "]");
                        dataGridViewProgram.Rows[rowIndex].Cells["BlockChannel"].Value = nodetbl.Attributes["BC"].Value;
                        dataGridViewProgram.Rows[rowIndex].Cells["Delay"].Value = Int32.Parse(node.InnerText) - _point;
                        _point = Int32.Parse(node.InnerText);
                        rowIndex = rowIndex + 1;
                        if (rowIndex > 99)
                        {
                            rowIndex = -1;
                            break;
                        }
                    }
                }
            }
            if (rowIndex != -1)
            {
                listBoxInfo.Items.Add("Программа для 100-канального пульта созданна");
                listBoxInfo.SelectedIndex = listBoxInfo.Items.Count - 1;
                buttonCountPiro.Enabled = true;
                buttonCreateProgram.Enabled = true;
                button100Channel.Enabled = false;
            }
            else
            {
                dataGridViewProgram.Rows.Clear();
                listBoxInfo.Items.Add("Ошибка");
                listBoxInfo.Items.Add("Программа расчитана больше чем на 100 каналов");
                listBoxInfo.SelectedIndex = listBoxInfo.Items.Count - 1;
                buttonCreateProgram.Enabled = true;
                buttonCountPiro.Enabled = true;
            }
            

        }

        private void DeleteRows()
        {
            dataGridViewMount.Rows.Clear();
        }
        
        private void DelFiles()
        {
            DirectorySearcher searcher = new DirectorySearcher();
            searcher.SearchDirectory(System.Windows.Forms.Application.StartupPath,"*_Console.xml", SearchOption.TopDirectoryOnly);
            if (searcher.Ошибка == null & searcher.СписокФайлов != null)
            {
                
                for (int i = 0; i < searcher.СписокФайлов.Count(); i++)
                {
                    File.Delete(searcher.СписокФайлов[i]);
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DelFiles();
        }

        private void buttonSaveTxt_Click(object sender, EventArgs e)
        {
            if (buttonCreateProgram.Enabled == false)
            {
                saveFileDialog1.Filter = "Текст|*.txt";
                saveFileDialog1.DefaultExt = "txt";
                saveFileDialog1.Title = "Сохранить текстовую программу";
                saveFileDialog1.FileName = "Program";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    WriteToLogFile(saveFileDialog1.FileName);
                    listBoxInfo.Items.Add("Файл создан: " + saveFileDialog1.FileName);
                }
            }
            if (buttonCountPiro.Enabled == false)
            {
                saveFileDialog1.Filter = "Excel 2003|*.xls|Excel 2007|*.xlsx";
                saveFileDialog1.DefaultExt = "xls";
                saveFileDialog1.Title = "Сохранить файл с количеством зарядов";
                saveFileDialog1.FileName = "Quantity";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    SaveExcel(saveFileDialog1.FileName);
                    listBoxInfo.Items.Add("Файл создан: " + saveFileDialog1.FileName);
                }
            }
            if (button100Channel.Enabled == false)
            {
                saveFileDialog1.Filter = "Текст|*.txt";
                saveFileDialog1.DefaultExt = "txt";
                saveFileDialog1.Title = "Сохранить текстовую программу";
                saveFileDialog1.FileName = "Program100";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    WriteToFile100(saveFileDialog1.FileName);
                    listBoxInfo.Items.Add("Файл создан: " + saveFileDialog1.FileName);
                }
            }
        }

        /// <summary>
        /// Записывает сообщение в файл указанный в ПутьиИмяФайла
        /// </summary>
        /// <param name="ПутьиИмяФайла">Путь и Имя файла в который необходимо записать сообщение. 
        /// Например: C:\TEMP\AlarmDog.log  для записи в каталог C:\TEMP
        /// или AlarmDog.log для записи в каталог расположения программы.</param>
        /// <param name="Сообщение">Текст сообщения которое необходимо записать.</param>
        public void WriteToLogFile(string ПутьиИмяФайла)
        {
            string block = "Блок: ", channel = "Канал: ", delay = "Задержка: ", quantity = "";
            string milisec = "", sec="", min="", h="";
            int time = 0;
            for (int i = 0; i < dataGridViewProgram.Rows.Count; i++)
            {
                block = block + dataGridViewProgram.Rows[i].Cells["Block"].Value + ",";
                channel = channel + dataGridViewProgram.Rows[i].Cells["Channel"].Value + ",";
                delay = delay + dataGridViewProgram.Rows[i].Cells["Delay"].Value + ",";
                time = time + int.Parse(dataGridViewProgram.Rows[i].Cells["Delay"].Value.ToString());
            }
            quantity = "Кол-во шагов: " + dataGridViewProgram.Rows.Count.ToString();
            
            
            h = (time/360000).ToString();
            if (int.Parse(h) > 0)
            {
                time = time - (int.Parse(h) * 360000);
            }
            min = (time / 6000).ToString();
            if (int.Parse(min) > 0)
            {
                time = time - (int.Parse(min) * 6000);
            }
            sec = (time / 100).ToString();
            if (int.Parse(sec) > 0)
            {
                time = time - (int.Parse(sec) * 100);
            }
            milisec = time.ToString();
            h = "Время фейерверка: " + h + " часов " + min + " минут " + sec + " секунд " + milisec + " милисекунд";
            using (StreamWriter fileWriter = new StreamWriter(ПутьиИмяФайла, false, Encoding.Default))
            {
                fileWriter.WriteLine(h);
                fileWriter.WriteLine(quantity);
                fileWriter.WriteLine(block);
                fileWriter.WriteLine(channel);
                fileWriter.WriteLine(delay);
            }
        }

        public void WriteToFile100(string ПутьиИмяФайла)
        {
            string blockChannel = "БлокКанал: ", delay = "Задержка: ", quantity = "";
            string milisec = "", sec = "", min = "", h = ""; ;
            int time = 0;
            for (int i = 0; i < dataGridViewProgram.Rows.Count; i++)
            {
                blockChannel = blockChannel + dataGridViewProgram.Rows[i].Cells["BlockChannel"].Value + ",";
                
                delay = delay + dataGridViewProgram.Rows[i].Cells["Delay"].Value + ",";
                time = time + int.Parse(dataGridViewProgram.Rows[i].Cells["Delay"].Value.ToString());
            }
            quantity = "Кол-во шагов: " + dataGridViewProgram.Rows.Count.ToString();
            milisec = time.ToString().Substring(time.ToString().Length - 2);
            h = (time / 360000).ToString();
            if (int.Parse(h) > 0)
            {
                time = time - (int.Parse(h) * 360000);
            }
            min = (time / 6000).ToString();
            if (int.Parse(min) > 0)
            {
                time = time - (int.Parse(min) * 6000);
            }
            sec = time.ToString().Substring(0, 2);
            h = "Время фейерверка: " + h + " часов " + min + " минут " + sec + " секунд " + milisec + " милисекунд";
            using (StreamWriter fileWriter = new StreamWriter(ПутьиИмяФайла, false, Encoding.Default))
            {
                fileWriter.WriteLine(h);
                fileWriter.WriteLine(quantity);
                fileWriter.WriteLine(blockChannel);
                
                fileWriter.WriteLine(delay);
            }
        }

        private void CountPiro(XmlDocument program)
        {
            XmlNodeList nodelst = program.SelectNodes("/Program/Shot");
            string[] names = new string[1];
            names[0] = "start";
            string[] calibers = new string[1];
            calibers[0] = "start";
            string[] nametmp = new string[1];
            nametmp[0] = "";
            
            foreach (XmlNode node in nodelst)
            {
                nametmp[0] = node.Attributes["Name"].Value;
                names = names.Concat(nametmp).ToArray();
                nametmp[0] = node.Attributes["Caliber"].Value;
                calibers = calibers.Concat(nametmp).ToArray();
            }
            names = names.Skip(1).ToArray();
            names = names.Distinct().ToArray();
            calibers = calibers.Skip(1).ToArray();
            calibers = calibers.Distinct().ToArray();
            dataGridViewProgram.Rows.Clear();
            dataGridViewProgram.Columns.Clear();
            dataGridViewProgram.Columns.Add("Number", "№ п/п");
            dataGridViewProgram.Columns["Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewProgram.Columns["Number"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewProgram.Columns.Add("Caliber", "Калибр");
            dataGridViewProgram.Columns["Caliber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewProgram.Columns["Caliber"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewProgram.Columns.Add("Name", "Название");
            dataGridViewProgram.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewProgram.Columns["Name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewProgram.Columns.Add("Quantity", "Количество");
            dataGridViewProgram.Columns["Quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewProgram.Columns["Quantity"].SortMode = DataGridViewColumnSortMode.NotSortable;

            int summ = 0;
            for (int j = 0; j< calibers.Count(); j++)
            {
                for (int i = 0; i < names.Count(); i++)
                {
                    int count = 0;
                    
                    foreach (XmlNode node in nodelst)
                    {
                        if (names[i] == node.Attributes["Name"].Value & calibers[j] == node.Attributes["Caliber"].Value)
                        {
                            count = count + 1;
                        }
                    }
                    if (count != 0)
                    {
                        dataGridViewProgram.Rows.Add();
                        int rowIndex = dataGridViewProgram.Rows.Count - 1;
                        dataGridViewProgram.Rows[rowIndex].Cells["Number"].Value = rowIndex + 1;
                        dataGridViewProgram.Rows[rowIndex].Cells["Caliber"].Value = calibers[j];
                        dataGridViewProgram.Rows[rowIndex].Cells["Name"].Value = names[i];
                        dataGridViewProgram.Rows[rowIndex].Cells["Quantity"].Value = count.ToString() + " шт.";
                        summ = summ + count;
                    }
                }
            }
            listBoxInfo.Items.Add("Заряды подсчитаны");
            listBoxInfo.Items.Add("Всего " + names.Count() + " разновидностей");
            listBoxInfo.Items.Add("Всего " + summ + " шт. зарядов");
            listBoxInfo.SelectedIndex = listBoxInfo.Items.Count - 1;
            buttonCountPiro.Enabled = false;
            buttonCreateProgram.Enabled = true;
            button100Channel.Enabled = true;

            
        }

        private void buttonCountPiro_Click(object sender, EventArgs e)
        {
            XmlDocument program = new XmlDocument();
            program.Load("Program.xml");
            CountPiro(program);
        }

        private void buttonCreateProgram_Click(object sender, EventArgs e)
        {
            XmlDocument program = new XmlDocument();
            program.Load("Program.xml");
            CreateProgram(program);
        }

        private void SaveExcel(string PathFileName)
        {
            Excel ex = new Excel();
            System.Globalization.CultureInfo info = System.Globalization.CultureInfo.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            ex.NewDocument();
            ex.AddNewPage("Заряды");
            for (int i = 0; i < dataGridViewProgram.Rows.Count; i++)
            {
                ex.SetValue("A" + (i + 1).ToString(), dataGridViewProgram.Rows[i].Cells["Number"].Value.ToString());
                ex.SetValue("B" + (i + 1).ToString(), dataGridViewProgram.Rows[i].Cells["Caliber"].Value.ToString());
                ex.SetValue("C" + (i + 1).ToString(), dataGridViewProgram.Rows[i].Cells["Name"].Value.ToString());
                ex.SetValue("D" + (i + 1).ToString(), dataGridViewProgram.Rows[i].Cells["Quantity"].Value.ToString());
            }
            ex.SaveDocument(PathFileName);
            ex.CloseDocument();
            System.Threading.Thread.CurrentThread.CurrentCulture = info;
            ex.Dispose();

        }

        private void button100Channel_Click(object sender, EventArgs e)
        {
            XmlDocument program = new XmlDocument();
            program.Load("Program.xml");
            XmlDocument table = new XmlDocument();
            table.Load("Megatron.xml");
            CreateProgram100(program, table);
        }

        

    }
}
