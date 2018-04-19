using System.Collections.Generic;

namespace InvertedIndex
{
    class MyInvertedIndex
    {
        private List<string> searchQueriesList
        {
            get { return searchQueriesList; }
            set
            {
                searchQueriesList = value;
                searchQueries = null;
            }
        }

        private List<string> searchSources
        {
            get { return searchSources; }
            set
            {
                searchSources = value;
                searchSource = null;
            }
        }

        private string searchQueries
        {
            get { return searchQueries; }
            set
            {
                searchQueries = value;
                searchQueriesList = null;
            }
        }

        private string searchSource
        {
            get { return searchSource; }
            set
            {
                searchSource = value;
                searchSources = null;
            }
        }

        /// <summary>
        /// Initializes an InvertedIndex object
        /// </summary>
        /// <param name="searchQueriesList">List of search queries</param>
        /// <param name="searchSources">List of strings to search in</param>
        public MyInvertedIndex(List<string> searchQueriesList, List<string> searchSources)
        {
            this.searchQueriesList = searchQueriesList;
            this.searchSources = searchSources;
        }

        /// <summary>
        /// Initializes an InvertedIndex object
        /// </summary>
        /// <param name="searchQueries"></param>
        /// <param name="searchSource"></param>
        public MyInvertedIndex(string searchQueries, string searchSource)
        {
            this.searchQueries = searchQueries;
            this.searchSource = searchSource;
        }

        /// <summary>
        /// Initializes an InvertedIndex object
        /// </summary>
        /// <param name="searchQueriesList"></param>
        /// <param name="searchSource"></param>
        public MyInvertedIndex(List<string> searchQueriesList, string searchSource)
        {
            this.searchQueriesList = searchQueriesList;
            this.searchSource = searchSource;
        }

        /// <summary>
        /// Initializes an InvertedIndex object
        /// </summary>
        /// <param name="searchQueries"></param>
        /// <param name="searchSources"></param>
        public MyInvertedIndex(string searchQueries, List<string> searchSources)
        {
            this.searchQueries = searchQueries;
            this.searchSources = searchSources;
        }

        public override string ToString()
        {
            string toString = "searchQueriesList: ";

            if(searchQueriesList == null)
                toString += "null";
            else
                foreach (string str in searchQueriesList) toString += str + " ";

            toString += "\nsearchSources: ";
            if (searchSources == null)
                toString += "null";
            else
                foreach (string str in searchSources) toString += str + " ";

            toString += "\nsearchQueries: " + searchQueries;
            toString += "\nsearchSource: " + searchSource + "\n";
            return toString;
        }
    }
}
