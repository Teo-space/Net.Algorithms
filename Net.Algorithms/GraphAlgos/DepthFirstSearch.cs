namespace GraphAlgos
{
	internal class DepthFirstSearch : Template, iRunnable
	{
		static List<int> GraphCells = new List<int>() { 1, 11, 12, 13, 21, 22, 23, 31, 32, 33 };
		static readonly int MaxValue = GraphCells.Max() + 1;
		static readonly int startV = 1;
		static readonly int EndG = 32;


		int Vertice = startV;
		bool[,] Edges = new bool[MaxValue, MaxValue];
		bool[] CheckedVerticles = new bool[MaxValue];
		bool[] EnqueuedVerticles = new bool[MaxValue];
		List<int>[] Paths = new List<int>[MaxValue];


		public DepthFirstSearch()
		{
			//Стартовая вершина проверена
			CheckedVerticles[Vertice] = true;
			EnqueuedVerticles[Vertice] = true;

			InitEdges();
		}
		void InitEdges()
		{
			Edges[1, 11] = true;
			Edges[1, 12] = true;
			Edges[1, 13] = true;


			Edges[11, 21] = true;

			Edges[12, 21] = true;
			Edges[12, 22] = true;
			Edges[12, 23] = true;

			Edges[13, 23] = true;


			Edges[21, 31] = true;
			Edges[22, 32] = true;
			Edges[23, 33] = true;


			Edges[13, 32] = true;


			Edges[21, 1] = true;
			Edges[31, 12] = true;
			Edges[22, 1] = true;
		}

		Queue<int> gfs = new Queue<int>();

		IEnumerable<int> GetConnectedVertices(int v)
		{
			for (int i = 0; i < MaxValue; i++)
			{//Выбираем где есть связь
				if (Edges[v, i]) yield return i;
			}
		}

		void AddToPaths(int index, int verticle)
		{
			if (Paths[index] == null) Paths[index] = new List<int>();
			Paths[index].Add(verticle);
		}

		public void Run()
		{
			print("Depth-first search", ConsoleColor.DarkMagenta);
			int Parent;
			do
			{
				if (Vertice == EndG)//Нашли путь
				{
					print($"Found Vertice: {Vertice}", ConsoleColor.Green);
					Parent = Vertice;
					Vertice = gfs.Dequeue();//Возвращаемся
					print($"Deq Vertice: {Vertice}", ConsoleColor.DarkYellow);
					AddToPaths(Vertice, Parent);
				}
				else
				{
					print($"Vertice: {Vertice}", ConsoleColor.Cyan);

					var ConnectedVertices = GetConnectedVertices(Vertice)
						.Where(x => !CheckedVerticles[x] && !EnqueuedVerticles[x]);
					CheckedVerticles[Vertice] = true;

					int count = ConnectedVertices.Count();
					print($"count: {count}", ConsoleColor.Magenta);

					if (count == 0) //Пришли в тупик
					{
						Vertice = gfs.Dequeue();//Возвращаемся
						print($"Vertice: {Vertice}", ConsoleColor.DarkYellow);
					}
					else
					{
						Parent = Vertice;
						Vertice = ConnectedVertices.First();
						print($"Vertice: {Vertice}", ConsoleColor.Yellow);
						AddToPaths(Vertice, Parent);

						foreach (var vert in ConnectedVertices.Skip(1))
						{
							gfs.Enqueue(vert);
							EnqueuedVerticles[vert] = true;
							print($"Enqueue: {vert}", ConsoleColor.Gray);
						}
					}
				}
			}
			while (gfs.Count > 0);

			ExtractPaths(Paths, EndG, startV);
		}



		static void ExtractPaths(List<int>[] Paths, int Vertice, int End)
		{
			print($"ExtractPaths", ConsoleColor.Cyan);

			var Max = Paths
				.Where(x => x != null)
				.SelectMany(x => x)
				.Max() + 1;

			//print($"Max {Max}", ConsoleColor.Red);

			List<int> row = new List<int>();
			List<List<int>> Result = new List<List<int>>();

			bool[,] Checked = new bool[Max, Max];
			int v = Vertice;

			do
			{
				var First = Paths[v]?.FirstOrDefault(x => !Checked[v, x] && x != 0 && x != Vertice);
				if(First != null && First.HasValue && First.Value != 0)
				{
					if (row.Count == 0)
					{
						row.Add(Vertice);
						//print($"{Vertice}", ConsoleColor.DarkYellow);
					}

					Checked[v, First.Value] = true;
					//print($"{First.Value}", ConsoleColor.Yellow);
					v = First.Value;
					row.Add(v);
				}
				else
				{
					if (v == Vertice) break;
					v = Vertice;

					row.Add(End);
					Result.Add(row);
					row = new List<int>();
					//print($"{End}", ConsoleColor.DarkYellow);
				}

			}
			while (true);

			print($"Depth-first search ExtractPaths Results: ", ConsoleColor.Cyan);
			foreach (var r in Result)
			{
				print(r.ToDelimitedString(", "), ConsoleColor.Cyan);
			}
		}

	}

}
