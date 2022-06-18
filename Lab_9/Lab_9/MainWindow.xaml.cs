using System;
using System.Collections.Generic;
using System.Linq;
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
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lab_9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int pageNumber = 1;
        int pageSize = 20;
        string snippetsType = "cs"; // C#

        public MainWindow()
        {
            InitializeComponent();
            ReloadPage();
        }

        public void ReloadPage()
        {
            PageReposne reponse = FetchSnippets(pageNumber, pageSize, snippetsType);
            List<SnippetReponse> snippetList = new List<SnippetReponse>();

            foreach (SnippetReponse snippet in reponse.Batches)
            {
                snippetList.Add(new SnippetReponse() { Size = snippet.Size, Name = snippet.Name, Type = snippet.Type, CreationTime = snippet.CreationTime, UpdateTime = snippet.UpdateTime });
            }

            dgSimple.ItemsSource = snippetList;
        }

        public static PageReposne FetchSnippets(int pageNumber, int pageSize, string snippetsType)
        {
            string url = $"https://dirask.com/api/snippets?pageNumber={pageNumber}&pageSize={pageSize}&dataOrder=newest&dataGroup=batches&snippetsType={Uri.EscapeUriString(snippetsType)}";
            string data = FetchData(url);

            return JsonSerializer.Deserialize<PageReposne>(data);
        }
        public class PageReposne
        {
            [JsonPropertyName("pageNumber")]
            public int PageNumber { get; set; }

            [JsonPropertyName("pagesCount")]
            public int PagesCount { get; set; }

            [JsonPropertyName("pageSize")]
            public int PageSize { get; set; }

            [JsonPropertyName("totalCount")]
            public int TotalCount { get; set; }

            [JsonPropertyName("batches")]
            public List<SnippetReponse> Batches { get; set; }
        }
        public class SnippetReponse
        {
            [JsonPropertyName("size")]
            public int Size { get; set; }

            [JsonPropertyName("type")]
            public string Type { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("creationTime")]
            public DateTime? CreationTime { get; set; }

            [JsonPropertyName("updateTime")]
            public DateTime? UpdateTime { get; set; }
        }

        public static string FetchData(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                ContentType type = new ContentType(response.ContentType ?? "text/plain;charset=" + Encoding.UTF8.WebName);
                Encoding encoding = Encoding.GetEncoding(type.CharSet ?? Encoding.UTF8.WebName);

                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream, encoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        private void Text_Click(object sender, RoutedEventArgs e)
        {
            snippetsType = "text";
            ReloadPage();
        }

        private void Bash_Click(object sender, RoutedEventArgs e)
        {
            snippetsType = "bash";
            ReloadPage();
        }

        private void cpp_Click(object sender, RoutedEventArgs e)
        {
            snippetsType = "cpp";
            ReloadPage();
        }

        private void cs_Click(object sender, RoutedEventArgs e)
        {
            snippetsType = "cs";
            ReloadPage();
        }

        private void java_Click(object sender, RoutedEventArgs e)
        {
            snippetsType = "java";
            ReloadPage();
        }

        private void css_Click(object sender, RoutedEventArgs e)
        {
            snippetsType = "css";
            ReloadPage();
        }

        private void html_Click(object sender, RoutedEventArgs e)
        {
            snippetsType = "html";
            ReloadPage();
        }

        private void javascript_Click(object sender, RoutedEventArgs e)
        {
            snippetsType = "javascript";
            ReloadPage();
        }

        private void php_Click(object sender, RoutedEventArgs e)
        {
            snippetsType = "php";
            ReloadPage();
        }

        private void python_Click(object sender, RoutedEventArgs e)
        {
            snippetsType = "python";
            ReloadPage();
        }

        private void sql_Click(object sender, RoutedEventArgs e)
        {
            snippetsType = "sql";
            ReloadPage();
        }

        private void page1_Click(object sender, RoutedEventArgs e)
        {
            pageNumber = 1;
            ReloadPage();
        }

        private void page2_Click(object sender, RoutedEventArgs e)
        {
            pageNumber = 2;
            ReloadPage();
        }

        private void page3_Click(object sender, RoutedEventArgs e)
        {
            pageNumber = 3;
            ReloadPage();
        }

        private void page4_Click(object sender, RoutedEventArgs e)
        {
            pageNumber = 4;
            ReloadPage();
        }

        private void page5_Click(object sender, RoutedEventArgs e)
        {
            pageNumber = 5;
            ReloadPage();
        }

        private void page6_Click(object sender, RoutedEventArgs e)
        {
            pageNumber = 6;
            ReloadPage();
        }

        private void page7_Click(object sender, RoutedEventArgs e)
        {
            pageNumber = 7;
            ReloadPage();
        }

        private void ComboBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void comboPageSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dgSimple == null)
            {
                return;
            }

            switch (comboPageSize.SelectedIndex)
            {
                case 0: pageSize = 5;
                    break;
                case 1: pageSize = 20;
                    break;
                case 2: pageSize = 50;
                    break;
                case 3:pageSize = 100;
                    break;
            }

            //pageSize = Int32.Parse(((Label)comboPageSize.SelectedItem).Content.ToString());
            ReloadPage();
        }
    }
}
