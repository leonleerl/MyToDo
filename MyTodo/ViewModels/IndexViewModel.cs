using MyTodo.Common.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.ViewModels
{
    public class IndexViewModel : BindableBase
    {
        public IndexViewModel()
        {
            TaskBars = new ObservableCollection<TaskBar>();
            CreateTaskBars();
            CreateTestData();
        }

        public void CreateTaskBars()
        {
            TaskBars.Add(new TaskBar { Icon = "ClockFast", Title = "汇总", Content = "9", Color = "#ff0ca0ff", Target = "" });
            TaskBars.Add(new TaskBar { Icon = "ClockCheckOutline", Title = "已完成", Content = "9", Color = "#ff1eca3a", Target = "" });
            TaskBars.Add(new TaskBar { Icon = "ChartLineVariant", Title = "完成比例", Content = "100%", Color = "#ff02c6dc", Target = "" });
            TaskBars.Add(new TaskBar { Icon = "PlaylistStar", Title = "备忘录", Content = "19", Color = "#ffffa000", Target = "" });
        }
        public void CreateTestData()
        {
            ToDoDtos = new ObservableCollection<ToDoDto>();
            MemoDtos = new ObservableCollection<MemoDto>();

            for (int i = 0; i < 10; i++)
            {
                ToDoDtos.Add(new ToDoDto { Title = "待办" + i, Content = "正在处理中..." });
                MemoDtos.Add(new MemoDto { Title = "备忘" + i, Content = "我的密码" });
            }
        }

        private ObservableCollection<TaskBar> _taskBars;

        public ObservableCollection<TaskBar> TaskBars
        {
            get { return _taskBars; }
            set
            {
                _taskBars = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<ToDoDto> _toDoDtos;

        public ObservableCollection<ToDoDto> ToDoDtos
        {
            get { return _toDoDtos; }
            set
            {
                _toDoDtos = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<MemoDto> _memoDto;

        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return _memoDto; }
            set
            {
                _memoDto = value;
                RaisePropertyChanged();
            }
        }

    }

}
