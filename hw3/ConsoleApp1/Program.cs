
class Program
{

	public static void Main(string[] args)
	{
		int[,,] labirynth = new int[5, 5, 5];

		int[,,] labirynth2 = new int[,,]
		{
			{
				{ 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 1 }

			},
			{
				{ 1, 1, 1, 0, 1, 1, 1 },
				{ 1, 0, 0, 0, 0, 0, 1 },
				{ 1, 0, 1, 1, 1, 0, 1 },
				{ 0, 0, 0, 0, 1, 0, 0 },
				{ 1, 1, 1, 0, 1, 1, 1 },
				{ 1, 1, 1, 0, 1, 1, 1 },
				{ 1, 1, 1, 0, 1, 1, 1 },
				{ 1, 1, 1, 0, 1, 1, 1 }
			},
			{
				{ 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 1, 0, 1, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 1 }

			},
			{
				{ 1, 1, 1, 0, 1, 1, 1 },
				{ 1, 0, 0, 0, 0, 0, 1 },
				{ 1, 0, 1, 1, 1, 0, 1 },
				{ 0, 0, 0, 0, 1, 0, 0 },
				{ 1, 1, 0, 0, 1, 1, 1 },
				{ 1, 1, 1, 0, 1, 1, 1 },
				{ 1, 1, 1, 0, 1, 1, 1 },
				{ 1, 1, 1, 0, 1, 1, 1 }
			},
			{
				{ 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 0, 1, 1, 1, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 1, 0, 1, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 1 }
			}
		};
        Console.WriteLine(Find(1, 3, 3, labirynth2));
        for (int i = 0; i < labirynth2.GetLength(0); i++)
        {
			Console.WriteLine("{");

			for (int j = 0; j < labirynth2.GetLength(1); j++)
            {
                Console.Write("    { ");
                for (int k = 0; k < labirynth2.GetLength(2); k++)
                {
					Console.Write(labirynth2[i, j, k] + ", ");
                }
                Console.Write("},");
                Console.WriteLine();
            }
			Console.WriteLine("},");

		}
		


    }


	static int Find(int i, int j, int k, int[,,] arr)
	{
		int count = 0;
        if (HasExit(i, j, k, arr))
        {
			count++;
			

		}
		else if (arr[i, j, k] == 1 || arr[i, j, k] == 2)
		{
			return 0;
		}
		else
		{
			arr[i, j, k] = 2;
			count += 
			Find(i, j, k + 1, arr) +
			Find(i, j, k - 1, arr) +

			Find(i, j + 1, k, arr) +
			Find(i, j - 1, k, arr) +

			Find(i + 1, j, k, arr) +
			Find(i - 1, j, k, arr);

		}
		return count;




	}

	static bool HasExit(int i, int j, int k, int[,,] arr)
	{
        if ((i < 0 || i > arr.GetLength(0) - 1) || (j < 0 || j > arr.GetLength(1) - 1) || (k < 0 || k > arr.GetLength(2) - 1))
        {
			return true;
        }
		return false;
    }


}