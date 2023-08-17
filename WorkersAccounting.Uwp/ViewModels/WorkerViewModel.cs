using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using WorkersAccounting.Entities;
using WorkersAccounting.Uwp.Models;

namespace WorkersAccounting.ViewModels;

public partial class WorkerViewModel : ObservableObject
{
    [ObservableProperty]
    private Worker _model;

    public WorkerViewModel() : this(new Worker())
    {
    }

    public WorkerViewModel(Worker model)
    {
        _model = model;
    }

    public string FirstName
    {
        get => Model.FirstName;
        set
        {
            SetProperty(Model.FirstName, value, Model,
                (originModel, newValue) => { originModel.FirstName = newValue; });
        }
    }

    public string LastName
    {
        get => Model.LastName;
        set
        {
            SetProperty(Model.LastName, value, Model, (originModel, newValue) => { originModel.LastName = newValue; });
        }
    }

    public int HourTimeWorking
    {
        get => Model.HourTimeWorking;
        set
        {
            SetProperty(Model.HourTimeWorking, value, Model,
                (originModel, newValue) => originModel.HourTimeWorking = newValue);
        }
    }

    public DateTime Birthday
    {
        get => Model.BirthDay;
        set => SetProperty(Model.BirthDay, value, Model,
            (originModel, newValue) => originModel.BirthDay = newValue);
    }

    public string? Description
    {
        get => Model.Description;
        set => SetProperty(Model.Description, value, Model,
            (originModel, newValue) => originModel.Description = newValue);
    }

    public Gender Gender
    {
        get => Model.Gender;
        set => SetProperty(Model.Gender, value, Model,
            (originModel, newValue) => originModel.Gender = newValue);
    }

    public IEnumerable<Gender> Genders => GenderMethods.GetEnumTypes;
}
