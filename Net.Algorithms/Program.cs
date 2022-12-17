using GraphAlgos;
using Net.Algorithms.HeapAlgs.BinaryHeap;
using SearchAlgos;
using SortAlgs;
using System;
using System.Collections.Generic;

namespace Net.Algorithms
{
	internal class Program
	{
		static void Main(string[] args)
		{

			Run<BinarySearch>();
			printLines(3);


			//SortingAlgosComparision
			Create<QuickSort>()
				.Run(10000);
			Create <InsertionSort>()
				.Run(10000);
			Create <BubleSort>()
				.Run(10000);
			printLines(3);


			//GraphAlgos
			Run<BreadthFirstSearch>();
			printLines(3);
			Run<DepthFirstSearch>();
			printLines(3);


			Run<BinaryHeapTest>();
			printLines(3);

		}
	}











}
