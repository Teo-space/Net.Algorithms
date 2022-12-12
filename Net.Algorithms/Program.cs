using GraphAlgos;
using SearchAlgos;
using SortAlgs;

namespace Net.Algorithms
{
	internal class Program
	{
		static void Main(string[] args)
		{
			BinarySearch.Run(1000, 678);
			print();
			print();

			//SortingAlgosComparision
			new QuickSort().Run(1000);
			new InsertionSort().Run(1000);
			new BubleSort().Run(1000);
			print();
			print();

			//GraphAlgos
			BreadthFirstSearch.Run();
			DepthFirstSearch.Run();

		}
	}
}
