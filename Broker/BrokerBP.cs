using Domen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broker
{
    public class BrokerBP
    {
        OleDbConnection konekcija;

        OleDbCommand komanda;
        OleDbTransaction transakcija;

        void KonektujSe()
        {
            konekcija = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Fakultet\Projektovanje softvera\Ana Basaric - seminarski\PROJEKAT\Projekat\Baza.accdb");

            komanda = konekcija.CreateCommand();
        }

        #region sigleton
        private static BrokerBP instance;

        public static BrokerBP Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BrokerBP();
                }
                return instance;
            }
        }

        private BrokerBP()
        {
            KonektujSe();
        }
        #endregion

        public void PokreniTransakciju()
        {
            transakcija = konekcija.BeginTransaction();
            komanda.Transaction = transakcija;
        }

        public void Commit()
        {
            transakcija.Commit();
        }

        public void Rollback()
        {
            transakcija.Rollback();
        }

        public void OtvoriKonekciju()
        {
            konekcija.Open();
        }

        public void ZatvoriKonekciju()
        {
            konekcija.Close();
        }

        public object Ubaci(IOpstiDomenskiObjekat odo)
        {
            komanda.CommandText = $"INSERT INTO {odo.VratiImeTabele()} ({odo.VratiKoloneZaInsert()}) " +
                $"VALUES ({odo.VratiVrednostiZaInsert()})";       
            komanda.CommandType = CommandType.Text;
            int rezultat = komanda.ExecuteNonQuery();
            if(rezultat == 1)
            {
                komanda.CommandText = "SELECT @@IDENTITY";
                object id = komanda.ExecuteScalar();
                return id;
            } else
            {
                throw new Exception();
            }           
        }

        public List<IOpstiDomenskiObjekat> VratiSve(IOpstiDomenskiObjekat odo)
        {
            List<IOpstiDomenskiObjekat> lista;
            komanda.CommandText = $"SELECT * FROM {odo.VratiImeTabele()}";
            komanda.CommandType = CommandType.Text;
            OleDbDataReader citac = komanda.ExecuteReader();
            lista = odo.VratiListu(citac);
            citac.Close();
            return lista;
        }

        public IOpstiDomenskiObjekat VratiPrvog(IOpstiDomenskiObjekat odo)
        {
            IOpstiDomenskiObjekat objekat;
            komanda.CommandText = $"SELECT * FROM {odo.VratiImeTabele()} WHERE {odo.VratiKljucIUslov()}";
            komanda.CommandType = CommandType.Text;
            OleDbDataReader citac = komanda.ExecuteReader();
            objekat = odo.VratiObjekat(citac);
            citac.Close();
            return objekat;
        }
        
        public List<IOpstiDomenskiObjekat> VratiSveUslov(IOpstiDomenskiObjekat odo)
        {
            List<IOpstiDomenskiObjekat> lista;
            komanda.CommandText = $"SELECT * FROM {odo.VratiImeTabele()} WHERE {odo.VratiKriterijumPretrage()}";
            komanda.CommandType = CommandType.Text;
            OleDbDataReader citac = komanda.ExecuteReader();
            lista = odo.VratiListu(citac);
            citac.Close();
            return lista;
        }

        //public List<IOpstiDomenskiObjekat> VratiSveKljuc(IOpstiDomenskiObjekat odo)
        //{
        //    List<IOpstiDomenskiObjekat> lista;
        //    komanda.CommandText = $"SELECT * FROM {odo.VratiImeTabele()} WHERE {odo.VratiKljucIUslov()}";
        //    komanda.CommandType = CommandType.Text;
        //    OleDbDataReader citac = komanda.ExecuteReader();
        //    lista = odo.VratiListu(citac);
        //    citac.Close();
        //    return lista;
        //}

        public bool Izmeni(IOpstiDomenskiObjekat odo)
        {
            komanda.CommandText = $"UPDATE {odo.VratiImeTabele()} SET {odo.VratiZaIzmenu()} " +
                $"WHERE {odo.VratiKljucIUslov()}";
            komanda.CommandType = CommandType.Text;
            int rezultat = komanda.ExecuteNonQuery();
            if (rezultat == 1)
            {
                return true;
            }
            else
            {
                throw new Exception();
            }
        }

        public bool Obrisi(IOpstiDomenskiObjekat odo)
        {
            komanda.CommandText = $"DELETE FROM {odo.VratiImeTabele()} WHERE {odo.VratiKljucIUslov()}";
            komanda.CommandType = CommandType.Text;
            int rezultat = komanda.ExecuteNonQuery();
            if (rezultat == 1)
            {
                return true;
            }
            else
            {
                throw new Exception();
            }
        }

    }
}

