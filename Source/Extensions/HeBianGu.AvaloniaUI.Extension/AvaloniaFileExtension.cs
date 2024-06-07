// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Platform.Storage;
using Avalonia.Styling;
using Avalonia.VisualTree;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HeBianGu.AvaloniaUI.Extension
{
    public static class AvaloniaFileExtension
    {
        public static async Task<string> SaveFilePickerAsync(this Avalonia.Visual visual)
        {
            // 从当前控件获取 TopLevel。或者，您也可以使用 Window 引用。
            var topLevel = TopLevel.GetTopLevel(visual);

            // 启动异步操作以打开对话框。
            var file = await topLevel.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
            {
                Title = "Save Text File"
            });

            if (file is not null)
            {
                //// 打开文件的写入流。
                //await using var stream = await file.OpenWriteAsync();
                //using var streamWriter = new StreamWriter(stream);
                //// 将一些内容写入文件。
                //await streamWriter.WriteLineAsync("Hello World!");
                return file.TryGetLocalPath();
            }
            return null;
        }

        public static async Task<string> OpenFilePickerAsync(this Avalonia.Visual visual)
        {
            // 从当前控件获取 TopLevel。或者，您也可以使用 Window 引用。
            var topLevel = TopLevel.GetTopLevel(visual);

            // 启动异步操作以打开对话框。
            var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "Open Text File",
                AllowMultiple = false
            });

            if (files.Count >= 1)
            {
                //// 打开第一个文件的读取流。
                //await using var stream = await files[0].OpenReadAsync();
                //using var streamReader = new StreamReader(stream);
                //// 将文件的所有内容作为文本读取。
                //var fileContent = await streamReader.ReadToEndAsync();
                return files[0].TryGetLocalPath();
            }
            return null;
        }

    }
}
