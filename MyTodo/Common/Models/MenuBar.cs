using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.Common.Models
{
    public class MenuBar : BindableBase
    {

		private string _icon;

		public string Icon
		{		
			get { return _icon; }
			set { _icon = value; }
		}

		private string _title;

		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}

		private string _nameSpace;

		public string NameSpace
		{
			get { return _nameSpace; }
			set { _nameSpace = value; }
		}

	}
}
