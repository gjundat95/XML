using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ConvertXMLToSQL
{
    class Library
    {
        public static OpenFileDialog openFileDialog() {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML Files (*.xml)|*.xml";
            ofd.FilterIndex = 0;
            ofd.DefaultExt = "xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                return ofd;
            }
            else {
                return null;
            }
           
        }

        public static int getCountElement(string pathFile) {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(pathFile);
                var root = doc.DocumentElement;
                var element1 = root.ChildNodes[0].ChildNodes;
                return element1.Count;
            }
            catch (XmlException ex) {
                return 0;
                throw ex;
            }
        }

        public static List<string> getElementName(string pathFile) {
            try
            {
                List<string> listElemntName = new List<string>();
                XmlDocument doc = new XmlDocument();
                doc.Load(pathFile);
                var root = doc.DocumentElement;
                var element1 = root.ChildNodes[0].ChildNodes;
                for (int i = 0; i < element1.Count; i++)
                {
                    listElemntName.Add(element1[i].Name);
                }
                return listElemntName;
            }
            catch (XmlException ex) {
                return new List<string>();
                throw ex;
            }
           
        }

        public static List<string> getQuerySQLInsert(string pathFile,List<string> listNameElement, string tableName) {
            List<string> listQuery = new List<string>();
            XmlDocument doc = new XmlDocument();
            doc.Load(pathFile);
            var root = doc.DocumentElement;
            var elementAll = root.ChildNodes;
            for (int i = 0; i < elementAll.Count; i++) {
                string temp = "";
                int count = 0;
                foreach (string item in listNameElement)
                {
                    if (count < listNameElement.Count - 1)
                    {
                        if (elementAll[i].SelectNodes(item)[0].InnerText != null)
                        {
                            temp += " N'" + elementAll[i].SelectNodes(item)[0].InnerText + "' , ";
                        }
                        else
                        {
                            temp +=   DBNull.Value + " , ";
                        }
                    }
                    else {
                        if (elementAll[i].SelectNodes(item)[0].InnerText != null)
                        {
                            temp += " N'" + elementAll[i].SelectNodes(item)[0].InnerText + "' ";
                        }
                        else {
                            temp += DBNull.Value + " , ";
                        }
                    }
                    count++;
                }
                string query = "INSERT INTO " + tableName+ " VALUES ( " + temp+" );";
                listQuery.Add(query);
            }

            return listQuery;
        }

        public static List<string> loadServerName()
        {
            List<string> listServerName = new List<string>();
            DataTable tb = SmoApplication.EnumAvailableSqlServers(true);
            foreach (DataRow item in tb.Rows)
            {
                listServerName.Add("" + item["Name"]);
            }
            return listServerName;
        }

        public static List<string> loadDB(string serverName)
        {
            List<string> listDBName = new List<string>();
            Server server = new Server(serverName);
            foreach (Database item in server.Databases)
            {
                listDBName.Add(item.Name);
            }
            return listDBName;
        }

        public static List<string> loadTable(string serverName, string dbName)
        {
            List<string> listTableName = new List<string>();
            Server server = new Server(serverName);
            foreach (Database item in server.Databases)
            {
                if (item.Name.Equals(dbName))
                {
                    foreach (Table it in item.Tables)
                    {
                        listTableName.Add(it.Name);
                    }

                }
            }
            return listTableName;
        }


    }
}
