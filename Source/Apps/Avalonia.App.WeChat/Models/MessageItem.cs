using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Avalonia.App.WeChat.Models
{
    [Display(Name = "微信")]
    public class MessageItem : TabItemBindableBase<Message>
    {
        public MessageItem()
        {
            this.Collection = Enumerable.Range(0, 20).Select(x => new Message() { }).ToObservable();
        }
    }
}
