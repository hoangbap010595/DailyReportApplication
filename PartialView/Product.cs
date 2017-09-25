using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartialView.DAL;
using System.Data.SqlClient;

namespace PartialView
{
    public class Product
    {

        public Product()
        {
        }
        public string Barcode { get; set; }
        public string Model { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Price { get; set; }
        public int Unit { get; set; }
        public string GroupType { get; set; }
        public string ProductName { get; set; }
        public string Properties { get; set; }
        public int BrandID { get; set; }
        public int CategoryID { get; set; }

        public bool InsertUpdate(Product p)
        {
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@Barcode",p.Barcode)
                    ,new SqlParameter("@Model", p.Model)
                    ,new SqlParameter("@Size",p.Size)
                    ,new SqlParameter("@Color", p.Color)
                    ,new SqlParameter("@Price",p.Price)
                    ,new SqlParameter("@Unit",p.Unit)
                    ,new SqlParameter("@GroupType",p.GroupType)
                    ,new SqlParameter("@ProductName",p.ProductName)
                    ,new SqlParameter("@Properties",p.Properties)
                    ,new SqlParameter("@BrandID",p.BrandID)
                    ,new SqlParameter("@CategoryID",p.CategoryID)
                };
                int ok = v1SqlHelper.ExecuteNonQuery(sqlConnection.Conn(), "InsertUpdateProduct", para);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(Product p)
        {
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@Barcode",p.Barcode)
                };
                int ok = v1SqlHelper.ExecuteNonQuery(sqlConnection.Conn(), "DeleteProduct", para);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
