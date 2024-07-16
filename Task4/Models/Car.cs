namespace Task4.Models;

public class Car
{
    public int CarId { get; set; }
    public int Year { get; set; }
    public string? Make { get; set; }
    public string? Model { get; set; }
    public string? StNumber { get; set; }

    public Car()
    {
        
    }

	public Car(int year, string? make, string? model, string? stNumber)
	{
		Year=year;
		Make=make;
		Model=model;
		StNumber=stNumber;
	}

    public override string ToString() => StNumber!;
}
