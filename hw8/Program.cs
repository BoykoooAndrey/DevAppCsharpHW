using System.Diagnostics;
using System.IO;

namespace hw8
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string path = Directory.GetCurrentDirectory();
			try
			{
                if (args.Length != 2)
                {
					throw new ArgumentException();
				}
				string fileName = args[0];
				string text = args[1];

				if (!(FindFile(fileName, path, text)))
				{
					Console.WriteLine("Файл не найден");

				}
				

			}
			catch (ArgumentException)
			{
				Console.WriteLine("Неверное количество аргументов");
			}
			catch (Exception)
			{
				Console.WriteLine("Неверные аргументы");
			}
			/*string fileName = "tesssst.txt";
			string text = "";*/


			

		}


		static string ReadText(string path)
		{
			using (StreamReader sr = new StreamReader(path))
			{
				return sr.ReadToEnd();
			}
		}
		static bool FindFile(string fileName, string path, string text)
		{
			bool result = false;
            foreach (string file in Directory.GetFiles(path))
			{
                if (Path.GetFileName(file) ==  fileName)
				{
					string data = "";

					if (text == (data = ReadText(file)))
                    {
                        Console.Write("Файл найден: ");
                        Console.WriteLine(file);
                        Console.WriteLine("Содержимое файла:");
                        Console.WriteLine(data);
                        result = result || true;
					}
                    
				}
			}
			foreach (string dir in Directory.GetDirectories(path))
			{
				result = result || FindFile(fileName, dir, text);
			}
			return result;
		}

		




	}
}

