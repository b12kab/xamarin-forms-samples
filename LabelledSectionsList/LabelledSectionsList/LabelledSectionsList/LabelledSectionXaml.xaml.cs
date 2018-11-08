using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using LabelledSectionsList;

namespace LabelledSections
{
	public partial class LabelledSectionXaml : ContentPage
	{
		public LabelledSectionXaml ()
		{
			InitializeComponent ();
            BindingContext = new ViewModelSection(Navigation);
		}
	}
}

