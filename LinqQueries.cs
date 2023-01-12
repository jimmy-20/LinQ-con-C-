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
    }
}