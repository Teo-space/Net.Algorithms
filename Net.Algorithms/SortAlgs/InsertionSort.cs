namespace SortAlgs
{
	internal class InsertionSort : SortTemplate
	{
		public override void Sort(int[] arr)
		{
			Count = 0;
			int len = arr.Length;

			for (int i = 1; i < len; i++)
			{
				for (int j = i; j > 0 && arr[j - 1] > arr[j]; j--) // пока j>0 и элемент j-1 > j, x-массив int
				{// меняем местами элементы j и j-1
					Count++;
					int temp = arr[j];
					arr[j] = arr[j - 1];
					arr[j - 1] = temp;
				}
			}
			print($"Count:{Count}");
		}
	}

}
