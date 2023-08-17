using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Popups;
using WorkersAccounting.Entities;
using WorkersAccounting.Uwp.Models;

namespace WorkersAccounting.ViewModels;

public partial class MainViewModel : ObservableObject
{

    [ObservableProperty]
    private ObservableCollection<WorkerViewModel> _models;

    [ObservableProperty]
    private WorkerViewModel? _selectedModel;

    [ObservableProperty]
    private bool _isOpenPopup;

    [ObservableProperty]
    private WorkerViewModel _createModel = new WorkerViewModel(GenerateTemplateWorker());

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
            $"Do you want delete {SelectedModel.FirstName} {SelectedModel.LastName}?",
            "Delete item")
        {
            DefaultCommandIndex = 1,
            CancelCommandIndex = 1
        };
        dialog.Commands.Add(new UICommand("Yes", (_) => Destroy()));
        dialog.Commands.Add(new UICommand("No"));

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
        CreateModel = new WorkerViewModel(GenerateTemplateWorker());
        IsOpenPopup = true;
    }

    [RelayCommand]
    public void ClosePopup()
    {
        IsOpenPopup = false;
    }

    [RelayCommand]
    public void SavePopup()
    {
        IsOpenPopup = false;
        Models.Add(CreateModel);
    }

    private static Worker GenerateTemplateWorker()
    {
        return new Worker
        {
            FirstName = "FirstName",
            LastName = "LastName",
            HourTimeWorking = 0,
            BirthDay = DateTime.Today,
            Description = string.Empty,
            Gender = Gender.Other
        };
    }

    public IEnumerable<Gender> GenderItems => GenderMethods.GetEnumTypes;
}
