using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BaiTapXml
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("++Start++");
            getKhachHang();
            Console.WriteLine("++End++");
            Console.ReadKey();

        }


        public static void getSach()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Phong.xml");
            XmlNodeList listSach = doc.DocumentElement.ChildNodes;
            for (int i = 0; i < listSach.Count; i++)
            {
                XmlNodeList listItem = listSach[i].ChildNodes;
                for (int j = 0; j < listItem.Count; j++) {
                    XmlNode node = listItem[j];
                    if (node.Name == "MaPhong" && node.InnerText.Equals("1"))
                        Console.WriteLine(listSach[i].InnerText);

                }
            }

        }

        public static string getMaPhong() {
            string maPhong = null;
            XmlDocument doc = new XmlDocument();
            doc.Load("Phong.xml");
            XmlNodeList listPhong = doc.DocumentElement.ChildNodes;
            for (int i = 0; i < listPhong.Count; i++)
            {
                XmlNodeList phong = listPhong[i].ChildNodes;
                for (int j = 0; j < phong.Count; j++) {
                    if(phong[j].Name.Equals("TenP") && phong[j].InnerText.Equals("R01"))
                        maPhong = phong[j].PreviousSibling.InnerText;
                }
            }
            return maPhong;
        }

        public static List<string> getListMaKhach() {
            List<string> listMaKhach = new List<string>();
            string maPhong = getMaPhong();

            XmlDocument doc = new XmlDocument();
            doc.Load("ThuePhong.xml");
            XmlNodeList listThuePhong = doc.DocumentElement.ChildNodes;
            for (int i = 0; i < listThuePhong.Count; i++) {
                XmlNodeList thuephong = listThuePhong[i].ChildNodes;
                for (int j = 0; j < thuephong.Count; j++) {
                    if (thuephong[j].Name.Equals("MaP") && thuephong[j].InnerText.Equals(maPhong)) {
                        //Console.WriteLine(thuephong[j].PreviousSibling.InnerText);
                        listMaKhach.Add(thuephong[j].PreviousSibling.InnerText.ToString());
                    }
                       
                }
            }

            return listMaKhach;
        }

        public static void getKhachHang() {
            List<string> listMaKhachHang = getListMaKhach();
            XmlDocument doc = new XmlDocument();
            doc.Load("KhachHang.xml");
            XmlNodeList listKhachHang = doc.DocumentElement.ChildNodes;
            for (int i = 0; i < listKhachHang.Count; i++) {
                XmlNodeList khachhang = listKhachHang[i].ChildNodes;
                foreach (string makhach in listMaKhachHang) {
                    for(int j = 0; j < khachhang.Count; j++)
                    {
                        if (khachhang[j].Name.Equals("MaKH") && khachhang[j].InnerText.Equals(makhach))
                            Console.WriteLine(listKhachHang[i].InnerText);
                    }
                }
            }
        }

    }
}
