using hw5;

class Program
{
    
    public static void Main()
    {
        Calculator calculator = new Calculator();
		calculator.Result += Calculator_Result;

        calculator.Add(10);
        calculator.Add(20);
        calculator.Div(3);

        Console.WriteLine();

        calculator.Cancel();
		calculator.Cancel();
		calculator.Cancel();
		calculator.Cancel();
		calculator.Cancel();





		calculator.Result -= Calculator_Result;

	}

	private static void Calculator_Result(object? sender, CalculatorArgs e)
	{
        Console.Write($"{e.answer} ");
    }
}