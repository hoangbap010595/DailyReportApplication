using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace DailyReport
{
    public static class BrandModel
    {
        public static string Brand { get; set; }
        public static string BrandMain { get; set; }


        public static void SaveBrandToFile(DataTable dt)
        {

            if (File.Exists(@"Brand.txt"))
                File.Delete(@"Brand.txt");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var brand = dt.Rows[i]["Brand"].ToString();
                var brandMain = dt.Rows[i]["BrandMain"].ToString();
                using (StreamWriter file = new StreamWriter(@"Brand.txt", true))
                {
                    file.WriteLine(brand + "|" + brandMain);
                }
            }
        }

        public static DataTable OpenBrandFromFile()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Brand");
            dt.Columns.Add("BrandMain");
            try
            {
                string[] lines = File.ReadAllLines(@"Brand.txt");

                foreach (string line in lines)
                {
                    DataRow dr = dt.NewRow();
                    dr["Brand"] = line.Split('|')[0].ToUpper().Trim();
                    dr["BrandMain"] = line.Split('|')[1].ToUpper().Trim();
                    dt.Rows.Add(dr);
                }
            }
            catch { }
            return dt;
        }
    }
}
