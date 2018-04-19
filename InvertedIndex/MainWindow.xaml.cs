using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace InvertedIndex
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> filesPaths;
        public MainWindow()
        {
            InitializeComponent();
            filesPaths = new List<string>();
        }

        private void Add_Files_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filename in openFileDialog.FileNames)
                {
                    if (!filesPaths.Contains(filename))
                    {
                        SourceFilesListBox.Items.Add(filename);
                        filesPaths.Add(filename);
                    }
                }
            }
        }

        private void Clear_File_List_Click(object sender, RoutedEventArgs e)
        {
            filesPaths.Clear();
            SourceFilesListBox.Items.Clear();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string searchQueriesT = searchQueries.Text;

            string[] _searchQueries =
                searchQueriesT.Split(',');
            List<string> searchQueriesList = new List<string>();
            List<string> searchSources = new List<string>();

            foreach(string searchQuery in _searchQueries)
            {
                string sQuery = searchQuery;
                sQuery = searchQuery.Replace("\\W", "");
                if (sQuery.StartsWith(" "))
                {
                    searchQueriesList.Add(sQuery.Substring(1));
                }
                else
                {
                    searchQueriesList.Add(sQuery);
                }
            }
            foreach(string filePath in filesPaths)
            {
                string source = File.ReadAllText(filePath);
                searchSources.Add(source);
            }

            MyInvertedIndex myInvertedIndex = 
                new MyInvertedIndex(searchQueriesList, searchSources);
            Output.Text = myInvertedIndex.ToString();
        }
    }
}
