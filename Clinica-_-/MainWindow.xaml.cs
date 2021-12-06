using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
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

namespace Clinica___
{
    public enum TableType
    {
        Journal,Patient,Diagnosis,Doctor,Adress
    }

    
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DbService db; //Для работы с базой
        TableType currentTableType; //Хранит текущую открытую таблицу

        public MainWindow()
        {
            new LoginWindow().ShowDialog();

            InitializeComponent();
            //Инициализация и обновление списка видеокарт
            db = new DbService();
            currentTableType = TableType.Journal;
            RefreshTable(currentTableType);
        }

        //Обновляет таблицу (пока что только для видеокарт)
        private void RefreshTable(TableType tt)
        {
            db = new DbService(); //Создаём обект базы данных
            CollectionViewSource vs = new CollectionViewSource();
            switch (tt)
            {
                case TableType.Patient:
                    db.Patient.Load(); //Загружаем данные из базы
                    vs.Source = db.Patient.Local;
                    this.PatientTable.ItemsSource = vs.View;
                    this.PatientTable.AddingNewItem += (sender, e) => e.NewItem = new Patient() { Name = "<новый>" };

                    Views.PatientView = vs;
                    break;
                case TableType.Diagnosis:
                    db.Diagnosis.Load(); //Загружаем данные из базы
                    vs.Source = db.Diagnosis.Local;
                    this.DiagnosisTable.ItemsSource = vs.View;
                    this.DiagnosisTable.AddingNewItem += (sender, e) => e.NewItem = new Diagnosis() { Name = "<новый>" };

                    Views.DiagnosisView = vs;
                    break;
                case TableType.Doctor:
                    db.Doctor.Load(); //Загружаем данные из базы
                    vs.Source = db.Doctor.Local;
                    this.DoctorTable.ItemsSource = vs.View;
                    this.DoctorTable.AddingNewItem += (sender, e) => e.NewItem = new Doctor() { Name = "<новый>" };

                    Views.DoctorView = vs;
                    break;
                case TableType.Adress:
                    db.Adress.Load(); //Загружаем данные из базы
                    vs.Source = db.Adress.Local;
                    this.AdressTable.ItemsSource = vs.View;
                    this.AdressTable.AddingNewItem += (sender, e) => e.NewItem = new Adress() { Name = "<новый>" };

                    Views.AdressView = vs;
                    break;
                case TableType.Journal:
                    db.Journal.Load(); //Загружаем данные из базы                   
                    vs.Source = db.Journal.Local;
                    this.JournalTable.ItemsSource = vs.View;
                    this.JournalTable.AddingNewItem += (sender, e) => e.NewItem = new Journal() { PatientID = 0, DiagnosisID = 0, DoctorID = 0, AdressID = 0 };
                    this.colPatient.ItemsSource = db.Patient.ToArray();
                    this.colDiagnosis.ItemsSource = db.Diagnosis.ToArray();
                    this.colDoctor.ItemsSource = db.Doctor.ToArray();
                    this.colAdress.ItemsSource = db.Adress.ToArray();

                    Views.JournalView = vs;
                    break;

            }
        }
        private void SaveChanges(TableType tt)
        {
            db.SaveChanges(); //Сохраняем изменения

            DataGrid currTable = null;
            switch (tt)
            {
                case TableType.Patient:
                    currTable = PatientTable;
                    break;
                case TableType.Diagnosis:
                    currTable = DiagnosisTable;
                    break;
                case TableType.Doctor:
                    currTable = DoctorTable;
                    break;
                case TableType.Adress:
                    currTable = AdressTable;
                    break;
                case TableType.Journal:
                    currTable = JournalTable;
                    break;
            }

            int si = currTable.SelectedIndex;//Сохраняем индекс текущей выделенной строки
            RefreshTable(tt); //Обновляем таблицу
            PatientTable.SelectedIndex = si; //Выделяем строку
        }

        private void DeleteRecord(TableType tt)
        {
            switch (tt)
            {
                case TableType.Patient:
                    if (PatientTable.SelectedItem is Patient v && v.Journal.Count == 0)
                        db.Patient.Local.Remove(v);
                    else
                        MessageBox.Show("Данные пациента уже записаны в журнале. Удаление невозможно!",
                            "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    break;
                case TableType.Diagnosis:
                    if (DiagnosisTable.SelectedItem is Diagnosis p && p.Journal.Count == 0)
                        db.Diagnosis.Local.Remove(p);
                    else
                        MessageBox.Show("Данные пациента уже записаны в журнале. Удаление невозможно!",
                            "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    break;
                case TableType.Doctor:
                    if (DoctorTable.SelectedItem is Doctor b && b.Journal.Count == 0)
                        db.Doctor.Local.Remove(b);
                    else
                        MessageBox.Show("Данные пациента уже записаны в журнале. Удаление невозможно!",
                            "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    break;
                case TableType.Adress:
                    if (AdressTable.SelectedItem is Adress n && n.Journal.Count == 0)
                        db.Adress.Local.Remove(n);
                    else
                        MessageBox.Show("Данные пациента уже записаны в журнале. Удаление невозможно!",
                            "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    break;
                case TableType.Journal:
                    if (JournalTable.SelectedItem is Journal m)
                        db.Journal.Local.Remove(m);
                    break;
            }
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            SaveChanges(currentTableType);
        }

        private void CancelChangesButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshTable(currentTableType);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteRecord(currentTableType);
        }

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TabItem ti)
            {
                TableType old = currentTableType;

                string header = ti.Header.ToString();
                if (header == "Пациенты")
                    currentTableType = TableType.Patient;
                else if (header == "Диагнозы")
                    currentTableType = TableType.Diagnosis;
                else if (header == "Доктора")
                    currentTableType = TableType.Doctor;
                else if (header == "Адреса")
                    currentTableType = TableType.Adress;
                else if (header == "Журал")
                    currentTableType = TableType.Journal;

                if (currentTableType != old)
                    RefreshTable(currentTableType);
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Views.JournalView.Filter += (o, ea) =>
            {
                if (ea.Item is Journal v)
                {
                    
                    string Pat = v.Patient.Name.ToLower();
                    string Dig = v.Diagnosis.Name.ToLower();
                    string Doc = v.Doctor.Name.ToLower();
                    string Adr = v.Adress.Name.ToLower();
                    if (Pat.Contains(JournalSearchPat.Text.ToLower())&&
                    Dig.Contains(JournalSearchDig.Text.ToLower())&&
                    Doc.Contains(JournalSearchDoc.Text.ToLower())&&
                    Adr.Contains(JournalSearchAdr.Text.ToLower()))
                    {
                        ea.Accepted = true;
                    }
                    else
                    {
                        ea.Accepted = false;
                    }
                }
            };
        }

        private void CancelSearchButton_Click(object sender, RoutedEventArgs e)
        {
            Views.JournalView.Filter += (o, ea) => ea.Accepted = true;
            JournalSearchPat.Text = "";
            JournalSearchDig.Text = "";
            JournalSearchDoc.Text = "";
            JournalSearchAdr.Text = "";
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            Report Report = new Report();
            switch (currentTableType)
            {
                case TableType.Journal:
                    Report.JournalGen(Views.JournalView.Source as IList<Journal>);
                    break;
            }
        }
    }
}
