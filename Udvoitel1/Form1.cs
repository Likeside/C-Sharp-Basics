using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Udvoitel.Model;

//Зиновьев А.А.
/*1. а) Добавить в программу «Удвоитель» подсчет количества отданных команд.
б) Добавить меню и команду «Играть». При нажатии появляется сообщение, какое число должен получить игрок. Игрок должен постараться получить это число за минимальное количество ходов.
в) * Добавить кнопку «Отменить», которая отменяет последние ходы.
*/
namespace Udvoitel
{
    public partial class Form1 : Form
    {
        GameDoubler game;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show(DateTime.Now.ToLongTimeString());
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?","Warning",MessageBoxButtons.YesNo)==DialogResult.Yes)  this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            game = new GameDoubler();
            game.action += UpdateInfo;
            UpdateInfo();
            btnMulti.Enabled = true;
            btnPlus.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            
        }

        void UpdateInfo()
        {
            lblCount.Text = "Ходов сделано: " + game.Count.ToString();
            lblCurrent.Text = "Ваше число: " + game.Current.ToString();
            lblFinish.Text = "Вам нужно получить число " + game.Finish.ToString();
            lblTotalMoves.Text = "Всего действий предпринято: " + game.TotalMoves.ToString();
            lblMinSteps.Text = "Минимальное количество хоодов: " + game.Steps.ToString();

            if (game.Current == game.Finish && game.Count == game.Steps)
            {
                lblWinLose.Text = "Вы победили";
            }
            else if (game.Count > game.Steps)
            {
                lblWinLose.Text = "Вы проиграли";
            }
            else
            {
                lblWinLose.Text = "Вы пока не победили и не проиграли";
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            game.Plus();
            
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            game.Multi();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            game.Back();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            game.Reset();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exchange.Current = game.Current;
            formAbout about = new formAbout();
            about.ShowDialog();
        }

      
    }
}
