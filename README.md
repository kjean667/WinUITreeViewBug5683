# WinUITreeViewBug5683

This repository contains a reproduction sample for triggering microsoft/microsoft-ui-xaml bug #5683: TreeView is unusable thanks to various memory access exceptions.

https://github.com/microsoft/microsoft-ui-xaml/issues/5683

## About the program

The program contains a TreeView that binds an ItemSource to a list contained in a view model.
The TreeView also binds its SelectedItem to a property in the view model.

With a timer, the main view model randomly replaces one item in the TreeView list and programmatically selects one of the items in the list.

## How to trigger

* Run the application for a while.

It crashes after a while, usually within a few seconds (around 1000 iterations).

System.AccessViolationException: 'Attempted to read or write protected memory. This is often an indication that other memory is corrupt.'

```
>	WinUITreeViewBug5683.dll!WinUITreeViewBug5683.ItemViewModel.IsSelected.set(bool value) Line 14	C#
 	WinUITreeViewBug5683.dll!WinUITreeViewBug5683.MainViewModel.Timer_Tick(Microsoft.UI.Dispatching.DispatcherQueueTimer sender, object args) Line 51	C#
```

It triggers easier if run with the debugger attached.
