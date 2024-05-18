namespace HeBianGu.Avalonia.Core.Ioc
{
    public interface IMetaSetting
    {
        string ID { get; set; }
        void Load();
        bool Save(out string message);
    }
}
