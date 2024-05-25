// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using System;
using System.Reflection;
using System.Xml;

namespace Avalonia.Ioc
{
    public interface IXmlable
    {
        void FromXml(XmlElement xmlEle, XmlDocument cnt, Func<PropertyInfo, object, bool> match = null);

        void ToXml(XmlElement xmlEle, XmlDocument cnt, Func<PropertyInfo, object, bool> match = null);
    }
}