global using static GlobalExtensions.ExtensionsCreate;

namespace GlobalExtensions
{
	public static class ExtensionsCreate
	{
		public static T Create<T>() where T : class, new() => new T();

		public static void Run<T>() where T : class, iRunnable, new()
		{
			Create<T>().Run();
		}
	}
	public interface iRunnable
	{
		public void Run();
	}
}
