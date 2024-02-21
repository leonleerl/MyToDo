using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Shared.Dtos
{

    public class ToDoDto : BaseDto
    {
        private string title;
        private string content;
        private string status;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }
        public string Content
        {
            get { return content; }
            set
            {
                content = value;
                OnPropertyChanged();
            }
        }
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged();
            }
        }
    }
}
