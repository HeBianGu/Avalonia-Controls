using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Avalonia.App.WeChat.Models
{
    [Display(Name = "通讯录")]
    public class AddressItem : TabItemBindableBase<Address>
    {
        public AddressItem()
        {
            this.Collection = Enumerable.Range(0, 20).Select(x => new Address()).ToObservable();
        }
    }
}
