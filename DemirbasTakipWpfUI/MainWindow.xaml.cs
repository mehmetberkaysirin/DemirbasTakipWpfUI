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
using DemirbasTakipWpfUI.DataAccess;
using DemirbasTakipWpfUI.Ekranlar;
using DemirbasTakipWpfUI.Entities;

namespace DemirbasTakipWpfUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProductDal productDal = new ProductDal();
        DepartmantDal departmantDal = new DepartmantDal();
        PersonnelDal personnelDal = new PersonnelDal();
        AllocationDal allocationDal = new AllocationDal();
        public MainWindow()
        {
            InitializeComponent();
        }
        public void DepertmanList()
        {
            cmbDepartman.ItemsSource = departmantDal.GetList();
            cmbDepartman.DisplayMemberPath = "Name";
            cmbDepartman.SelectedValuePath = "Id";
        }

        private void PersonnelList()
        {
            cmbPersonel.ItemsSource = personnelDal.GetList();
            cmbPersonel.DisplayMemberPath = "FirstName";
            cmbPersonel.SelectedValuePath = "Id";
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Listele();

            DepertmanList();
            PersonnelList();
            cbStatus.IsChecked = true;
        }

        private void CmbDepartman_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int departmanId = Convert.ToInt32(cmbDepartman.SelectedValue);
            cmbPersonel.ItemsSource = personnelDal.GetList(p => p.DepartmantId == departmanId);
            cmbPersonel.DisplayMemberPath = "FirstName";
            cmbPersonel.SelectedValuePath = "Id";
        }

        //urunlistesini datagride doldurur.
        private void Listele()
        {
            dgProducts.ItemsSource = productDal.GetList();
            dgAllocations.ItemsSource = allocationDal.GetList();
        }

        private void BtnSaveProduct_Click(object sender, RoutedEventArgs e)
        {

            int sonuc = productDal.Add(new Product
            {
                Name = txbProductName.Text,
                Price = Convert.ToDecimal(txbPrice.Text)
            });
            if (sonuc == 1)
                MessageBox.Show("Kayıt başarılı!");

            Listele();
           
        }

        private void DgProducts_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            
        }

        private void DgProducts_MouseEnter(object sender, MouseEventArgs e)
        {
          
        }

        private void BtnsaveAllocation_Click(object sender, RoutedEventArgs e)
        {
            Boolean a;
            if (cbStatus.IsChecked==true){ a = true;}
            else{a = false;}
            int sonuc = allocationDal.Add(new Allocation
            {
                ProductId = Convert.ToInt32(txbProductId.Text),
                PersonelId = Convert.ToInt32(cmbPersonel.SelectedValue),
                IslemId = Convert.ToInt32(txbIslem.Text),
                StartDate = Convert.ToDateTime(StartDate.Text),
                EndDate = Convert.ToDateTime(EndDate.Text),
                Status = a,
                Description= txbDescription.Text
            });
            if (sonuc == 1)
                MessageBox.Show("Kayıt başarılı!");

            Listele();
        }

        

        private void BtnPersonnelSave_Click(object sender, RoutedEventArgs e)
        {
            int sonuc = personnelDal.Add(new Personnel
            {
                FirstName = txbPersonnelName.Text,
                LastName = txbPersonelLastName.Text,
                DepartmantId = Convert.ToInt32(cmbDepartman.SelectedValue),
            });
            if (sonuc == 1)
                MessageBox.Show("Kayıt başarılı!");
            PersonnelList();
            txbPersonnelName.Text = "";
        }

        private void BtnDepartmantAdd_Click(object sender, RoutedEventArgs e)
        {
            Departman departmant = new Departman();
            
            departmant.ShowDialog();
            
        }
    }
}
