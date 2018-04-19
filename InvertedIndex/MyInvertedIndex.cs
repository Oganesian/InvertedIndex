using System.Collections.Generic;

namespace InvertedIndex
{
    class MyInvertedIndex
    {
        private List<List<int>> invertedIndexes = new List<List<int>>();

        private List<string> searchQueries = new List<string>();
        private List<string> searchSources = new List<string>();

        //==================================//
        //           CONSTRUCTORS           //
        //==================================//

        /// <summary>
        /// Initializes an InvertedIndex object
        /// </summary>
        /// <param name="searchQueries">List of search queries</param>
        /// <param name="searchSources">List of strings to search in</param>
        public MyInvertedIndex(List<string> searchQueries, List<string> searchSources)
        {
            this.searchQueries = searchQueries;
            this.searchSources = searchSources;

            FindInvertedIndexes();
        }

        /// <summary>
        /// Initializes an InvertedIndex object
        /// </summary>
        /// <param name="searchQuery">Search query</param>
        /// <param name="searchSource">String to search in</param>
        public MyInvertedIndex(string searchQuery, string searchSource)
        {
            searchQueries = new List<string>();
            searchQueries.Add(searchQuery);

            searchSources = new List<string>();
            searchSources.Add(searchSource);

            FindInvertedIndexes();
        }
        /// <summary>
        /// Initializes an InvertedIndex object
        /// </summary>
        /// <param name="searchQueries">List of search queries</param>
        /// <param name="searchSource">String to search in</param>
        public MyInvertedIndex(List<string> searchQueries, string searchSource)
        {
            this.searchQueries = searchQueries;

            searchSources = new List<string>();
            searchSources.Add(searchSource);

            FindInvertedIndexes();
        }

        /// <summary>
        /// Initializes an InvertedIndex object
        /// </summary>
        /// <param name="searchQuery">Search query</param>
        /// <param name="searchSources">> of strings to search in</param>
        public MyInvertedIndex(string searchQuery, List<string> searchSources)
        {
            searchQueries = new List<string>();
            searchQueries.Add(searchQuery);

            this.searchSources = searchSources;

            FindInvertedIndexes();
        }

        //==================================//
        //      GETTERS AND SETTERS         //
        //==================================//

        public void setSearchQueries(List<string> searchQueries)
        {
            this.searchQueries = searchQueries;
        }

        public List<string> getSearchQueries()
        {
            return searchQueries;
        }

        public void setSearchSources(List<string> searchSources)
        {
            this.searchSources = searchSources;
        }

        public List<string> getSearchSources()
        {
            return searchSources;
        }

        public void setSearchQuery(string searchQuery)
        {
            searchQueries = new List<string>();
            searchQueries.Add(searchQuery);
        }

        public void setSearchSource(string searchSource)
        {
            searchSources = new List<string>();
            searchSources.Add(searchSource);
        }

        public string getSearchQuery()
        {
            return searchQueries[0];
        }

        public string getSearchSource()
        {
            return searchSources[0];
        }

        //==================================//
        //             METHODS              //
        //==================================//

        /// <summary>
        /// Performs an inverted index search on the previously specified search string(-s) 
        /// and the source string(-s)
        /// </summary>
        private void FindInvertedIndexes()
        {
            int queryIndex = 0;
            int sourceIndex = 0;
            foreach(string sQuery in searchQueries)
            {
                invertedIndexes.Add(new List<int>());
                foreach(string sSource in searchSources)
                {
                    if (sSource.Contains(sQuery))
                    {
                        invertedIndexes[queryIndex].Add(sourceIndex);
                    }
                    sourceIndex++;
                }
                sourceIndex = 0;
                queryIndex++;
            }
        }

        public override string ToString()
        {
            string toString = "";
            int sourceIndex = 0;
            foreach(string query in searchQueries)
            {
                toString += "\"" + query + "\" \t{ ";
                foreach (int invertedIndex in invertedIndexes[sourceIndex])
                {
                    toString += invertedIndex + ", ";
                }
                if(invertedIndexes[sourceIndex].Count > 0)
                    toString = toString.Remove(toString.Length - 2); // Remove last comma
                toString += " }\n";
                sourceIndex++;
            }
            return toString;
        }
    }
}
