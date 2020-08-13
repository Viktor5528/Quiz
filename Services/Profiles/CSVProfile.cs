using CsvHelper.Configuration;

using Services.Requests;
using Services.ViewModels;

public class CSVUser : ClassMap<RegisterViewModel>
{
    public CSVUser()
    {
        Map(m => m.Password).Name("Password");
        Map(m => m.Login).Name("Login");
        Map(m => m.Age).Name("Age");
    }
}