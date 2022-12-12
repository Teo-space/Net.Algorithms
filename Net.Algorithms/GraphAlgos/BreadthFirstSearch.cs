namespace GraphAlgos
{
	internal class BreadthFirstSearch : Template
	{
		static List<int> GraphCells = new List<int>() { 1, 11, 12, 13, 21, 22, 23, 31, 32, 33 };
		static readonly int MaxValue = GraphCells.Max() + 1;
		static bool[,] Edges = new bool[MaxValue, MaxValue];

		static int startV = 1;
		static int Vertice = startV;
		static int EndG = 32;

		static bool[] CheckedVerticles = new bool[MaxValue];
		static bool[] EnqueuedVerticles = new bool[MaxValue];
		static int[] Paths = new int[MaxValue];


		static BreadthFirstSearch()
		{
			CheckedVerticles[Vertice] = true;
			EnqueuedVerticles[Vertice] = true;

			InitEdges();
		}
		static void InitEdges()
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

		static Queue<int> gfs = new Queue<int>();


		static IEnumerable<int> GetConnectedVertices(int v)
		{
			for (int i = 0; i < MaxValue; i++)
			{//Выбираем где есть связь
				if (Edges[v, i]) yield return i;
			}
		}

		public static void Run()
		{
			print("Breadth-first search", ConsoleColor.Yellow);
			do
			{
				foreach(var v in GetConnectedVertices(Vertice)
					.Where(x => !CheckedVerticles[x] && !EnqueuedVerticles[x]))
				{
					EnqueuedVerticles[v] = true;
					print($"Enqueue: {v}", ConsoleColor.Gray);
					gfs.Enqueue(v);
					Paths[v] = Vertice;//Сохраняем откуда пришли первый раз
				}

				Vertice = gfs.Dequeue();
				print($"Vertice: {Vertice}", ConsoleColor.Yellow);

				if (CheckedVerticles[Vertice]) continue;
				CheckedVerticles[Vertice] = true;

				if (Vertice == EndG) break;
			}
			while (gfs.Count > 0);

			List<int> path = new List<int>();
			int p = Vertice;
			path.Add(p);
			do
			{
				p = Paths[p];
				path.Add(p);
			}
			while (p != startV);
			print($"Breadth-first search Result:  {path.ToDelimitedString(", ")}", ConsoleColor.Cyan);
		}





	}
}
