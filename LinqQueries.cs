namespace Curso_LinQ
{
    public class LinqQueries
    {
        private List<Book> librosCollection = new List<Book>();
        private readonly string fileBooks = "books.json";

        public LinqQueries()
        {
            if (File.Exists(fileBooks)){
                using (StreamReader reader = new StreamReader("books.json")){
                string json = reader.ReadToEnd();
                this.librosCollection = System.Text.Json.JsonSerializer.
                                        Deserialize<List<Book>>
                                        (json,
                                        new System.Text.Json.JsonSerializerOptions() 
                                            { PropertyNameCaseInsensitive = true });
                }
            }
            
        }

        public IEnumerable<Book> TodaLaColeccion(){
            return this.librosCollection;
        }

        public IEnumerable<Book> PublishDateAfterOf(){
            //Extension Method
            //return librosCollection.Where(b => b.PublishedDate.Year > 2000);

            //Query expresion
            return from b in librosCollection where b.PublishedDate.Year > 2000 select b;
        }

        public IEnumerable<Book> HigherPagesAndContain(){
            return from b in librosCollection where b.PageCount > 250 && b.Title.Contains("in Action") select  b;
        }

        public bool BooksStatusNotNull(){
            return librosCollection.All(p => p.Status != string.Empty);
        }

        public bool atLeastIn2005(){
            return librosCollection.Any(b => b.PublishedDate.Year == 2005);
        }

        public IEnumerable<Book> BooksPython(){
            return librosCollection.Where(b => b.Categories.Contains("Python"));
        }

        public IEnumerable<Book> BooksJavaForName(){
            return (from b in librosCollection where b.Categories.Contains("Java") orderby b.Title select b);
        }

        public IEnumerable<Book> BooksMajor450Pages(){
            return from b in librosCollection where b.PageCount > 450 orderby b.PageCount descending select b;
        }

        public IEnumerable<Book> BooksPublishedRecentJava(){
            return (from b in librosCollection where b.Categories.Contains("Java") orderby b.PublishedDate descending select b).Take(3);
        }

        public IEnumerable<Book> TercerCuartoLibro400Pag(){
            return librosCollection.Where(b => b.PageCount> 400).OrderByDescending(b => b.PageCount).Take(4).Skip(2);
        }

        public IEnumerable<Book> BooksThirdCollection(){
            return librosCollection.Take(3).Select(b => new Book(){Title = b.Title, PageCount = b.PageCount});
        }

        public int CountBookIn200And500(){
            return librosCollection.Where(b => b.PageCount >= 200 && b.PageCount <= 500).Count();
        }

        public DateTime PublishDateOld(){
            return librosCollection.Min(b => b.PublishedDate);
        }

        public int PageMax(){
            return librosCollection.Max(b => b.PageCount);
        }

        public Book BookPageMin(){
            return librosCollection.Where(p => p.PageCount > 0).MinBy(b => b.PageCount);
        }

        public Book BookPublishedDateRecent(){
            return librosCollection.MaxBy(b => b.PublishedDate);
        }

        public int SumAllBooks0And500(){
            return librosCollection.Where(b=> b.PageCount >= 0 && b.PageCount <= 500).Sum(b => b.PageCount);
        }

        public string BookAfter2015Concat(){
            return librosCollection.Where(b => b.PublishedDate.Year > 2015 ).Aggregate("",(Titulos,next) =>  {
                if (Titulos != string.Empty){
                    Titulos += " - " + next.Title;
                }else{
                    Titulos += next.Title;
                }

                return Titulos;
            });
        }

        public double AverageCharacterTitle(){
            return librosCollection.Average(b => b.Title.Length);
        }

        //Obtener el promedio del número de paginas mayor a 0
        public double AveragePages(){
            return (from b in librosCollection where b.PageCount > 0 select b).Average(b => b.PageCount);
        }

        public IEnumerable<IGrouping<int,Book>> BooksAfter2000GroupByYear(){
            return librosCollection.Where(b => b.PublishedDate.Year >= 2000).GroupBy(b => b.PublishedDate.Year);
        }

        public ILookup<char,Book> DictonaryByChar(){
            return librosCollection.ToLookup(p => p.Title[0], p => p);
        }

        public IEnumerable<Book> BooksJoin(){
            var after2005 = librosCollection.Where(b => b.PublishedDate.Year > 2005);
            var major500 = librosCollection.Where(b => b.PageCount > 500);

            return after2005.Join(major500,b => b.Title,x=> x.Title,(b,x) => b);
        }
    }
}