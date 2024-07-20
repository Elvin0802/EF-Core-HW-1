using Microsoft.Extensions.Configuration;
using System.IO;
using System.Windows;
using Task4.Views;

namespace Task4;

public partial class App : Application
{
	public static IConfigurationRoot? Configuration { get; set; }

	private void AppStartup(object sender, StartupEventArgs e)
	{
		Configuration = new ConfigurationBuilder()
					.SetBasePath(Directory.GetCurrentDirectory())
					.AddJsonFile("Resources/appsettings.json")
					.Build();

		_ = new MainWindow().ShowDialog();
	}
}