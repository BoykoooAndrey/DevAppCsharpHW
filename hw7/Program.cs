using System;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;

namespace hw7
{
	internal class Program
	{
		static void Main(string[] args)
		{
			TestClass tc = new TestClass(1, "s", 0.5m, new char[] { 'c', 'h', ' ', 'a', 'r' });
			string data = objToString(tc);

            TestClass newTC = (TestClass)stringToObj(data);
            Console.WriteLine(newTC.ToString());


        }

		static string objToString(object o)
		{
			StringBuilder sb = new StringBuilder();
			Type type = o.GetType();
			var properties = type.GetProperties();
			sb.Append(type.AssemblyQualifiedName);
			sb.Append(':');

			foreach (var proerty in properties)
			{
				if (proerty.GetValue(o) != null)
				{
					if (!proerty.GetValue(o).GetType().IsArray)
					{
						sb.Append(proerty.ToString());
						sb.Append('*');
						sb.Append(proerty.GetValue(o));
						sb.Append(';');
					}
					else
					{
						if (proerty.GetValue(o).GetType().ToString() == "System.Char[]")
						{
							char[]? arr = proerty.GetValue(o) as char[];

							if (!(arr is null))
							{
								sb.Append(proerty.ToString());
								sb.Append('*');

								foreach (var element in arr)
								{
									sb.Append(element);
								}
							}
						}
						if (proerty.GetValue(o).GetType().ToString() == "System.String[]")
						{
							// Ну тут реалзиация не особо будет отличаться, так что думаю смысла нет расписывать, цель урока я думаю не в этом)
						}
						if (proerty.GetValue(o).GetType().ToString() == "System.int[]")
						{
							// Ну тут реалзиация не особо будет отличаться, так что думаю смысла нет расписывать, цель урока я думаю не в этом)
						}
					}
				}
			}
			return sb.ToString();

		}
		static object? stringToObj(string data)
		{
			string[] firstLevel = data.Split(':');
			string[] metaData = firstLevel[0].Split(',');
			ObjectHandle? obj = Activator.CreateInstance(metaData[1], metaData[0]);
			var result = obj.Unwrap();

			Type type = result.GetType();
			var properties = type.GetProperties();

			string[] secondLevel = firstLevel[1].Split(';');
           
            foreach (var item in secondLevel)
            {
				string[] propertyKey = item.Split('*');
				
                foreach (var proerty in properties)
				{

					if (propertyKey[0] == proerty.ToString())
                    {
                        switch (propertyKey[0])
						{
							case "Int32 I":
                                proerty.SetValue(result, int.Parse(propertyKey[1]));
								break;
							case "System.String S":
								proerty.SetValue(result, propertyKey[1]);
								break;
							case "System.Decimal D":
                                
								proerty.SetValue(result,  Convert.ToDecimal(propertyKey[1]));

								break;
							case "Char[] C":
                                List<char> tmp = new List<char>();
                                for (int i = 0; i < propertyKey[1].Length; i++)
                                {
									tmp.Add(propertyKey[1][i]);
								}
								proerty.SetValue(result, tmp.ToArray());
								break;
						}
					}
                }
            }
            
			return result;
		}
	}
}


class TestClass
{
	public int I { get; set; }
	public string? S { get; set; }
	public decimal D { get; set; }
	public char[]? C { get; set; }

	public TestClass()
	{ }
	private TestClass(int i)
	{
		this.I = i;
	}
	public TestClass(int i, string s, decimal d, char[] c) : this(i)
	{
		this.S = s;
		this.D = d;
		this.C = c;
	}
	public override string ToString()
	{
		StringBuilder sb = new StringBuilder();
		sb.Append(this.I);
		sb.Append(" ");
		sb.Append(this.S);
		sb.Append(" ");
		sb.Append(this.D);
		sb.Append(" ");
		sb.Append(this.C);
		sb.Append(" ");

		return sb.ToString();
	}
}