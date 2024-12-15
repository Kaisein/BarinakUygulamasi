using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Barınakv
{
    class Sqlbaglant
    {
         public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-RQS85JQ\SQLEXPRESS;Initial Catalog=Barınak;Integrated Security=True");
            baglan.Open();
            return baglan; 
        }
    }
}
