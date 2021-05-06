using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WebToObj
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            webread();


        }
        public static int[] bla = new int[] { 2, 3, 3,5,3,1 };
        List<List<string>> list = new List<List<string>>(); 
        List<string> listi = new List<string>();
        public static void recusion(HtmlAgilityPack.HtmlNode doc)
        {
            var ol2 = doc.Elements("div");
            if (ol2.Count() > 0)
            {
                recusion(doc);
            }
            else
            {

            }

        }

        public static void webread()
        {
            List<string> listi=new List<string>();
            using (var client = new WebClient())
            {
                string result = client.DownloadString("https://www.yazio.com/de/kalorientabelle/hefe.html");

                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(result);
                     var ol = doc.DocumentNode;
                for (int i = 0; i < bla.Count(); i++)
                {

                    ol = ol.ChildNodes[bla[i]];

                    //var ol2 = ol.Elements("div");
                    //if (ol2.Count()>0)
                    //{
                    //    for (int j = 0; j < ol2.Count(); j++)
                    //    {
                    //        ol = ol2.ElementAt(j);
                    //    }
                    //}
                    //else
                    //{
                    //}

                }
                var ol2 = ol.Elements("div");
                if (ol2.Count() > 0)
                {

                    for (int j = 0; j < ol2.Count(); j++)
                    {
                        recusion(ol2.ElementAt(j));
                        //ol = ol2.ElementAt(j);
                    }
                }
                else
                {
                }


                //var ol2 = doc.DocumentNode.ChildNodes[0].ChildNodes[0].DocumentNode.Element("div");
                // var ol3 = doc.DocumentNode.ChildNodes[0].ChildNodes[0].DocumentNode.Element("div");
                // var ol4 = doc.DocumentNode.ChildNodes[0].ChildNodes[0].DocumentNode.Element("div");
                //doc.DocumentNode.ChildNodes[0].ChildNodes[0]
                //var list = Recurse(doc.DocumentNode);
                //WebRequest request = CreateWebRequest(uri);
                //WebResponse response = request.GetResponse();
                //result = GetPageHtml(response);
            }
        }
        List<Person> Recurse(HtmlAgilityPack.HtmlNode root)
        {

            

            var ol = root.Element("div");
            if (ol == null) return null;

            return ol.Elements("div")
                        .Select(li => new Person
                        {
                            Name = li.FirstChild.InnerText.Trim(),
                            //Children = Recurse(li)
                        })
                        .ToList();
        }
    }
    public class PeopleList
    {
        public List<Person> People { get; set; }
    }

    public class Person
    {
        public string Name { get; set; }
        public PeopleList Children { get; set; }
    }
}
