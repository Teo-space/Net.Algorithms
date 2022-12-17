namespace SearchAlgos
{
	internal class BinarySearch : Template, iRunnable
	{

		public void Run()
		{
			int number = 741;
			int ArrSize = 1000;

			print("BinarySearch", ConsoleColor.Green);

			var list = Enumerable.Range(0, ArrSize).ToList();

			print($"Search({number}) : {Search(list, number)}", ConsoleColor.Green);
		}


		public static int? Search(List<int> list, int item)
		{
			int Min = 0;
			int Max = list.Count;
			int currentIndex = 0;
			int current;
			while (Min < Max)
			{
				currentIndex = (Min + Max) / 2;
				current = list[currentIndex];

				print($"Min {Min}   Max {Max}   currentIndex   {currentIndex} current {current}");

				if (current == item)
				{
					return currentIndex;
				}
				else if (current > item)
				{
					Max = currentIndex;
				}
				else if (current < item)
				{
					Min = currentIndex;
				}
			}

			return default;
		}
	}

}
