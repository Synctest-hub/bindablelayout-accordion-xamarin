using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace AccordionXamarin
{
    public class ViewModel : INotifyPropertyChanged
    {
        #region Properties
        public ObservableCollection<ContactInfo> Contacts { get; set; }
        public Command<object> TapCommand { get; set; }

        #endregion

        #region Constructor

        public ViewModel()
        {
            Contacts = new ObservableCollection<ContactInfo>();
            TapCommand = new Command<object>(OnTapped);
            Contacts.Add(new ContactInfo() { Type = "A", Contacts = new ObservableCollection<Contact>() { new Contact() { ContactName = "Adam" }, new Contact { ContactName = "Aaron" } } });
            Contacts.Add(new ContactInfo() { Type = "B", Contacts = new ObservableCollection<Contact>() { new Contact() { ContactName = "Bolt" }, new Contact { ContactName = "Bush" } } });
            Contacts.Add(new ContactInfo() { Type = "C", Contacts = new ObservableCollection<Contact>() { new Contact() { ContactName = "Clark" }, new Contact { ContactName = "Clara" } } });
        }

        #endregion

        #region Private Methods

        private void OnTapped(object obj)
        {

            var data = obj as Contact;
            App.Current.MainPage.DisplayAlert("Message", "Tapped Accoridon item is : " + data.ContactName, "Ok");

        }
        #endregion

        #region Interface Member

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
