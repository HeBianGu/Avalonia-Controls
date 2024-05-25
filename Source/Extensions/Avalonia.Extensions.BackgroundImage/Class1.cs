using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.Extensions.BackgroundImage
{
    internal class Class1
    {

        public void Method()
        {

            Bitmap bitmap = new Bitmap("avares://Avalonia.Extensions.BackgroundImage/Assets/b13.png");

        }

        public Bitmap GetBitmap(string uri)
        {
           return  new Bitmap(AssetLoader.Open(new Uri(uri)));

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
