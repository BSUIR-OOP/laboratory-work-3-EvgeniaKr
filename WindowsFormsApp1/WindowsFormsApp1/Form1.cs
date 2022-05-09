using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Class;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<ListFigures> FiguresList = new List<ListFigures>();
        IEnumerable<Type> FiguresTypes;
        public Form1()
        {
            InitializeComponent();
            FiguresTypes = typeof(ListFigures).Assembly.ExportedTypes.Where(t => typeof(ListFigures).IsAssignableFrom(t) && t != typeof(ListFigures));
           // comboBox1.Items.Add(FiguresTypes[1].Name);
            foreach (var i in FiguresTypes)
            {
                comboBox1.Items.Add(i.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string NameType = "WindowsFormsApp1.Class." + comboBox1.SelectedItem;
            Type Type = Type.GetType(NameType, false, true);

            System.Reflection.ConstructorInfo f = Type.GetConstructor(new Type[] { });
            ListFigures figure = (ListFigures)f.Invoke(new object[] { });

            figure.P = Int32.Parse(textBox1.Text);
            figure.S = Int32.Parse(textBox2.Text);
            figure.Name = comboBox1.Text;

            FiguresList.Add(figure);
            listBox1.Items.Add(figure.Name);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var item in FiguresList)
            {
                if (listBox1.SelectedItem.ToString() == item.Name)
                {
                    comboBox1.SelectedItem = item.GetType().Name;
                    comboBox1.Text = item.Name;
                    textBox1.Text = item.P.ToString();
                    textBox2.Text = item.S.ToString();
                    return;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var item in FiguresList)
            {
                if (listBox1.SelectedItem.ToString() == item.Name)
                {
                    FiguresList.Remove(item);
                    listBox1.Items.RemoveAt(listBox1.Items.IndexOf(item.Name));
                    return;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (FileStream fileStream = new FileStream("file.bin", FileMode.OpenOrCreate))
            {
                IFormatter formatter = new BinaryFormatter();

                formatter.Serialize(fileStream, FiguresList);
                FiguresList.Clear();
                listBox1.Items.Clear();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (FileStream fileStream = new FileStream("file.bin", FileMode.OpenOrCreate))
            {
                IFormatter formatter = new BinaryFormatter();

                FiguresList = formatter.Deserialize(fileStream) as List<ListFigures>;
                foreach (var item in FiguresList)
                {
                    listBox1.Items.Add(item.Name);
                }

            }
        }
    }
}
