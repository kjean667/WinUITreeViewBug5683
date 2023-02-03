using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;

namespace WinUITreeViewBug5683
{
    public partial class ItemViewModel : ObservableObject
    {
        public string Name { get; }

        public bool m_isSelected;
        public bool IsSelected
        {
            get => m_isSelected;
            set => SetProperty(ref m_isSelected, value);
        }

        [ObservableProperty]
        public bool m_isExpanded;

        public List<ItemViewModel> Children = new();

        public ItemViewModel(string name)
        {
            Name = name;

            IsExpanded = true;
        }
    }
}
