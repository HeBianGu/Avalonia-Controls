﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia.Extensions.Geometry;
using Avalonia.Modules.Messages.Notice;
using Avalonia.Mvvm;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Avalonia.Modules.Messages.Notice
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
