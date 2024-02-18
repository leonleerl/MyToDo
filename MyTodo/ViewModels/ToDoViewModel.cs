﻿using MyTodo.Common.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.ViewModels
{
    public class ToDoViewModel : BindableBase
    {
        public ToDoViewModel()
        {
            ToDoDtos = new ObservableCollection<ToDoDto>();
            CreateToDoList();
            AddCommand = new DelegateCommand(Add);
        }

        private void Add()
        {
            IsRightDrawerOpen = !IsRightDrawerOpen;
        }

        public void CreateToDoList()
        {
            for (int i = 0; i < 20; i++)
            {
                ToDoDtos.Add(
                    new ToDoDto()
                    {
                        Title = "标题" + i,
                        Content = "测试数据" + i
                    }
                    );
            }
        }

        public DelegateCommand AddCommand { get; private set; }


        private ObservableCollection<ToDoDto> _toDoDtos;
        private bool _isRightDrawerOpen;

        public bool IsRightDrawerOpen
        {
            get { return _isRightDrawerOpen; }
            set
            {
                _isRightDrawerOpen = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<ToDoDto> ToDoDtos
        {
            get { return _toDoDtos; }
            set { _toDoDtos = value; }
        }

    }
}
