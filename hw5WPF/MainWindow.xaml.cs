using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace hw5WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Calculator calculator;

		public MainWindow()
		{
			InitializeComponent();
			calculator = new Calculator();
			calculator.Result += Calculator_Result;

		}

		private void Calculator_Result(object? sender, CalculatorArgs e)
		{
			Answer.Content = e.answer;
		}

		private void Back_Click(object sender, RoutedEventArgs e)
		{
			calculator.Cancel();
			InputText.Text = string.Empty;
		}

		private void Remove_Click(object sender, RoutedEventArgs e)
		{
			string str = InputText.Text;
			if (str.Length > 0)
			{
				
				str = str.Remove(str.Length - 1);
				
				InputText.Text = str;
			}
		}
		private void Clear_Click(object sender, RoutedEventArgs e)
		{
			calculator.Clear();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			string name = (e.Source as FrameworkElement).Name;

			string data = InputText.Text;
			int val = 0;

			if (int.TryParse(data, out val))
            {
				switch (name)
				{
					case "Add":
						calculator.Add(val);
						InputText.Text = string.Empty;
						break;
					case "Sub":
						calculator.Sub(val);
						InputText.Text = string.Empty;
						break;
					case "Mult":
						calculator.Mult(val);
						InputText.Text = string.Empty;
						break;
					case "Div":
						calculator.Div(val);
						InputText.Text = string.Empty;
						break;
					default:
						Answer.Content = "Jib,rf 404";
						InputText.Text = string.Empty;
						break;

				}
				
			}
			else
			{
				Answer.Content = "Введите цифру";
				InputText.Text = string.Empty;
			}


		}


		private void InputText_TextChanged(object sender, TextChangedEventArgs e)
		{
			
			string str = InputText.Text;
            if (str.Length > 0)
            {
				char last = str[str.Length - 1];
				if (last < '0' || last > '9')
				{
					str = str.Remove(str.Length - 1);
				}
				InputText.Text = str;
			}
			
            
        }

		
	}
}