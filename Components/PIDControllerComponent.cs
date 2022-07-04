namespace Components;
class PID
{
    private double p { get; set; }
    private double i { get; set; }
    private double d { get; set; }
    private double minOut { get; set; }
    private double maxOut { get; set; }
    private double integral { get; set; } = 0.0;
    private double previousError { get; set; } = 0.0;

    public PID(double P, double I, double D, double MinOut, double MaxOut)
    {
        this.p = P;
        this.i = I;
        this.d = D;
        this.minOut = MinOut;
        this.maxOut = MaxOut;
    }

    public void SetP(double P)
    {
        this.p = P;
    }

    public void SetI(double I)
    {
        this.i = I;
    }

    public void SetD(double D)
    {
        this.d = D;
    }

    public double Update(double error)
    {
        double p_term = error * p;

        integral += error;
        double i_term = integral * i;

        double d_term = (error - previousError) * d;

        previousError = error;

        return (p_term + i_term + d_term);
    }

    public void ResetIntegral()
    {
        this.integral = 0.0;
    }
}