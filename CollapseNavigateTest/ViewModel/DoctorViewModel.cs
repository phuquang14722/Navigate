using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using CollapseNavigateTest.Model;

namespace CollapseNavigateTest.ViewModel
{
    class DoctorViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public int CheckedCount;
        public List<Doctor> doctors = new List<Doctor>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public List<Doctor> Doctors
        {
            get { return doctors; }
            set { doctors = value; OnPropertyChanged("Doctors"); }
        }

        private bool? isCheckedAll;

        public bool? IsCheckedAll
        {
            get { return isCheckedAll; }
            set { isCheckedAll = value; OnPropertyChanged("IsCheckedAll"); }
        }

        public ICommand AllCheckedCommand { get; set; }
        public ICommand SingleCheckedCommand { get; set; }

        public DoctorViewModel()
        {
            Doctors.Add(new Doctor() { ID = 1, Name = "Quang 2k4", Age = 17, Phone = "02323432", Mail = "1@kteam.com", Sex = SexType.Nam, Birthday = (new DateTime(2004, 1, 1)).ToString("dd/MM/yyyy") });
            Doctors.Add(new Doctor() { ID = 2, Name = "Quang 2k2", Age = 19, Phone = "02323432", Mail = "2@kteam.com", Sex = SexType.Nam, Birthday = (new DateTime(2002, 1, 1)).ToString("dd/MM/yyyy") });
            Doctors.Add(new Doctor() { ID = 3, Name = "Lộc wibu", Age = 7, Phone = "02323432", Mail = "3@kteam.com", Sex = SexType.Nam, Birthday = (new DateTime(2002, 1, 1)).ToString("dd/MM/yyyy") });
            Doctors.Add(new Doctor() { ID = 4, Name = "Nghĩa tay to", Age = 39, Phone = "02323432", Mail = "3@kteam.com", Sex = SexType.Nam, Birthday = (new DateTime(2002, 1, 1)).ToString("dd/MM/yyyy") });
            Doctors.Add(new Doctor() { ID = 5, Name = "Tuấn khỉ", Age = 39, Phone = "02323432", Mail = "3@kteam.com", Sex = SexType.Nam, Birthday = (new DateTime(2002, 1, 1)).ToString("dd/MM/yyyy") });
            CheckedCount = 0;
            IsCheckedAll = false;
            AllCheckedCommand = new RelayCommand<CheckBox>((p) => { return p == null ? false : true; }, (p) =>
            {
                bool allcheckbox = (p.IsChecked == true);
                for (int i = 0; i < Doctors.Count; i++)
                    Doctors[i].IsChecked = allcheckbox;
            });

            SingleCheckedCommand = new RelayCommand<CheckBox>((p) => { return p == null ? false : true; }, (p) =>
            {
                IsCheckedAll = null;
                if (p.IsChecked == true)
                    CheckedCount++;
                else
                    CheckedCount--;

                if (CheckedCount == doctors.Count)
                    IsCheckedAll = true;
                else
                    if (CheckedCount == 0)
                    IsCheckedAll = false;
            });
        }
    }
}
