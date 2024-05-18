namespace HeBianGu.Avalonia.Core.Ioc
{
    public interface IMetaSettingService
    {
        void Serilize(object setting, string id);
        T Deserilize<T>(string id);
    }
}
