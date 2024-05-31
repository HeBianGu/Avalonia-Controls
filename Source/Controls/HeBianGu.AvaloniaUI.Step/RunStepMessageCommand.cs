// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control




using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.Mvvm;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HeBianGu.AvaloniaUI.Step
{
    public class RunStepMessageCommand : MarkupCommandBase
    {
        public bool UseVertical { get; set; }
        public int Count { get; set; } = 10;
        public override async void Execute(object parameter)
        {
            var list = Enumerable.Range(1, this.Count).Select(x => UseVertical ?
            new StepItemVerticalPresenter() { DisplayName = x.ToString() }
            : new StepItemPresenter() { DisplayName = x.ToString() });
            StepPresenter stepPresenter = new StepPresenter();
            stepPresenter.Collection = list.OfType<IStepItemPresenter>().ToObservable();
            await IocMessage.Dialog.ShowAction(stepPresenter, x =>
            {

            },
            (d, p) =>
            {
                foreach (var item in stepPresenter.Collection)
                {
                    item.State = StepState.Running;
                    Thread.Sleep(2000);
                    item.State = Random.Shared.Next(0, 5) == 1 ? StepState.Error : StepState.Success;
                    if (item.State == StepState.Error)
                    {
                        Thread.Sleep(2000);
                        return false;
                    }
                }
                Thread.Sleep(2000);
                return true;
            });
        }
    }
}
