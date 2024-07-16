using System.Configuration;
using System.Data;
using System.Windows;
using Task4.Views;

namespace Task4;

public partial class App : Application
{
	private void AppStartup(object sender, StartupEventArgs e)
	{
		var a = new MainWindow().ShowDialog();

		
	}
}