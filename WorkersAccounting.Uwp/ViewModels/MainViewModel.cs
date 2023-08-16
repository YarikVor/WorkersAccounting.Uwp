using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using Windows.UI.Popups;
using WorkersAccounting.Entities;

namespace WorkersAccounting.ViewModels;

public partial class MainViewModel : ObservableObject
{

    [ObservableProperty]
    private ObservableCollection<WorkerViewModel> _models;

    [ObservableProperty]
    private WorkerViewModel? _selectedModel;

    public IEnumerable<Worker> Workers
    {
        set
        {
            Models = new ObservableCollection<WorkerViewModel>(
                value.Select(e => new WorkerViewModel(e)));

            Models.CollectionChanged += (sender, args) => OnPropertyChanged(nameof(Models));
        }
    }


    [RelayCommand]
    public void Remove()
    {
        if (SelectedModel == null)
            return;

        var dialog = new MessageDialog(
            $"Do you want delete {SelectedModel.FirstName} {SelectedModel.LastName}?", "Delete item");
        dialog.Commands.Add(new UICommand("Yes", (_) => Destroy()));
        dialog.Commands.Add(new UICommand("No"));
        dialog.DefaultCommandIndex = 1;
        dialog.CancelCommandIndex = 1;

        dialog.ShowAsync();
    }

    private void Destroy()
    {
        Models.Remove(SelectedModel);
        SelectedModel = null;
    }

    [RelayCommand]
    public void Create()
    {
        var worker = GenerateTemplateWorker();
        var viewModel = new WorkerViewModel(worker);
        Models.Add(viewModel);
    }

    private static Worker GenerateTemplateWorker()
    {
        return new Worker
        {
            FirstName = "FirstName",
            HourTimeWorking = 0,
            BirthDay = DateTime.Today,
            Description = string.Empty,
            LastName = "LastName"
        };
    }
}