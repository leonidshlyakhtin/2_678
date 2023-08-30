using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _678
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<int> mas = new List<int>();
        Queue<string> StrNums = new Queue<string>();
        LinkedList<int> DoubleNums = new LinkedList<int>();
        int tenCounter = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtInterMass.Text.Length != 0)
            {
                string str = txtInterMass.Text;
                if (str[str.Length - 1] == ',') str = str.Substring(0, str.Length - 1);
                string[] strmas = str.Split(',');
                string res = "";
                foreach (var item in strmas)
                {
                    mas.Add(int.Parse(item));
                    res += item + " ";
                }
                tbMassive.Text = res;
            }
            else
            {
                MessageBox.Show("Введите элементы массива", "Сообщение",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int answer = mas[0];

            for (int i = 1; i < mas.Count; i++)
            {
                if (answer > mas[i]) answer = i;
            }
            tbResult.Text = $"Самое  число под индексом {answer}";
        }

        private void txtInterMass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key == Key.OemComma ||
                e.Key == Key.Back || e.Key == Key.OemMinus)
                return;
            e.Handled = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            mas.Clear();
            txtInterMass.Clear();
            tbMassive.Text = "";
            tbResult.Text = "";
        }

        public void AddButtonClicked(object sender, EventArgs args)
        {

            if (Numbers_7.Text == string.Empty)
            {

            }
            else
            {
                string elem = Numbers_7.Text;
                StrNums.Enqueue(elem);
                userList.Content = $"Ваш список: [{StrNums.GetString()} ]";
            }

        }

        public void DeleteButtonClicked(object sender, EventArgs args)
        {
            StrNums.Dequeue();
            userList.Content = $"Ваш список: [{StrNums.GetString()} ]";

        }

        public void SearchButtonClicked(object sender, EventArgs args)
        {
            string Tstr = "";
            foreach (string elem in StrNums)
            {
                if (elem[0] == 't') Tstr += elem + ' ';

            }

            userList.Content = $"Ваш список: [{StrNums.GetString()} ] {Tstr}";
        }

        public void AddButtonClicked8(object sender, EventArgs args)
        {
            
            if (Numbers_8.Text == string.Empty)
            {

            }
            else
            {
                string elem = Numbers_8.Text;
                int num = 0;
                if (int.TryParse(elem, out num))
                {

                    DoubleNums.Add(num);
                    if (num == 10 && tenCounter == 0)
                    {
                        DoubleNums.Remove(num);
                        tenCounter++;
                    }
                    userList8.Content = $"Ваш список: [{DoubleNums.GetString()} ]";

                }
            }
        }

    }
}
