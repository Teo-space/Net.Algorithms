namespace SortAlgs
{
    internal class BubleSort : SortTemplate
	{
		public override void Sort(int[] arr)
		{
			Count = 0;
			int len = arr.Length;
			for (int i = 0; i < len; i++)
			{
				for (int j = 0; j < len; j++)
				{
					Count++;
					if (arr[j] >= j + 1)
					{
						var temp = arr[j];
						arr[j] = arr[j + 1];
						arr[j + 1] = temp;
					}
				}
			}
		}
	}
}
