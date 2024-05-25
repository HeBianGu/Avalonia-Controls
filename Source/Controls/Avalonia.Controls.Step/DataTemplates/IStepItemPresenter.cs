namespace Avalonia.Controls.Step
{
    public interface IStepItemPresenter
    {
        string DisplayName { get; set; }
        string Message { get; set; }
        int Percent { get; set; }
        StepState State { get; set; }
        double Width { get; set; }
    }
}
