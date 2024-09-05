﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;


namespace MyFirstMauiApp.ViewModel;

public partial class MainViewModel  : ObservableObject
{
    public MainViewModel()
    {
        Items = new ObservableCollection<string>();
    }

    [ObservableProperty]
    ObservableCollection<string> items;

    [ObservableProperty]
    string text;
   
    [RelayCommand]
    void Add()
    {
        if (string.IsNullOrWhiteSpace(Text))
            return;

        Items.Add(text);
        
        // add our item
        Text = string.Empty;
    }

    [RelayCommand]
    void Delete(string s)
    {
        if (items.Contains(s))
        {
            Items.Remove(s);
        }
    }
    [RelayCommand]
    async Task Tap(string s)
    {
        //await Shell.Current.GoToAsync($"DetailPage?Text={s}");
        //same
        await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
    }
}
