namespace HeBianGu.AvaloniaUI.Ioc
{
    public interface ISettingViewPresenterOption : ISettingDataManagerOption
    {
        double TitleWidth { get; set; }
        bool UsePassword { get; set; }
    }
}
