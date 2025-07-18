using static System.Net.Mime.MediaTypeNames;

namespace Opc.NodeSet2.Server.Example
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			var application = new Application();
			await application.StartAsync();

			Console.WriteLine("Server is running. Press any key to exit...");
			Console.ReadKey(true);
		}
	}
}
