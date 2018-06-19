using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;
using ListviewProje.Models.Entity;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using ListviewProje.Models;

namespace ListviewProje.ViewModels
{
    public class StudentViewModel:ViewModelBase
    {
        //‹
        //public event PropertyChangedEventHandler PropertyChanged;

        private string _count;
        int _limit = 5;
        int _total, _pageSize;

        StudentDAO studentDAO = new StudentDAO();

        private int _firstpage,_secondpage,_thirdpage;
        private string _next, _prev;
        private SolidColorBrush _firstcolor, _secondcolor, _thirdcolor;

        public StudentViewModel()
        {
            _deleteCommand = new Command(OnDelete);
            _updateCommand = new Command(OnUpdate);
            _addCommand = new Command(OnAdd);
            _pageChangeCommand = new Command(OnPageChange);

            _firstpage = 1; _secondpage = 2;_thirdpage = 3;
            _prev = "‹"; _next = "";
            _firstcolor = _secondcolor = _thirdcolor = Brushes.Black;
            _total = (int)studentDAO.Count();
            _pageSize = _total / _limit;
            _count = $"{_total} adet kayıt var";
            List.Clear();
            foreach (var item in studentDAO.Find(1, _limit, _pageSize))
            {
                List.Add(item);
            }

            //BindData();
        }

        ICommand _deleteCommand, _updateCommand, _addCommand, _pageChangeCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return _deleteCommand;
            }
            set
            {
                if (_deleteCommand == null)
                {
                    return;
                }
                _deleteCommand = value;
            }
        }
        public ICommand UpdateCommand
        {
            get
            {
                return _updateCommand;
            }
            set
            {
                if (_updateCommand == null)
                {
                    return;
                }
                _updateCommand = value;
            }
        }
        public ICommand AddCommand
        {
            get
            {
                return _addCommand;
            }
            set
            {
                if (_addCommand==null)
                {
                    return;
                }
                _addCommand = value;
            }
        }
        public ICommand PageChangeCommand
        {
            get
            {
                return _pageChangeCommand;
            }
            set
            {
                if (_pageChangeCommand == null)
                {
                    return;
                }
                _pageChangeCommand = value;
            }
        }


        private void BindData()
        {

            StudentDAO studentDAO = new StudentDAO();
            studentDAO.Insert(new Student
            {
                Name = "Hasan234",
                Surname = "Gedik456"
            });
            studentDAO.Insert(new Student
            {
                Name = "45",
                Surname = "65"
            });
            studentDAO.Insert(new Student
            {
                Name = "Abc",
                Surname = "23"
            });

            studentDAO.Insert(new Student
            {
                Name = "Hasan234",
                Surname = "Gedik456"
            });
            studentDAO.Insert(new Student
            {
                Name = "45",
                Surname = "65"
            });
            studentDAO.Insert(new Student
            {
                Name = "Abc",
                Surname = "23"
            });
            studentDAO.Insert(new Student
            {
                Name = "Hasan234",
                Surname = "Gedik456"
            });
            studentDAO.Insert(new Student
            {
                Name = "45",
                Surname = "65"
            });
            studentDAO.Insert(new Student
            {
                Name = "Abc",
                Surname = "23"
            });
        }

        private void OnDelete(object param)
        {
            var item = (MenuItem)param;
            var selectedModel = (Student)item.CommandParameter;
            if (selectedModel != null)
            {
                List.Remove(selectedModel);
            }
        }

        private void OnUpdate(object param)
        {
            var item = (MenuItem)param;
            var selectedModel = (Student)item.CommandParameter;
            if (selectedModel != null)
            {

            }
        }

        private void OnAdd(object param)
        {

        }

        private void OnPageChange(object e)
        {
            List.Clear();
            Label lbl = (Label)e;
            //lbl.Foreground = Brushes.Red;
            var isNumeric = int.TryParse(lbl.Content.ToString(), out int n);
            int page=0;
            if (isNumeric)
            {
                page= Convert.ToInt32(lbl.Content);
                SetData(page);
            }
            else if(lbl.Content.ToString()== "‹")
            {
                PrevPage(FirstPage);
                SetData(FirstPage);
            }
            else if(lbl.Content.ToString() == "›")
            {

            }

            // İlk Sayfa Butonuna Basarsan Önceki Sayfaya Git
            if (page==FirstPage)
            {
                PrevPage(page);
            }
            else
            {
                NextPage(page);
            }
        }

        private void ColorChange(int page)
        {
            if (page==1)
            {
                FirstColor = Brushes.Red;
                SecondColor = Brushes.Black;
                ThirdColor = Brushes.Black;
            }
            else if (page==SecondPage)
            {
                FirstColor = Brushes.Black;
                SecondColor = Brushes.Red;
                ThirdColor = Brushes.Black;
            }
            else
            {
                FirstColor = Brushes.Black;
                SecondColor = Brushes.Black;
                ThirdColor = Brushes.Red;
            }
            //switch (page)
            //{
            //    case 1:
            //        FirstColor = Brushes.Red;
            //        SecondColor = Brushes.Black;
            //        ThirdColor = Brushes.Black;
            //        break;
            //    case 2:
            //        FirstColor = Brushes.Black;
            //        SecondColor = Brushes.Red;
            //        ThirdColor = Brushes.Black;
            //        break;
            //    case 3:
            //        FirstColor = Brushes.Black;
            //        SecondColor = Brushes.Black;
            //        ThirdColor = Brushes.Red;
            //        break;
            //    default:
            //        break;
            //}
        }
        private void NextPage(int page)
        {
            if (page == 1)
            {
                ColorChange(FirstPage);
            }
            else if (page == _pageSize)
            {
                ColorChange(ThirdPage);
            }
            else if (page == SecondPage)
            {
                ColorChange(SecondPage);
            }
            else if (_pageSize > ThirdPage)
            {
                ThirdPage = ThirdPage + 1;
                SecondPage = SecondPage + 1;
                FirstPage = FirstPage + 1;
                ColorChange(SecondPage);
            }
        }
        private void PrevPage(int page)
        {
            if (page == 1)
            {
                ColorChange(FirstPage);
            }
            else if (FirstPage > 1)
            {
                FirstPage = FirstPage - 1;
                SecondPage = SecondPage - 1;
                ThirdPage = ThirdPage - 1;
                ColorChange(SecondPage);
            }
        }
        private void SetData(int page)
        {
            foreach (var item in studentDAO.Find(page, _limit, _pageSize))
            {
                List.Add(item);
            }
        }

        public static ObservableCollection<Student> List { get; set; } = new ObservableCollection<Student>();

        public string Count
        {
            get => _count;
            set
            {
                _count = value;
                RaisePropertyChanged("Count");
            }
        }
        public int FirstPage
        {
            get => _firstpage;
            set
            {
                _firstpage = value;
                //RaisePropertyChanged("FirstPage");
                RaisePropertyChanged(System.Reflection.MethodBase.GetCurrentMethod().GetPropertyName());
            }
        }
        public int SecondPage {
            get => _secondpage;
            set
            {
                _secondpage = value;
                // RaisePropertyChanged("SecondPage");
                RaisePropertyChanged(System.Reflection.MethodBase.GetCurrentMethod().GetPropertyName());

            }
        }
        public int ThirdPage {
            get => _thirdpage;
            set {
                _thirdpage = value;
                //RaisePropertyChanged("ThirdPage");
                RaisePropertyChanged(System.Reflection.MethodBase.GetCurrentMethod().GetPropertyName());
            }
        }

        public string Next
        {
            get => _next;
            set
            {
                _next = value;
                //RaisePropertyChanged("ThirdPage");
                RaisePropertyChanged(System.Reflection.MethodBase.GetCurrentMethod().GetPropertyName());
            }
        }
        public string Prev
        {
            get => _prev;
            set
            {
                _prev = value;
                //RaisePropertyChanged("ThirdPage");
                RaisePropertyChanged(System.Reflection.MethodBase.GetCurrentMethod().GetPropertyName());
            }
        }

        public SolidColorBrush FirstColor
        {
            get => _firstcolor;
            set
            {
                _firstcolor = value;
                RaisePropertyChanged(System.Reflection.MethodBase.GetCurrentMethod().GetPropertyName());
            }
        }
        public SolidColorBrush SecondColor {
            get => _secondcolor;
            set
            {
                _secondcolor = value;
                RaisePropertyChanged(System.Reflection.MethodBase.GetCurrentMethod().GetPropertyName());
            }
        }
        public SolidColorBrush ThirdColor {
            get => _thirdcolor;
            set
            {
                _thirdcolor = value;
                RaisePropertyChanged(System.Reflection.MethodBase.GetCurrentMethod().GetPropertyName());
            }
        }
    }
}
