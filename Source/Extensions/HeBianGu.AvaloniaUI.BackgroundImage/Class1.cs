using Avalonia.Markup.Xaml.Converters;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.AvaloniaUI.BackgroundImage
{
    public class AssetBitmapTypeConverter : BitmapTypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            var s = (string)value;
            var uri = s.StartsWith("/")
                ? new Uri(s, UriKind.Relative)
                : new Uri(s, UriKind.RelativeOrAbsolute);

            if (uri.IsAbsoluteUri && uri.IsFile)
                return new Bitmap(uri.LocalPath);

            return new AssetBitmap(uri);
        }
    }
    [TypeConverter(typeof(AssetBitmapTypeConverter))]
    public class AssetBitmap : Bitmap
    {
        public AssetBitmap(Uri uri) : base(AssetLoader.Open(uri))
        {

        }
        public AssetBitmap(string uri) : base(AssetLoader.Open(new Uri(uri)))
        {

        }

        public AssetBitmap(Stream uri) : base(uri)
        {

        }

        public string Uri { get; set; }
    }
    internal class Class1
    {

        public void Method()
        {

            Bitmap bitmap = new Bitmap("avares://HeBianGu.AvaloniaUI.BackgroundImage/Assets/Star.png");

        }

        public Bitmap GetBitmap(string uri)
        {
            return new Bitmap(AssetLoader.Open(new Uri(uri)));

        }

        // 在适当的位置创建一个方法来加载图像
        private async Task<Bitmap> LoadImageFromUrl(string imageUrl)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // 从web URL获取图像数据
                    byte[] imageData = await client.GetByteArrayAsync(imageUrl);

                    // 将图像数据转换为Avalonia的Bitmap
                    using (var stream = new MemoryStream(imageData))
                    {
                        var bitmap = new Bitmap(stream);
                        return bitmap;
                        //// 将Bitmap设置为Image控件的Source属性
                        //imageControl.Source = bitmap;
                    }
                }
            }
            catch (Exception ex)
            {
                // 处理异常情况
                Console.WriteLine("加载图像时出现错误：" + ex.Message);
            }

            return null;
        }
    }
}
