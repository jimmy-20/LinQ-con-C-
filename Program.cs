// See https://aka.ms/new-console-template for more information
using Curso_LinQ;

LinqQueries queries = new LinqQueries();
ImprimirValores(queries.TodaLaColeccion());

void ImprimirValores(IEnumerable<Book> lista){
    Console.WriteLine("\n{0,-60} {1,15} {2,15}","Title","Page count","Publisher Date");
    Console.WriteLine("=============================================================================================");

    foreach(var item in lista){
        Console.WriteLine("{0,-60} {1,15} {2,15}",item.Title,item.PageCount,item.PublishedDate.ToShortDateString());
    }
}