using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIS_PRO
{
    public partial class MainWindow : Form
    {
        private int TEMPORARY_NUMBER;
        public MainWindow()
        {
            TEMPORARY_NUMBER = 0;
            InitializeComponent();
        }

        private void Start_Button_Click(object sender, EventArgs e)
        {
            TEMPORARY_NUMBER++;
            LogTextBox.Clear();
            EvolutionAlgorithm Algorithm = new EvolutionAlgorithm(Convert.ToInt32(NumberOfChanelsBox.Value));
            try
            {
                Algorithm.FindBestSolution();
                LogTextBox.AppendText(Algorithm.PrintResult());
            }catch(NotImplementedException Ex)
            {
                LogTextBox.AppendText("NIE ZAIMPLEMENTOWANO: " + Ex.Message + Environment.NewLine);
                LogTextBox.AppendText("Przykładowy wynik " + TEMPORARY_NUMBER.ToString() + Environment.NewLine);
                LogTextBox.AppendText("Dla 10 kanałów" + Environment.NewLine);
                LogTextBox.AppendText("Ilość iteracji dużych: 12" + Environment.NewLine);
                LogTextBox.AppendText("Ilość iteracji małych dających poprawny wynik: 100052" + Environment.NewLine);
                LogTextBox.AppendText("Szerokość siatki: 78" + Environment.NewLine);
                LogTextBox.AppendText("Minimalny wynik mieszania: -76" + Environment.NewLine);
                LogTextBox.AppendText("MAksymalny wynik mieszania: 144" + Environment.NewLine);
                LogTextBox.AppendText("Zajęte kanały:" + Environment.NewLine);
                LogTextBox.AppendText("0 2 9 14 28 33 54 58 66 78" + Environment.NewLine);
                LogTextBox.AppendText("//wartości przypadkowe" + Environment.NewLine);
            }
        }
    }
}
