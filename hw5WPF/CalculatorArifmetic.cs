using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw5WPF
{
	public class CalculatorArgs : EventArgs
	{
		public double answer;
	}
	public class CalculatorArifmetic
	{
		public event EventHandler<CalculatorArgs> Result;
		
		public double result { get; private set; } = 0;
		Stack<double> results = new Stack<double>();
		private void Calculation()
		{
            
            Result.Invoke(this, new CalculatorArgs { answer = result });
		}

		public virtual void Add(double value)
		{
			results.Push(result);
			result += value;
			Calculation();
		}

		public virtual void Sub(double value)
		{
			results.Push(result);
			result -= value;
			Calculation();
		}
		public virtual void Mult(double value)
		{
			results.Push(result);
			result *= value;
			Calculation();
		}
		public virtual void Div(double value)
		{
			results.Push(result);
			result /= value;
			Calculation();
		}

		public virtual void Cancel()
		{
			if (results.Count > 0)
			{
				result = results.Pop();
				Calculation();
			}
			else
			{
				Calculation();

			}
		}

		public virtual void Clear()
		{
			result = 0;
			Calculation();
		}
	}
}
