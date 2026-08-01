using GitFlow.Entities.Interfaces.IServices;
using GitFlow.Entities.Models;
using Microsoft.Extensions.DependencyInjection;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IServices<Person> _personService;

        public MainWindow([FromKeyedServices("CrudService")] IServices<Person> PersonService)
        {
            _personService = PersonService;
            _personService.setUp();
            InitializeComponent();
            
         
        }

        private async void MainCrudDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        
        }

        private async void MainCrudDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            List<Person> People = await _personService.GetAllAsync();
            MainCrudDataGrid.ItemsSource = People;
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddEmployee(_personService));
        }
    }
}