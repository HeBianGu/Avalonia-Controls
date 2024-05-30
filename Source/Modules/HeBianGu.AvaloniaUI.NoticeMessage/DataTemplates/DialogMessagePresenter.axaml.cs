using Avalonia.Extensions.Geometry;
using Avalonia.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HeBianGu.AvaloniaUI.NoticeMessage
{
    public class DialogMessagePresenter : MessagePresenterBase
    {
        public DialogMessagePresenter()
        {
            this.Geometry = GeometryFactory.Create(Geometrys.Dalog);
        }
        public Predicate<DialogMessagePresenter> IsMatch { get; set; }
        public RelayCommand SumitCommand => new RelayCommand((s, e) =>
        {
            this.DialogResult = true;
            this.Close();
        });

        public RelayCommand CancelCommand => new RelayCommand((s, e) =>
        {
            this.DialogResult = false;
            this.Close();
        });


        public RelayCommand CloseCommand => new RelayCommand((s, e) =>
        {
            this.Close();
        });

        private void Close()
        {
            _waitHandle.Set();
        }
        private bool? DialogResult { get; set; }
        private ManualResetEvent _waitHandle = new ManualResetEvent(false);
        public async Task<bool?> ShowDialog()
        {
            _waitHandle.Reset();
            return await Task.Run(() =>
            {
                _waitHandle.WaitOne();
                return this.DialogResult;
            });
        }

    }
}
