// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control




using HeBianGu.AvaloniaUI.Mvvm;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HeBianGu.AvaloniaUI.Step
{
    public class StepRunCommand : MarkupCommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter is Step step)
            {
                var items = step.Items.OfType<IStepItemPresenter>();
                foreach (var item in items)
                {
                    item.State = StepState.Ready;
                }

                Task.Run(() =>
                {
                    foreach (var item in items)
                    {
                        item.State = StepState.Running;
                        Thread.Sleep(1000);
                        item.State = Random.Shared.Next(0, 5) == 1 ? StepState.Error : StepState.Success;
                        if (item.State == StepState.Error)
                            return;
                    }
                });
            }
        }
    }
}
