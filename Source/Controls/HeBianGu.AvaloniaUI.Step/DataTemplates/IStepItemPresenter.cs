using HeBianGu.AvaloniaUI.Ioc;

namespace HeBianGu.AvaloniaUI.Step
{
    public interface IStepItemPresenter: IPresenter
    {
        string DisplayName { get; set; }
        string Message { get; set; }
        int Percent { get; set; }
        StepState State { get; set; }
        double Width { get; set; }
    }
}
