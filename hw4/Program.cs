class Programm
{
    static void Main(string[] args)
    {
		int[] arr = new int[] { 1, 33, 33, 26, 40, 33, 7, 10 };

		int target = 99;

        for (int i = 0; i < arr.Length; i++)
        {
			
			var x = target - arr[i];
		
			HashSet<int> set = new HashSet<int>();
			for (int j = 0; j < arr.Length; j++)
			{
                if (i != j)
                {
					int y = x - arr[j];
					if (set.Contains(y))
					{
						Console.WriteLine($"{arr[i]} + {arr[j]} + {y} = {target}");
					}
					else
					{
                        if (arr.Contains(y))
                        {
							set.Add(y);

						}
					}
				}
                
			}
			



		}

	}

	
}



