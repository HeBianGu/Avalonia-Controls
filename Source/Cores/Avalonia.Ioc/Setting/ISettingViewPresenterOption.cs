namespace Avalonia.Ioc
{
    public interface ISettingViewPresenterOption : ISettingDataManagerOption
    {
        double TitleWidth { get; set; }
        bool UsePassword { get; set; }
    }
}
