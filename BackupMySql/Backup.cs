using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupMySql
{
    public class Backup
    {
        private const string SERVIDOR = "192.168.0.253";
        //private const string SERVIDOR = "localhost";
        private const string USER = "lundy  ";
        private const string SENHA = "12345";
        private const string BANCO = "sisvendas";

        public string file = "C:\\Backup\\Backup_"+ (DateTime.Now.Day.ToString() +"-"+ DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + "_as_" + DateTime.Now.Hour.ToString() + "_e_" + DateTime.Now.Second.ToString()) + ".sql";

        public void fazerBackup()
        {
            string conn = "server="+ SERVIDOR + ";user="+USER+";password="+SENHA+";database="+BANCO+";charset=utf8";
             


            using (MySqlConnection con = new MySqlConnection(conn))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = con;
                        con.Open();
                        mb.ExportToFile(file);
                        con.Close();
                    }
                }

            }
        }
    }
}
