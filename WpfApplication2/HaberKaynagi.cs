using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace WpfApplication2
{
    class HaberKaynagi
    {
        public class Haber
        {
            public string id { get; set; }
            public string haberurl { get; set; }
            public string haberbaslik { get; set; }
            public string haberozet { get; set; }

            public bool yeni { get; set; }

            public string renk { get
                {
                    if (yeni == true)
                    {
                        return "red";
                    }
                    else
                    {
                        return "white";
                    }
                } }
        }

        List<Haber> Haberler = new List<Haber>();


        public void HaberGuncelle()
        {
            XmlDocument xmlkaynak = new XmlDocument();
            xmlkaynak.Load("http://aa.com.tr/tr/rss/default?cat=guncel");


            for(int i = 5; i <xmlkaynak.ChildNodes[0].ChildNodes[0].ChildNodes.Count; i++)
            {
                bool yenihaber = true;
                Haber a = new Haber();
                a.haberbaslik = xmlkaynak.ChildNodes[0].ChildNodes[0].ChildNodes[i].ChildNodes[2].InnerText;
                a.id = xmlkaynak.ChildNodes[0].ChildNodes[0].ChildNodes[i].ChildNodes[0].InnerText;
                a.haberozet = xmlkaynak.ChildNodes[0].ChildNodes[0].ChildNodes[i].ChildNodes[3].InnerText;
                a.haberurl = xmlkaynak.ChildNodes[0].ChildNodes[0].ChildNodes[i].ChildNodes[1].InnerText;
                a.yeni = true;
                for(int j = 0; j < Haberler.Count; j++)
                {
                    if (Haberler[j].id == a.id)
                    {
                        yenihaber = false;
                        Haberler[j] = a;
                        Haberler[j].yeni = false;
                        break;
                    }
                }
                if (yenihaber == true)
                {
                    Haberler.Add(a);
                }

            }

        }

        public List<Haber> HaberleriVer()
        {
            HaberGuncelle();
            return Haberler;
        }

    }
}
