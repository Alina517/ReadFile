using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace ReadFile
{
    public partial class Form1 : Form
    {
        string readText;//
        string filename1 = "text.txt";//имена входного и выходного файлов
        string filename2 = "result.txt";
        string punctmarks;
        public Form1()
        {
            InitializeComponent();
            StreamReader file = new StreamReader(filename1);//открываем файл для чтения
            readText = file.ReadToEnd();//считываем все данные из файла и записываем в readText
            file.Close();//закрывем файл

            richTextBox1.Text = readText;//выводим считанные данные в textbox
        }

        private void label1_Click(object sender, EventArgs e){}

        private void button1_Click(object sender, EventArgs e)//кнопка ">>>"
        {
            int count = 0;
            for(int i = 0; i < readText.Length; i++)//проходим по считанной строке
            {
                if(char.IsPunctuation(readText[i]))//проверяем, является ли элемент знаком препинания
                {
                    punctmarks += readText[i];//если да, записываем его в новый массив
                    count++;
                }
            }
            //проверка, найдены ли были знаки препинания
            if (count == 0)
                richTextBox2.Text = "Знаки препинания не найдены";
            else
                richTextBox2.Text = punctmarks;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            StreamWriter fileout = new StreamWriter(filename2, false);//открываем файл для записи
            fileout.Write(punctmarks);//запись в файл
            fileout.Close();// закрываем файл
            MessageBox.Show("Данные записаны в файл ", filename2);
        }
    }
}
