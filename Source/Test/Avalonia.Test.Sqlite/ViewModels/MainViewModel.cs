using Avalonia.Threading;
using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Threading.Tasks;
using HeBianGu.AvaloniaUI.Mvvm;
using HeBianGu.AvaloniaUI.Ioc;

namespace Avalonia.Test.Sqlite.ViewModels;

public class MainViewModel : BindableBase
{
    public string Greeting => "Welcome to Avalonia!";

    private readonly IStringRepository<mbc_dv_image> _imageRepository;
    public MainViewModel()
    {
        _imageRepository =System.Ioc.GetService<IStringRepository<mbc_dv_image>>();

        this.RefreshData();
    }


    private ObservableCollection<mbc_dv_image> _collection = new ObservableCollection<mbc_dv_image>();
    /// <summary> 说明  </summary>
    public ObservableCollection<mbc_dv_image> Collection
    {
        get { return _collection; }
        set
        {
            _collection = value;
            RaisePropertyChanged();
        }
    }


    public RelayCommand AddCommand => new RelayCommand(async (s, e) =>
    {
        mbc_dv_image image = new mbc_dv_image();
        image.Name = DateTime.Now.ToString();
        _imageRepository.Insert(image);
        this.RefreshData();
    });


    public RelayCommand DeleteCommand => new RelayCommand((s, e) =>
    {
        if (this.SelectedImage == null)
            return;
        _imageRepository.Delete(this.SelectedImage);
        this.RefreshData();
    });

    public RelayCommand ClearCommand => new RelayCommand((s, e) =>
    {
        _imageRepository.Clear();
        this.RefreshData();
    });

    private mbc_dv_image _selectedImage;
    /// <summary> 说明  </summary>
    public mbc_dv_image SelectedImage
    {
        get { return _selectedImage; }
        set
        {
            _selectedImage = value;
            RaisePropertyChanged();
        }
    }



    public void RefreshData()
    {
        Task.Run(() =>
        {
            Dispatcher.UIThread.Invoke(() =>
            {
                var images = _imageRepository.GetList();
                this.Collection = new ObservableCollection<mbc_dv_image>(images);
            });
        });
    }

}
