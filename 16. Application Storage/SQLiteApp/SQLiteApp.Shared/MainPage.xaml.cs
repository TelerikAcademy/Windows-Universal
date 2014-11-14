using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SQLiteApp;
using SQLite;
using Windows.Storage;
using SQLiteApp.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SQLiteApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private const string dbName = "News.db";

        public List<Article> articles { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Create Db if not exist
            bool dbExists = await CheckDbAsync(dbName);
            if (!dbExists)
            {
                await CreateDatabaseAsync();
                await AddArticlesAsync();
            }
            
            // Get Articles
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            var query = conn.Table<Article>();
            articles = await query.ToListAsync();

            // Show users
            ArticleList.ItemsSource = articles;
        }

        #region SQLite utils
        private async Task<bool> CheckDbAsync(string dbName)
        {
            bool dbExist = true;

            try
            {
                StorageFile sf = await ApplicationData.Current.LocalFolder.GetFileAsync(dbName);
            }
            catch (Exception)
            {
                dbExist = false;
            }

            return dbExist;
        }

        private async Task CreateDatabaseAsync()
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            await conn.CreateTableAsync<Article>();
        }

        private async Task AddArticlesAsync()
        {
            // Create a Articles list
            var list = new List<Article>()
            {
                new Article()
                {
                    Title = "Hackers exploit touch payment tech",
                    Content = "Security experts testing ways to break smartphone software have found several bugs in the NFC payment system found on many handsets."
                },
                new Article()
                {
                    Title = "Assassin's Creed glitches criticised",
                    Content = "Widespread glitches in French Revolution-set Assassin's Creed: Unity have put its publisher Ubisoft under pressure."
                }
            };

            // Add rows to the Article Table
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            await conn.InsertAllAsync(list);
        }

        private async Task SearchArticleByTitleAsync(string title)
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);

            AsyncTableQuery<Article> query = conn.Table<Article>().Where(x => x.Title.Contains(title));
            List<Article> result = await query.ToListAsync();
            foreach (var article in result)
            {
                // ...
            }

            var allArticles = await conn.QueryAsync<Article>("SELECT * FROM Articles");
            foreach (var article in allArticles)
            {
                // ...
            }

            var otherArticles = await conn.QueryAsync<Article>(
                "SELECT Content FROM Articles WHERE Title = ?", new object[] { "Hackers, Creed" });
            foreach (var article in otherArticles)
            {
                // ...
            }
        }

        private async Task UpdateArticleTitleAsync(string oldTitle, string newTitle)
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);

            // Retrieve Article
            var article = await conn.Table<Article>()
                .Where(x => x.Title == oldTitle).FirstOrDefaultAsync();
            if (article != null)
            {
                // Modify Article
                article.Title = newTitle;

                // Update record
                await conn.UpdateAsync(article);
            }
        }

        private async Task DeleteArticleAsync(string name)
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);

            // Retrieve Article
            var article = await conn.Table<Article>().Where(x => x.Title == name).FirstOrDefaultAsync();
            if (article != null)
            {
                // Delete record
                await conn.DeleteAsync(article);
            }
        }

        private async Task DropTableAsync(string name)
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            await conn.DropTableAsync<Article>();
        }

        #endregion SQLite utils
    }
}
