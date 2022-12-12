global using System;
global using System.IO;
global using System.Data;
//global using System.Text;
global using System.Collections;
global using System.Collections.Generic;
global using System.Linq;
global using System.Threading;
global using System.Threading.Tasks;
global using System.Reflection;
global using System.Text.RegularExpressions;
//-------------------------------------------------------------------------------
global using static GlobalConsole;
//-------------------------------------------------------------------------------
global using MoreLinq;
//-------------------------------------------------------------------------------



class GlobalConsole
{
	static DateTime start = DateTime.Now;

	public static string Time() => $"{DateTime.Now}:{DateTime.Now.Millisecond}";

	public static void print() => Console.WriteLine();

	public static void print(object o = null) => print(o, ConsoleColor.White);

	public static void print(object o = null, ConsoleColor color = ConsoleColor.White)
	{
		if (o == null)
		{
			Console.WriteLine("null");
			return;
		}
		Console.ForegroundColor = ConsoleColor.DarkGray;
		Console.Write("[");
		Console.ForegroundColor = ConsoleColor.Cyan;
		Console.Write(Time());
		Console.ForegroundColor = ConsoleColor.DarkGray;
		Console.Write("]");
		Console.Write($"({Math.Round((DateTime.Now - start).TotalMilliseconds, 2)})        ");
		start = DateTime.Now;
		Console.ForegroundColor = color;
		Console.Write("  ");
		Console.Write(o.ToString());
		Console.WriteLine();
		Console.ForegroundColor = ConsoleColor.White;
	}


	public static void print(params object[] parameters)
	{
		if (parameters == null || parameters.Length == 0) return;

		Console.ForegroundColor = ConsoleColor.DarkGray;
		Console.Write("[");
		Console.ForegroundColor = ConsoleColor.Cyan;
		Console.Write(Time());
		Console.ForegroundColor = ConsoleColor.DarkGray;
		Console.Write("]");
		Console.Write("  ");
		Console.ForegroundColor = ConsoleColor.White;
		for (int i = 0; i < parameters.Length; i++)
		{
			Console.Write($"  {parameters[i]}");
		}
		Console.WriteLine();
	}

	public virtual string? Source { get; set; }
	public static void print(Exception? ex)
	{
		print($"Message: {ex?.Message}", ConsoleColor.Red);
		print($"Source: {ex?.Source}", ConsoleColor.Red);
		print($"StackTrace: {ex?.StackTrace}", ConsoleColor.Red);
		print($"InnerException: {ex?.InnerException?.Message}", ConsoleColor.Red);

		//print(ex, ConsoleColor.DarkRed);
	}


}


