using System.Windows;
using System.Windows.Controls;
using Task4.AppDbContext;
using Task4.Models;

namespace Task4.Views;

public partial class MainWindow : Window
{
	public Car? NewCar { get; set; }
	public CarDbContext? DB { get; set; }

	public MainWindow()
	{
		InitializeComponent();

		DB = new();

		AddCarBtn.IsEnabled = false;
		UpdateCarBtn.IsEnabled = false;
		DeleteCarBtn.IsEnabled = false;

		RefreshData();
	}

	private void AddCarBtnExecute(object sender, RoutedEventArgs e)
	{
		NewCar = new()
		{
			Make = MakeTB.Text,
			Model = ModelTB.Text,
			Year = YearDP.SelectedDate!.Value.Year,
			StNumber = StNumTB.Text
		};

		DB!.Cars.Add(NewCar);

		DB.SaveChanges();

		NewCar = null;

		RefreshData();
	}
	private void UpdateCarBtnExecute(object sender, RoutedEventArgs e)
	{
		NewCar!.Set(YearDP.SelectedDate!.Value.Year, MakeTB.Text, ModelTB.Text, StNumTB.Text);

		DB!.Update(NewCar!);

		DB.SaveChanges();

		NewCar = null;

		RefreshData();
	}
	private void DeleteCarBtnExecute(object sender, RoutedEventArgs e)
	{
		CarsLW.SelectedIndex = -1;

		DB!.Remove(NewCar!);

		DB.SaveChanges();

		NewCar = null;

		UpdateCarBtn.IsEnabled = false;
		DeleteCarBtn.IsEnabled = false;

		MakeTB.Text = "";
		ModelTB.Text = "";
		YearDP.SelectedDate = null;
		StNumTB.Text = "";

		RefreshData();
	}

	private void CarsLW_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (CarsLW.SelectedIndex < 0)
			return;

		NewCar = DB!.Cars.ElementAt(CarsLW.SelectedIndex);

		MakeTB.Text = NewCar!.Make;
		ModelTB.Text = NewCar.Model;
		YearDP.SelectedDate = new DateTime(NewCar.Year, 1, 1);
		StNumTB.Text = NewCar.StNumber;

		DeleteCarBtn.IsEnabled = true;

		UpdateCarBtn.IsEnabled = true;
	}

	private void TB_TextChanged(object sender, TextChangedEventArgs e)
	{
		if (string.IsNullOrEmpty(MakeTB.Text) ||
			string.IsNullOrEmpty(ModelTB.Text) ||
			string.IsNullOrEmpty(YearDP.Text) ||
			string.IsNullOrEmpty(StNumTB.Text))
		{
			AddCarBtn.IsEnabled = false;

			UpdateCarBtn.IsEnabled = false;
		}
		else
		{
			AddCarBtn.IsEnabled = true;

			if (CarsLW.SelectedIndex >= 0)
				UpdateCarBtn.IsEnabled = true;
		}
	}

	public void RefreshData()
	{
		CarsLW.ItemsSource = DB!.Cars.ToList();

		CarsLW.Items.Refresh();
	}
}
