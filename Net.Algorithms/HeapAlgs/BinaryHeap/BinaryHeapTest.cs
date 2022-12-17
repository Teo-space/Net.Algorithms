using GlobalExtensions;
namespace Net.Algorithms.HeapAlgs.BinaryHeap
{
	internal class BinaryHeapTest : iRunnable
	{
		public void Run()
		{
			print("BinaryHeapTest", ConsoleColor.DarkMagenta);
			{
				print("Create");
				var heap = new BinaryHeap();
				heap.Add(0);
				heap.Add(3);
				heap.Add(8);
				heap.Add(18);
				heap.Add(44);
				print(heap);
			}
			{
				print("Create");
				var heap = new BinaryHeap();
				heap.Add(1);
				heap.Add(2);
				heap.Add(3);
				heap.Add(4);
				heap.Add(5);
				print(heap);
			}
			{
				print("FromArray");
				var heap = BinaryHeap.FromArray(new int[] { 100, 0, 9, 3, 2, 6, 8, 28 });
				print(heap);
			}
			{
				print("BinaryHeap.Sort");
				var array = BinaryHeap.Sort(new int[] { 0, 9, 3, 2, 6, 8 });
				print(array.ToDelimitedString(", "));
			}
		}
	}
}
