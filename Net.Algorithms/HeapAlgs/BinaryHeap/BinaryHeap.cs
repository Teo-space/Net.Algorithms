using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Algorithms.HeapAlgs.BinaryHeap
{
	public class BinaryHeap
	{
		private List<int> list = new List<int>();

		public int heapSize
		{
			get => this.list.Count;
		}
		public int MaxValue
		{
			get => this.list.Count == 0 ? 0 : this.list[0];
		}


		public override string ToString() => list.ToDelimitedString(", ");

		public List<int> ToList() => list.ToList();

		public void Add(int value)
		{
			list.Add(value);
			int i = heapSize - 1;
			int parent = (i - 1) / 2;

			while (i > 0 && list[parent] < list[i])
			{
				int temp = list[i];
				list[i] = list[parent];
				list[parent] = temp;

				i = parent;
				parent = (i - 1) / 2;
			}
		}

		public int GetMax()
		{
			int result = list[0];
			list[0] = list[heapSize - 1];
			list.RemoveAt(heapSize - 1);
			return result;
		}

		public void Heapify(int i)
		{
			int leftChild;
			int rightChild;
			int largestChild;

			for (; ; )
			{
				leftChild = 2 * i + 1;
				rightChild = 2 * i + 2;
				largestChild = i;

				if (leftChild < heapSize && list[leftChild] > list[largestChild])
				{
					largestChild = leftChild;
				}

				if (rightChild < heapSize && list[rightChild] > list[largestChild])
				{
					largestChild = rightChild;
				}

				if (largestChild == i)
				{
					break;
				}

				int temp = list[i];
				list[i] = list[largestChild];
				list[largestChild] = temp;
				i = largestChild;
			}
		}

		public static BinaryHeap FromArray(int[] sourceArray)
		{
			var heap = new BinaryHeap();
			heap.list = sourceArray.ToList();
			for (int i = heap.heapSize / 2; i >= 0; i--)
			{
				heap.Heapify(i);
			}
			return heap;
		}



		public static int[] Sort(int[] array)
		{
			var heap = BinaryHeap.FromArray(array);
			for (int i = array.Length - 1; i >= 0; i--)
			{
				array[i] = heap.GetMax();
				heap.Heapify(0);
			}
			return array;
		}
	}

}
