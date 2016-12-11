﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Catalogo.Models;
using Catalogo.Services;
using MvvmCross.Core.ViewModels;

namespace Catalogo.Core.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        public MenuViewModel(IDataService dataService) : base(dataService)
        {
            DataService.LoadCategorias(OnSucesso, OnErro);
        }

        private ObservableCollection<Categoria> _categorias;
        public ObservableCollection<Categoria> Categorias
        {
            get { return _categorias; }
            set
            {
                _categorias = value;
                RaisePropertyChanged(() => Categorias);
            }
        }

        public IMvxCommand ShowHomeCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    ShowViewModel<CatalogoViewModel>();
                });
            }
        }

        private void OnSucesso(List<Categoria> list)
        {
            Categorias = new ObservableCollection<Categoria>(list);
        }
        private void OnErro(Exception obj)
        {
        }
    }
}