using System;
using System.Collections.Generic;
using System.Data;
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

namespace calc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable table = new DataTable();
        string Example;
        public MainWindow()
        {
            InitializeComponent();
            rb2.IsChecked = true;
        }

        private void rb1_Checked(object sender, RoutedEventArgs e)
        {
            if (Example != null && Example != string.Empty)
            {
                for (int i = 0; i < Example.Length; i++)
                {
                    if (Example[i] == '.')
                    {
                        Example = Example.Replace(".", ",");
                    }
                }
                Example = ((Convert.ToDouble(Example) * 180) / Math.PI).ToString();
                for (int i = 0; i < Example.Length; i++)
                {
                    if (Example[i] == ',')
                    {
                        Example = Example.Replace(",", ".");
                    }
                }
                Field.Text = Example;
            }
        }

        private void btn_7_Click(object sender, RoutedEventArgs e)
        {
            if (Example == null && ((sender as Button).Content.ToString() == "+" || (sender as Button).Content.ToString() == "*" || (sender as Button).Content.ToString() == "/" || (sender as Button).Content.ToString() == "%" || (sender as Button).Content.ToString() == "."))
            {
                Example = null;
                Field.Text = Example;
                return;
            }
            Example += (sender as Button).Content;
            Field.Text = Example;
        }

        private void btn_Result_Click(object sender, RoutedEventArgs e)
        {
            //Field.Text = new DataTable.Compute(Field.Text, null);

            if (Example != null && Example != string.Empty)
            {
                IsValid(Example);
                if (IsValid(Example) == true)
                {
                    if (Example[Example.Length - 1] == '+' || Example[Example.Length - 1] == '*' || Example[Example.Length - 1] == '/' || Example[Example.Length - 1] == '%' || Example[0] == '/'
                        || Example[0] == '+' || Example[0] == '-' || Example[0] == '*' || Example[0] == '%')
                    {
                        return;
                    }
                    //for (int i = 0; i < Example.Length; i++)
                    //{
                    //    if (Example[i] == '.')
                    //    {
                    //        return;
                    //    }
                    //}
                    if (Example[Example.Length-2] == '/' && Example[Example.Length-1] == '0')
                    {
                        ErrorWindow win = new ErrorWindow();
                        win.Show();
                        Example = string.Empty;
                        Field.Text = Example;
                    }
                    Example = (table.Compute(Example, null)).ToString();
                    for (int i = 0; i < Example.Length; i++)
                    {
                        if (Example[i] == ',')
                        {
                            Example = Example.Replace(",", ".");
                        }
                    }
                    //Field.Text = (table.Compute(Field.Text, null)).ToString();
                    Field.Text = Example;
                }
                else
                {
                    MessageBox.Show("Не введено нужное кол-во скобок!");
                    return;
                }
            }
        }



        private void btn_CE_Click(object sender, RoutedEventArgs e)
        {
            Example = null;
            SqrtY.Text = null;
            PowY.Text = null;
            Field.Text = Example;
        }

        private void btn_sin_Click(object sender, RoutedEventArgs e)
        {
            if (Example != null && Example != string.Empty)
            {
                if (Example == null || Example[0] == '+')
                {
                    Example = null;
                    Field.Text = Example;
                    return;
                }
                for (int i = 0; i < Example.Length; i++)
                {
                    if (Example[i] == '.')
                    {
                        Example = Example.Replace(".", ",");
                    }
                }
                Example = (Math.Sin(Convert.ToDouble(Example))).ToString();
                for (int i = 0; i < Example.Length; i++)
                {
                    if (Example[i] == ',')
                    {
                        Example = Example.Replace(",", ".");
                    }
                }
                Field.Text = Example;
            }

        }

        private void btn_ln_Click(object sender, RoutedEventArgs e)
        {
            if (Example != null && Example != string.Empty)
            {
                for (int i = 0; i < Example.Length; i++)
                {
                    if (Example[i] == '.')
                    {
                        Example = Example.Replace(".", ",");
                    }
                }
                Example = (Math.Log10(Convert.ToDouble(Example))).ToString();
                for (int i = 0; i < Example.Length; i++)
                {
                    if (Example[i] == ',')
                    {
                        Example = Example.Replace(",", ".");
                    }
                }
                Field.Text = Example;
            }

        }

        private void btn_cos_Click(object sender, RoutedEventArgs e)
        {
            if (Example != null && Example != string.Empty)
            {
                for (int i = 0; i < Example.Length; i++)
                {
                    if (Example[i] == '.')
                    {
                        Example = Example.Replace(".", ",");
                    }
                }
                Example = (Math.Cos(Convert.ToDouble(Example))).ToString();
                for (int i = 0; i < Example.Length; i++)
                {
                    if (Example[i] == ',')
                    {
                        Example = Example.Replace(",", ".");
                    }
                }
                Field.Text = Example;
            }

        }

        private void btn_cosh_Click(object sender, RoutedEventArgs e)
        {
            if (Example != null && Example != string.Empty)
            {
                for (int i = 0; i < Example.Length; i++)
                {
                    if (Example[i] == '.')
                    {
                        Example = Example.Replace(".", ",");
                    }
                }
                Example = (Math.Cosh(Convert.ToDouble(Example))).ToString();
                for (int i = 0; i < Example.Length; i++)
                {
                    if (Example[i] == ',')
                    {
                        Example = Example.Replace(",", ".");
                    }
                }
                Field.Text = Example;
            }

        }

        private void btn_sinh_Click(object sender, RoutedEventArgs e)
        {
            if (Example != null && Example != string.Empty)
            {
                for (int i = 0; i < Example.Length; i++)
                {
                    if (Example[i] == '.')
                    {
                        Example = Example.Replace(".", ",");
                    }
                }
                Example = (Math.Sinh(Convert.ToDouble(Example))).ToString();
                for (int i = 0; i < Example.Length; i++)
                {
                    if (Example[i] == ',')
                    {
                        Example = Example.Replace(",", ".");
                    }
                }
                Field.Text = Example;
            }

        }

        private void btn_tan_Click(object sender, RoutedEventArgs e)
        {
            if (Example != null && Example != string.Empty)
            {
                for (int i = 0; i < Example.Length; i++)
                {
                    if (Example[i] == '.')
                    {
                        Example = Example.Replace(".", ",");
                    }
                }
                Example = (Math.Tan(Convert.ToDouble(Example))).ToString();
                for (int i = 0; i < Example.Length; i++)
                {
                    if (Example[i] == ',')
                    {
                        Example = Example.Replace(",", ".");
                    }
                }
                Field.Text = Example;
            }

        }

        private void btn_tanh_Click(object sender, RoutedEventArgs e)
        {
            if (Example != null && Example != string.Empty)
            {
                for (int i = 0; i < Example.Length; i++)
                {
                    if (Example[i] == '.')
                    {
                        Example = Example.Replace(".", ",");
                    }
                }
                Example = (Math.Tanh(Convert.ToDouble(Example))).ToString();
                for (int i = 0; i < Example.Length; i++)
                {
                    if (Example[i] == ',')
                    {
                        Example = Example.Replace(",", ".");
                    }
                }
                Field.Text = Example;
            }

        }

        private void btn_Sqrt_Click(object sender, RoutedEventArgs e)
        {
            if (Example != null && Example != string.Empty)
            {
                for (int i = 0; i < Example.Length; i++)
                {
                    if (Example[i] == '.')
                    {
                        Example = Example.Replace(".", ",");
                    }
                }
                Example = (Math.Sqrt(Convert.ToDouble(Example))).ToString();
                for (int i = 0; i < Example.Length; i++)
                {
                    if (Example[i] == ',')
                    {
                        Example = Example.Replace(",", ".");
                    }
                }
                Field.Text = Example;
            }

        }

        private void btn_10x_Click(object sender, RoutedEventArgs e)
        {
            if (Example != null && Example != string.Empty)
            {
                for (int i = 0; i < Example.Length; i++)
                {
                    if (Example[i] == '.')
                    {
                        Example = Example.Replace(".", ",");
                    }
                }
                Example = (Math.Pow(10, Convert.ToDouble(Example))).ToString();
                for (int i = 0; i < Example.Length; i++)
                {
                    if (Example[i] == ',')
                    {
                        Example = Example.Replace(",", ".");
                    }
                }
                Field.Text = Example;
            }
        }


        private void btn_x3_Click(object sender, RoutedEventArgs e)
        {
            if (Example != null && Example != string.Empty)
            {
                for (int i = 0; i < Example.Length; i++)
                {
                    if (Example[i] == '.')
                    {
                        Example = Example.Replace(".", ",");
                    }
                }
                Example = (Math.Pow(Convert.ToDouble(Example), 3)).ToString();
                for (int i = 0; i < Example.Length; i++)
                {
                    if (Example[i] == ',')
                    {
                        Example = Example.Replace(",", ".");
                    }
                }
                Field.Text = Example;
            }

        }

        private void btn_x2_Click(object sender, RoutedEventArgs e)
        {
            if (Example != null && Example != string.Empty)
            {
                for (int i = 0; i < Example.Length; i++)
                {
                    if (Example[i] == '.')
                    {
                        Example = Example.Replace(".", ",");
                    }
                }
                Example = (Math.Pow(Convert.ToDouble(Example), 2)).ToString();
                for (int i = 0; i < Example.Length; i++)
                {
                    if (Example[i] == ',')
                    {
                        Example = Example.Replace(",", ".");
                    }
                }
                Field.Text = Example;
            }

        }

        private void btn_n_Click(object sender, RoutedEventArgs e)
        {
            if (Example != null && Example != string.Empty)
            {
                if (Example.Contains('+') || (Example.Contains('-') && Example[0] != '-') || Example.Contains('*') || Example.Contains('/'))
                {
                    Example = (table.Compute(Example, null)).ToString();
                }
                for (int i = 0; i < Example.Length; i++)
                {
                    if (Example[i] == '.' || Example[i] == ',')
                    {
                        MessageBox.Show("Нельзя найти факториал чисел типа double!");
                        return;
                    }
                }
                double n = double.Parse(Example);
                double factorial = 1;
                for (int i = 1; i <= n; i++)
                {
                    factorial = factorial * i;

                }

                Example = factorial.ToString();
                Field.Text = Example;
            }

        }

        private void btn_Exp_Click(object sender, RoutedEventArgs e)
        {
            if (Example != null && Example != string.Empty)
            {
                for (int i = 0; i < Example.Length; i++)
                {
                    if (Example[i] == '.')
                    {
                        Example = Example.Replace(".", ",");
                    }
                }
                Example = (Math.Exp(Convert.ToDouble(Example))).ToString();
                for (int i = 0; i < Example.Length; i++)
                {
                    if (Example[i] == ',')
                    {
                        Example = Example.Replace(",", ".");
                    }
                }
                Field.Text = Example;
            }

        }

        private void btn_NumberP_Click(object sender, RoutedEventArgs e)
        {
            Example = Math.PI.ToString();
            for (int i = 0; i < Example.Length; i++)
            {
                if (Example[i] == ',')
                {
                    Example = Example.Replace(",", ".");
                }
            }
            Field.Text = Example;
        }

        private void btn_Mod_Click(object sender, RoutedEventArgs e)
        {
            if (Example != null && Example != string.Empty)
            {
                Example = Example.Replace("-", "");
                Field.Text = Example;
            }

        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            if (Example != null && Example != string.Empty)
            {
                Example = Example.Remove(Example.Length - 1);
                Field.Text = Example;
            }

        }

        private void btn_1divX_Click(object sender, RoutedEventArgs e)
        {
            if (Example != null && Example != string.Empty)
            {
                Example = (table.Compute($"1/{Example}", null)).ToString();
                for (int i = 0; i < Example.Length; i++)
                {
                    if (Example[i] == ',')
                    {
                        Example = Example.Replace(",", ".");
                    }
                }
                Field.Text = Example;
                Example = null;
            }

        }

        private void btn_PlusMinus_Click(object sender, RoutedEventArgs e)
        {
            if (Example != null && Example != string.Empty)
            {
                if (Example[0] != '-')
                {
                    Example = '-' + Example;
                    Field.Text = Example;

                }
                else
                {

                    Example = Example.Replace("-", "");
                    Field.Text = Example;
                }
            }

        }

        private void btn_SqrtYX_Click(object sender, RoutedEventArgs e)
        {
            if (Example != null && Example != string.Empty)
            {
                if (SqrtY.Text != null && SqrtY.Text != string.Empty)
                {
                    Example = Math.Pow(Convert.ToDouble(Example), Convert.ToDouble(table.Compute($"1/{SqrtY.Text}", null))).ToString();
                    for (int i = 0; i < Example.Length; i++)
                    {
                        if (Example[i] == ',')
                        {
                            Example = Example.Replace(",", ".");
                        }
                    }
                    Field.Text = Example;
                }

                else
                {
                    return;
                }
            }

        }

        private void btn_Sqrt3X_Click(object sender, RoutedEventArgs e)
        {
            if (Example != null && Example != string.Empty)
            {
                Example = Math.Pow(Math.Sqrt(Convert.ToDouble(Example)), 3).ToString();
                for (int i = 0; i < Example.Length; i++)
                {
                    if (Example[i] == ',')
                    {
                        Example = Example.Replace(",", ".");
                    }
                }
                Field.Text = Example;
            }

        }

        private void btn_xy_Click(object sender, RoutedEventArgs e)
        {
            if (Example != null && Example != string.Empty)
            {
                if (PowY.Text != null && PowY.Text != string.Empty)
                {
                    if (Convert.ToDouble(PowY.Text) < 0)
                    {
                        Example = table.Compute($"1/{Math.Pow(Convert.ToDouble(Example), -Convert.ToDouble((PowY.Text)))}", null).ToString();
                    }

                    else if (Convert.ToDouble(PowY.Text) > 0)
                    {
                        Example = Math.Pow(Convert.ToDouble(Example), Convert.ToDouble(PowY.Text)).ToString();
                    }

                    else
                    {
                        Example = Math.Pow(Convert.ToDouble(Example), Convert.ToDouble(PowY.Text)).ToString();
                    }

                    for (int i = 0; i < Example.Length; i++)
                    {
                        if (Example[i] == ',')
                        {
                            Example = Example.Replace(",", ".");
                        }
                    }
                    Field.Text = Example;
                }

                else
                {
                    return;
                }
            }

        }

        private void btn_log_Click(object sender, RoutedEventArgs e)
        {
            if (Example != null && Example != string.Empty)
            {
                Example = Math.Log(Convert.ToDouble(Example)).ToString();
                for (int i = 0; i < Example.Length; i++)
                {
                    if (Example[i] == ',')
                    {
                        Example = Example.Replace(",", ".");
                    }
                }
                Field.Text = Example;
            }

        }

        private void rb2_Checked(object sender, RoutedEventArgs e)
        {
            if (Example != null && Example != string.Empty)
            {
                Example = ((Convert.ToDouble(Example) * Math.PI) / 180).ToString();
                Field.Text = Example;
            }
        }

        private bool IsValid(string s)
        {
            var count = 0;
            foreach (var c in s)
            {
                if (c == '(')
                {
                    count++;
                }

                if (c == ')')
                {
                    count--;
                }
            }

            if (count == 0)
            {
                count = 0;
                return true;
            }
            else
            {

                return false;
            }
        }
    }
}
