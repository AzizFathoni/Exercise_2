using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Exepabd
{
    class Program
    {
      

      public void Connecting()
        {
            using (
                SqlConnection con = new SqlConnection("data source=LAPTOP-VG11B78I;database=ApotekAziz; Integrated Security = True")
            )
            {
                con.Open();
                Console.WriteLine("Berhasil terhubung ke database!");
            }
        }
        public void Create()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=LAPTOP-VG11B78I;database=ApotekAziz; Integrated Security = True");
                con.Open();

                SqlCommand cm = new SqlCommand("create table Karyawan (Kode_kr char(3) Primary Key not null, Nama_kr varchar(80), Alamat_kr varchar(80))" 
                    + "create table Konsumen (Kode_ko char(3) Primary Key not null, Nama_ko varchar(80), Alamat_ko varchar(80))"
                    + "create table Supplier(Kode_su char(3) not null Primary Key, Alamat varchar(80), Jlh_Brg_masuk varchar(80))" 
                    + "create table Obat(Kode_obat char(3) not null Primary Key, Kode_su char(3) FOREIGN KEY REFERENCES Supplier(Kode_su), Nama_obat varchar(80))"
                    + "create table Transaksi(Kode_t char(3) not null primary key, Kode_obat char(3) FOREIGN KEY REFERENCES Obat(Kode_Obat), Kode_ko char(3) FOREIGN KEY REFERENCES Konsumen(Kode_ko), Kode_kr char(3) FOREIGN KEY REFERENCES Karyawan(Kode_kr), Waktu_transaksi varchar (80), Harga_obat varchar(80))", con);
                cm.ExecuteNonQuery();

                Console.WriteLine("Tabel sukses dibuat!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops, Sepertinya ada yang salah. " + e);
                Console.ReadKey();
            }
            finally
            {
                con.Close();
            }
        }
        public void InsertData()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=LAPTOP-VG11B78I;database=ApotekAziz; Integrated Security = True");
                con.Open();

                SqlCommand cm = new SqlCommand(
                      "insert into Karyawan (Kode_kr, Nama_kr, Alamat_kr) values ('54A','Aziz','Bandung')"
                    + "insert into Konsumen(Kode_ko, Nama_ko, Alamat_ko) values ('45A','Fathoni','Jakarta')"
                    + "insert into Supplier(Kode_su, Alamat, Jlh_Brg_masuk) values ('35A','bantul','500 Dus')"
                    + "insert into Obat(Kode_obat,Kode_su,Nama_obat) values ('PA1','35A','Paracetamol')"
                    + "insert into Transaksi(Kode_t,Kode_obat,Kode_ko,Kode_kr,Waktu_transaksi,Harga_obat) values ('kl1','PA1','45A','54A','5 April 2022','50.000.000')", con);
                cm.ExecuteNonQuery();


                Console.WriteLine("Data sukses diinput");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Sepertinya ada yang salah" + e);
                Console.ReadKey();
            }
            finally
            {
                con.Close();
            }
        }
        static void Main(string[] args)
        {
            //new Program().Connecting();

            new Program().Create();

            new Program().InsertData();
        }
    }
}