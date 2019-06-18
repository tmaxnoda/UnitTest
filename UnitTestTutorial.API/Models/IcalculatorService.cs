namespace UnitTestTutorial.API.Models
{
    public interface IcalculatorService
    {
        double Add(double val1, double val2);
        double Subtract(double val1, double val2);

        double Multiply(double val1, double val2);

        double Divide(double val1, double val2);
    }
}
