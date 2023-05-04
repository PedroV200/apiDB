// Representacion de un elemento expression

public class expression 
{
    // ID unico de la expresion. PK en la DB ?
    public int expid{ get; set; } 
    // Valor en string de la expresion
    public string strexpression { get; set; }
    // Nombre de la expression
    public string nombre { get; set; }
    // Sector / libros XLS al cual perteneces
    public string dominio { get; set; }
    // tipo numerico de la expresion en formato string
    public string data_type { get; set; }
    // ultima vez que se modifico
    public string lastaccess { get; set; }
    // Descripcion (notas opcionales)
    public string description { get; set; }
}