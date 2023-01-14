using Curso_LinQ;

LinqQueries queries = new LinqQueries();
//PrintBooks(queries.HigherPagesAndContain());
//Console.WriteLine("Todos los libros tienen Status?: "+queries.BooksStatusNotNull());
//Console.WriteLine("Existen libros publicados en el año 2005?: "+ (queries.atLeastIn2005() ? "SI" : "NO"));
//PrintBooks(queries.BooksPython());
//PrintBooks(queries.BooksJavaForName());
//PrintBooks(queries.BooksMajor450Pages());
//Console.WriteLine("Libros de Java publicados recientemenete");
//PrintBooks(queries.BooksPublishedRecentJava());
//Console.WriteLine("Tercer y cuarto libro con más de 400 paginas");
//PrintBooks(queries.TercerCuartoLibro400Pag());
//PrintBooks(queries.BooksThirdCollection());
//Console.WriteLine("Cantidad de libros que contienen entre 200 y 500 páginas: "+queries.CountBookIn200And500());
//Console.WriteLine("El libro mas viejo se publicó en: "+queries.PublishDateOld().ToShortDateString());
//Console.WriteLine("El libro con más paginas contiene: "+queries.BookPageMax());
//Console.WriteLine("El libro con menor número de paginas es: ");
//PrintBook(queries.BookPageMin());
//Console.WriteLine("El libro recien publicado es: ");
//PrintBook(queries.BookPublishedDateRecent());
//Console.WriteLine("Suma total de paginas entre 0 y 500: "+queries.SumAllBooks0And500());
//Console.WriteLine(queries.BookAfter2015Concat());
//Console.WriteLine("Promedio de caracteres del titulo de los libros: "+ queries.AverageCharacterTitle());
//Console.WriteLine("El promedio de páginas mayor a 0 de cada libro es de: "+Math.Round(queries.AveragePages(),2));
//Console.WriteLine("Libros agrupados por año");
//ImprimirGrupo(queries.BooksAfter2000GroupByYear());

//Console.WriteLine("Agrupados por la inicial del titulo");
//ImprimirDiccionario(queries.DictonaryByChar(),'E');
Console.WriteLine("Libros filtrados con Join");
PrintBooks(queries.BooksJoin());
void ImprimirGrupo(IEnumerable<IGrouping<int,Book>> ListadeLibros)
{
    foreach(var grupo in ListadeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: { grupo.Key }");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach(var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}",item.Title,item.PageCount,item.PublishedDate.Date.ToShortDateString()); 
        }
    }
}

void PrintBooks(IEnumerable<Book> lista){
    Console.WriteLine("\n{0,-60} {1,15} {2,15}","Title","Page count","Publisher Date");
    Console.WriteLine("=============================================================================================");

    foreach(var item in lista){
        Console.WriteLine("{0,-60} {1,15} {2,15}",item.Title,item.PageCount,item.PublishedDate.ToShortDateString());
    }
}

void PrintBook(Book item){
    Console.WriteLine("\n{0,-60} {1,15} {2,15}","Title","Page count","Publisher Date");
    Console.WriteLine("=============================================================================================");
    Console.WriteLine("{0,-60} {1,15} {2,15}",item.Title,item.PageCount,item.PublishedDate.ToShortDateString());
}

void ImprimirDiccionario(ILookup<char, Book> ListadeLibros, char letra)
{
   Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
   foreach(var item in ListadeLibros[letra])
   {
         Console.WriteLine("{0,-60} {1, 15} {2, 15}",item.Title,item.PageCount,item.PublishedDate.Date.ToShortDateString()); 
   }
}