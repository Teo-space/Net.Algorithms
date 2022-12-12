namespace SortAlgs
{
	internal class QuickSort : SortTemplate
	{
		public override void Sort(int[] arr)
		{
			Count = 0;
			Sort(arr, 0, arr.Length - 1);
		}

		void Sort(int[] arr, int left, int right)
		{
			int start = left;
			int end = right;
			int Base = arr[(left + right) / 2];

			while (start <= end)
			{
				while (arr[start] < Base) start++;
				while (arr[end] > Base) end--;

				Count++;
				if (start <= end)
				{
					int temp = arr[start];
					arr[start] = arr[end];
					arr[end] = temp;
					start++;
					end--;
				}
			}

			if (left < end) Sort(arr, left, end);
			if (start < right) Sort(arr, start, right);
		}

	}
}
