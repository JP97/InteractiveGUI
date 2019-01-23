using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InteractiveGUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	
	public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
		}
		Controller cont = Controller.GetInstance();


		private void btn_NewPerson(object sender, RoutedEventArgs e)
		{
			cont.AddPerson();
			Agetb.Text = "0";
			Firstnametb.IsEnabled = true;
			Lastnametb.IsEnabled = true;
			Agetb.IsEnabled = true;
			Teletb.IsEnabled = true;
			Up.IsEnabled = true;
			Down.IsEnabled = true;
			Delete_Person.IsEnabled = true;

			Firstnametb.Text = null;
			Lastnametb.Text = null;
			//Agetb.Text = null;
			Teletb.Text = null;

			Person_Count.Text = "Person Count: " + cont.PersonCount;
			Index.Text = "Index: " + cont.PersonIndex;
			//Firstnametb.Text = cont.CurrentPerson.FirstName;
			//Lastnametb.Text = cont.CurrentPerson.LastName;
			//Agetb.Text = cont.CurrentPerson.Age.ToString();
			//Teletb.Text = cont.CurrentPerson.TelephoneNo;
		}

		private void btn_Down(object sender, RoutedEventArgs e)
		{
			if (cont.PersonIndex == 0)
			{
				Down.IsEnabled = false;
			}
			else
			{
				cont.PrevPerson();

				ResetText();
			}

			Index.Text = "Index: " + cont.PersonIndex;
		}

		private void btn_DeletePerson(object sender, RoutedEventArgs e)
		{

			if(cont.PersonCount > 0)
			{
				cont.DeletePerson();
				cont.PrevPerson();

				if(cont.PersonCount != 0)
				{
					ResetText();
				}
				else
				{
					Firstnametb.IsEnabled = false;
					Lastnametb.IsEnabled = false;
					Agetb.IsEnabled = false;
					Teletb.IsEnabled = false;
					Up.IsEnabled = false;
					Down.IsEnabled = false;
					Delete_Person.IsEnabled = false;
				}
			}


			Index.Text = "Index: " + cont.PersonIndex;
			Person_Count.Text = "Person Count: " + cont.PersonCount;
		}

		private void btn_Up(object sender, RoutedEventArgs e)
		{

			if (cont.PersonIndex == cont.PersonCount - 1)
			{
				Up.IsEnabled = false;
			}
			else
			{
				cont.NextPerson();

				ResetText();
			}

			Index.Text = "Index: " + cont.PersonIndex;
		}


		private void ResetText()
		{
			Firstnametb.Text = cont.CurrentPerson.FirstName;
			Lastnametb.Text = cont.CurrentPerson.LastName;
			Agetb.Text = cont.CurrentPerson.Age.ToString();
			Teletb.Text = cont.CurrentPerson.TelephoneNo;
		}

		private void TextChange_LastName(object sender, TextChangedEventArgs e)
		{
			cont.CurrentPerson.LastName = Lastnametb.Text;
		}

		private void TextChange_Firstname(object sender, TextChangedEventArgs e)
		{
			cont.CurrentPerson.FirstName = Firstnametb.Text;
		}

		private void TextChange_Age(object sender, TextChangedEventArgs e)
		{
			cont.CurrentPerson.Age = Convert.ToInt32(Agetb.Text);
		}

		private void TextChanged_Tele(object sender, TextChangedEventArgs e)
		{
			cont.CurrentPerson.TelephoneNo = Teletb.Text;
		}
	}
}
