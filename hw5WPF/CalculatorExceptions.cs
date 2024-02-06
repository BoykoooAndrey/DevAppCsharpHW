using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace hw5WPF
{
	public class CalculatorExceptions : CalculatorArifmetic
	{
		public override void Add(double value)
		{
			try
			{

				base.Add(value);
			}
			
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		public override void Sub(double value)
		{
			try
			{
				base.Sub(value);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		public override void Mult(double value)
		{
			try
			{
				base.Mult(value);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		public override void Div(double value)
		{
			try
			{
				base.Div(value);
			}
			catch (DivideByZeroException e)
			{
				MessageBox.Show(e.Message);
			}
			
		}

		public override void Cancel()
		{
			try
			{
				base.Cancel();
			}
			catch (DivideByZeroException e)
			{
				MessageBox.Show(e.Message);
			}
		}

		public override void Clear()
		{
			try
			{
				base.Clear();
			}
			catch (DivideByZeroException e)
			{
				MessageBox.Show(e.Message);
			}
		}
	}
}
