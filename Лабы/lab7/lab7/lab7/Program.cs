using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab7
{
	delegate int NumberChanger( int n );
	class TestDelegate {
		static int num = 10;
		public static int AddNum( int p ) => ++p;
	}

	class A
	{
		public void Method()
		{
			try
			{
				throw
			new ArgumentNullException();
			}
			finally { }
		}
	}

class Program
	{
		static void Main( string[] args )
		{

		NumberChanger nc;
		NumberChanger nc1 = new NumberChanger(TestDelegate.AddNum); nc = nc1;
		Console.WriteLine(nc(5));

		try
		{
				// Можно использовать только при ограничении struct vv
			/*
				CollectionType<int> collINT = new CollectionType<int>();
				Console.WriteLine("------------");
				collINT.Add(1);
				collINT.Add(2);
				collINT.Add(3);
				collINT.Add(4);
				collINT.Add(5);
				collINT.Show();
				collINT += 10;

				Console.WriteLine("Коллекция double: ");
				CollectionType<double> collDOUBL = new CollectionType<double>();
				collDOUBL.Add((double)0.121);
				collDOUBL.Add((double)3.44);
				collDOUBL.Add((double)5.33);
				collDOUBL.Add((double)1.111);
				collDOUBL.Add((double)0.4);
				collDOUBL += -2.1111;
				collDOUBL.Show();
				
*/

				Console.WriteLine("Коллекция Island: ");

				Island island = new Island("Сицилия", "Италия", 6000000);
				Island island1 = new Island("Хонсю", "Япония", 10000);
				Island island2 = new Island("Южный", "Новая Зеландия", 2000000);
				Island island3 = new Island("Гренландия", "Дания", 26000);
	
				CollectionType<Island> stack1 = new CollectionType<Island>();
				stack1.Push(island);
				stack1 += island1;
				stack1.Add(island2);
				stack1.Add(island3);
				stack1.Pop();

				CollectionType<Island> stack2 = new CollectionType<Island>();
				stack2 = stack1 < stack2;
				stack2.Show();
				stack2.Pop();
				stack2.Pop();
				stack2.Add(island3);

				Console.WriteLine("\n-----------Запись в файл:-----------\n");
				CollectionType<Island>.WriteToFile(ref stack2);
				Console.WriteLine("");

				Console.WriteLine("\n-----------Чтение из файла:-----------\n");
				CollectionType<Island>.ReadFromFile();
				stack2.Show();


				Console.WriteLine(" ");


                string str1 = "asb";
                CollectionType<string> sstring = new CollectionType<string>();
                sstring.Push(str1);
                sstring.Show();

            }

			catch (MyException message)
			{
				Console.WriteLine($"An exception {message.InnerException} found there: {message.StackTrace}.\n");
			}

			finally
			{
				Console.WriteLine("\n Block Finnaly");
			}









			/*Console.WriteLine("Коллекция int: ");
			CollectionType<int> collINT=new CollectionType<int>();
			collINT.Add(1);
			collINT.Add(2);
			collINT.Add(3);
			collINT.Add(4);
			collINT.Add(5);
			collINT.Show();

			Console.WriteLine("After Delete");

			collINT.Delete();
			collINT.Show();
			Console.WriteLine();

			//--------------

			Console.WriteLine("Коллекция double: ");
			CollectionType<double> collDOUBL = new CollectionType<double>();
			collDOUBL.Add(0.121);
			collDOUBL.Add(3.44);
			collDOUBL.Add(5.33);
			collDOUBL.Add(1.111);
			collDOUBL.Add(0.4);
//				collDOUBL.Add(null);

			collDOUBL.Show();

			Console.WriteLine("After Delete");

			collDOUBL.Delete();
			collDOUBL.Show();
			Console.WriteLine();

			//--------------				Console.WriteLine(" --------------------------- ");
				stack2.ChangeTheHead(island2, stack2);
				Console.WriteLine("After ChangeTheHead method");
				stack2.Show();

			//--------------

			Console.WriteLine("Коллекция Island: ");
			CollectionType<Island> collISLAND = new CollectionType<Island>();
			Island isl1 = new Island("Гренландия ");
			Island isl2 = new Island("Калимантан ");
			Island isl3 = new Island("Мадагаскар ");
			Island isl4 = new Island("Хонсю ");
			Island isl5 = new Island("Куба ");



			collISLAND.Add(isl1);
			collISLAND.Add(isl2);
			collISLAND.Add(isl3);
			collISLAND.Add(isl4);
			collISLAND.Add(isl5);
			collISLAND.Show();

			Console.WriteLine("After Delete");

			collISLAND.Delete();
			collISLAND.Show();
			Console.WriteLine();
		}

		catch (MyException message)
		{
			Console.WriteLine($"An exception {message.InnerException} found there: {message.StackTrace}.\n");

		}

		finally
		{
			Console.WriteLine("Finnaly");
		}
		Console.ReadKey();

			*/

		}
	}
}