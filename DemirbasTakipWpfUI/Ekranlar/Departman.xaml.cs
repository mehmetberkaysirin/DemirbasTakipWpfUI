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
using System.Windows.Shapes;
using DemirbasTakipWpfUI.DataAccess;
using DemirbasTakipWpfUI.Entities;


namespace DemirbasTakipWpfUI.Ekranlar
{
    /// <summary>
    /// Interaction logic for Departman.xaml
    /// </summary>
    public partial class Departman : Window
    {
        public Departman()
        {
            InitializeComponent();
        }
        DepartmantDal departmantDal = new DepartmantDal();
        public void DepertmanList()
        {
            cmbDepartman.ItemsSource = departmantDal.GetList();
            cmbDepartman.DisplayMemberPath = "Name";
            cmbDepartman.SelectedValuePath = "Id";
        }
        private void BtnSaveDepartman_Click(object sender, RoutedEventArgs e)
        {
            int sonuc = departmantDal.Add(new Departmant
            {
                Name = txbDepartman.Text
            });
            if (sonuc == 1)
                MessageBox.Show("Kayıt başarılı!");
            DepertmanList();
            txbDepartman.Text = "";
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            DepertmanList();
        }
    }
}
