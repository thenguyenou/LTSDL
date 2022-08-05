using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
//using ProductClass = NguyenQuangThe.Product;

namespace NguyenQuangThe
{
    public partial class Form1 : Form
    {
        private ProductBUS busProduct;
        public Form1()
        {
            InitializeComponent();
            busProduct = new ProductBUS();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            gvSanPham.DataSource = busProduct.GetProducts();
            busProduct.GetCategories(cbLoaiSP);
            busProduct.GetSuppliers(cbNCC);


        }
        private void btThem_Click(object sender, EventArgs e)
        {
            bool result = false;
            ProductClass p = new ProductClass();

            try
            {
                p.ProductName = txtTenSP.Text.ToString();

                p.Quantity = int.Parse(txtSoLuong.Text);
                p.UnitPrice = double.Parse(txtDonGia.Text);
                p.CategoryId = int.Parse(cbLoaiSP.SelectedValue.ToString());
                p.SupplierId = int.Parse(cbNCC.SelectedValue.ToString());
                result = busProduct.AddProduct(p);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            switch (result)
            {
                case false:
                    MessageBox.Show("Them that bai");
                    break;
                case true:
                    MessageBox.Show("Them thanh cong");

                    gvSanPham.DataSource = busProduct.GetProducts();
                    break;
                


            }



        }

        private void btSua_Click(object sender, EventArgs e)
        {

        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            //bool result;


            //try
            //{
         


            //    result = busProduct.AddProduct(p);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //switch (result)
            //{
            //    case false:
            //        MessageBox.Show("Them that bai");
            //        break;
            //    case true:
            //        MessageBox.Show("Them thanh cong");
            //        break;
             


            //}


        }



        private void gvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

           

        }

     
    }


}
