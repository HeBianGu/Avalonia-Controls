﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using System;
using System.Net.Http;
using System.Text.Json;

namespace Avalonia.Ioc
{
    internal class JsonWebSerializerService : IWebJsonSerializerService
    {
        public T Load<T>(string url, out string message)
        {
            message = null;
            Uri uri = new Uri(url);
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string json = client.GetStringAsync(uri).Result;
                    return (T)JsonSerializer.Deserialize(json, typeof(T));
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    IocLog.Instance?.Error(ex);
                    return default;
                }
            }
        }
    }
}