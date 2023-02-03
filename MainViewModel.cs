using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Dispatching;
using System;
using System.Collections.ObjectModel;

namespace WinUITreeViewBug5683
{
    public partial class MainViewModel : ObservableObject
    {
        public ObservableCollection<ItemViewModel> Items { get; } = new();

        [ObservableProperty]
        private ItemViewModel m_selectedItemViewModel;

        DispatcherQueue m_dispatcher;

        public MainViewModel()
        {
            m_dispatcher = DispatcherQueue.GetForCurrentThread();

            var timer = m_dispatcher.CreateTimer();
            timer.Interval = new System.TimeSpan(0, 0, 0, 0, 10);
            timer.Tick += Timer_Tick;
            timer.Start();

            Items.Add(new ItemViewModel("Item 1"));
            Items.Add(new ItemViewModel("Item 2"));
            Items.Add(new ItemViewModel("Item 3"));
            Items.Add(new ItemViewModel("Item 4"));
            Items.Add(new ItemViewModel("Item 5"));
            Items.Add(new ItemViewModel("Item 6"));

            Items[0].IsSelected = true;
            SelectedItemViewModel = Items[0];
        }

        private int m_counter = 0;

        private void Timer_Tick(DispatcherQueueTimer sender, object args)
        {
            Random rnd = new Random();

            var removeIndex = rnd.Next(0, Items.Count);
            var item = new ItemViewModel($"Item {m_counter++}");
            item.Children.Add(new ItemViewModel("Sub item"));
            Items.Insert(removeIndex, item);
            Items.RemoveAt(removeIndex + 1);


            var index = rnd.Next(0, Items.Count);
            Items[index].IsSelected = true;
            SelectedItemViewModel = Items[index];
        }
    }
}
