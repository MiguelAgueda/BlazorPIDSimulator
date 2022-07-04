namespace Components;
class Plant
{
    private double min { get; set; }
    private double max { get; set; }
    public double lastOutput { get; set; } = 0.0;

    private PID plantPID = new PID(.025, 1e-9, 0.1, 0.0, 255.0);
    public Plant(double Min, double Max)
    {
        this.min = Min;
        this.max = Max;
    }

    public double Update(double Input)
    {
        if (Input > 255.0)
            Input = 255.0;
        else if (Input < 0.0)
            Input = 0.0;

        double desiredOutput = Input * this.max / 255.0;
        double deltaOutput = desiredOutput - this.lastOutput;
        double output = this.lastOutput + this.plantPID.Update(deltaOutput);
        this.lastOutput = output;
        return output;
    }
}