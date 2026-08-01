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
using GitFlow.Entities.Interfaces.IServices;
using GitFlow.Entities.Models;
using Microsoft.Extensions.DependencyInjection;
namespace GitFlow.UI
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Page
    {
        private readonly IServices<Person> _PersonService; 
        public AddEmployee([FromKeyedServices("CrudService")] IServices<Person> Service)
        {
            _PersonService =Service;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person();
            person.Firstname = FIRSTNAMETxtBx.Text;
            person.Lastname = LASTNAMETxtBx.Text;   
            person.Gender = GenderTxtBx.Text;   
            person.Dni = DNITxtBx1.Text;
            person.Birthdate = DateOnly.FromDateTime(BirthDatePicker.SelectedDate.Value);
            
            _PersonService.Create(person);
        }
    }
}
