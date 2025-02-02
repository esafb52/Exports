<Query Kind="Program" />

public class Expense
{
	public DateTime Date { set; get; }
	public string Department { set; get; }
	public decimal Expenses { set; get; }
}

public static IList<Expense> ExpensesDataSource()
{
	return new List<Expense>
		{
			new Expense { Date = new DateTime(2011,11,1), Department = "Computer", Expenses = 100 },
			new Expense { Date = new DateTime(2011,11,1), Department = "Math", Expenses = 200 },
			new Expense { Date = new DateTime(2011,11,1), Department = "Physics", Expenses = 150 },

			new Expense { Date = new DateTime(2011,10,1), Department = "Computer", Expenses = 75 },
			new Expense { Date = new DateTime(2011,10,1), Department = "Math", Expenses = 150 },
			new Expense { Date = new DateTime(2011,10,1), Department = "Physics", Expenses = 130 },

			new Expense { Date = new DateTime(2011,9,1), Department = "Computer", Expenses = 90 },
			new Expense { Date = new DateTime(2011,9,1), Department = "Math", Expenses = 95 },
			new Expense { Date = new DateTime(2011,9,1), Department = "Physics", Expenses = 100 }
		};	
}

void Main()
{
	ExpensesDataSource().Dump();
	ExpensesDataSource()
									.GroupBy(t =>
										new
										{
											Year = t.Date.Year,
											Month = t.Date.Month                                            
										})
									.Select(
									   myGroup =>
										   new
										   {
											   //Year = myGroup.Key.Year,
											   Month = myGroup.Key.Month,
											   ComputerDepartment = myGroup.Where(x => x.Department == "Computer").Sum(x => x.Expenses),
											   MathDepartment = myGroup.Where(x => x.Department == "Math").Sum(x => x.Expenses),
											   PhysicsDepartment = myGroup.Where(x => x.Department == "Physics").Sum(x => x.Expenses),
											   Total = myGroup.Sum(x=>x.Expenses)											   
										   }
									)
									.Dump();
}