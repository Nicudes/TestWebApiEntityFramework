using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PragueDbTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        private CustomersDataAccess dataAccess;
        public Page1()
        {
            InitializeComponent();

            this.dataAccess = new CustomersDataAccess();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.BindingContext = this.dataAccess;
        }
        private void Save_Activated(object sender, EventArgs e)
        {
            this.dataAccess.SaveAllCustomers();
        }

        private void Add_Activated(object sender, EventArgs e)
        {
            this.dataAccess.AddNewCustomer();
        }

        private void Remove_Activated(object sender, EventArgs e)
        {
            var currentCustomer = this.CustomersView.SelectedItem as Customer;
            if (currentCustomer!=null)
            {
                this.dataAccess.DeleteCustomer(currentCustomer);
            }
        }

        private async void RemoveAll_Activated(object sender, EventArgs e)
        {
            if (this.dataAccess.Customers.Any())
            {
                var result = await DisplayAlert("Confirmation", "Are you totally ok with deleting errythang?", "OK", "Cancel");
                if (result == true)
                {
                    this.dataAccess.DeleteAllCustomers();
                    this.BindingContext = this.dataAccess;
                }
            }
        }

   
    }
}