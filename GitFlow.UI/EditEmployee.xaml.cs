using GitFlow.Entities.Interfaces.IServices;
using GitFlow.Entities.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GitFlow.UI
{
    /// <summary>
    /// Interaction logic for EditEmployee.xaml
    /// </summary>
    public partial class EditEmployee : Page
    {
        private readonly IServices<Person> _PersonService;
        public EditEmployee(int PersonId, [FromKeyedServices("CrudService")] IServices<Person> Service)
        {
            _PersonService = Service;
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person();
            person.Firstname = FIRSTNAMETxtBx.Text;
            person.Lastname = LASTNAMETxtBx.Text;
            person.Gender = GenderTxtBx.Text;
            person.Dni = DNITxtBx1.Text;
            person.Birthdate = DateOnly.FromDateTime(BirthDatePicker.SelectedDate.Value);
            _PersonService.Update(this.PersistId, person);
            this.IsEnabled = false;
            this.Visibility = Visibility.Collapsed;
                        
        }
    }
}
