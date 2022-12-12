internal class Template
{
	public static HashSet<int> Randoms(int limit)
	{
		HashSet<int> result = new HashSet<int>();
		Random rand = new Random();
		while (result.Count < limit)
		{
			result.Add(rand.Next(limit));
		}
		return result;
	}


}

internal class SortTemplate : Template
{
	protected int Count = 0;
	public void Run(int lim)
	{
		print(this.GetType().Name, ConsoleColor.Cyan);

		print("Init", ConsoleColor.DarkBlue);
		var rands = Randoms(lim);
		int[] arr = rands.ToArray();

		print("Sort", ConsoleColor.Yellow);
		DateTime st = DateTime.Now;
		Sort(arr);

		print($"End {(DateTime.Now - st).TotalMilliseconds}", ConsoleColor.Green);
		print($"Count Steps:{Count}", ConsoleColor.DarkBlue);
	}

	public virtual void Sort(int[] arr)
	{

	}
}