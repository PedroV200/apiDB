using Npgsql;
using Dapper;



/*
public class expression 
{
    // ID unico de la expresion. PK en la DB ?
    public int expID;
    // Valor en string de la expresion
    public string strExpression=string.Empty;
    // Nombre de la expression
    public string nombre=string.Empty;
    // Sector / libros XLS al cual perteneces
    public string dominio=string.Empty;
    // tipo numerico de la expresion en formato string
    public string dataType=string.Empty;
    // ultima vez que se modifico
    public string lastAccess=string.Empty;
    // Descripcion (notas opcionales)
    public string descripcion=string.Empty;
}*/


public class ExpressionRepository: IExpressionRepository
{
    private readonly IConfiguration _configuration;
    string connectString="";
    public ExpressionRepository(IConfiguration configuration)
    {
        _configuration=configuration;
    }

    public async Task<IEnumerable<expression>> getAll()
    {
        var sqlery="SELECT * FROM expressionstbl";
        var connection=new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        connection.Open(); 
        var result = await connection.QueryAsync<expression>(sqlery);
        return result;

    }

    public async Task<expression> getById(int id)
    {
        var sqlery=$"SELECT * FROM expressionsTbl WHERE {id}=expid";
        var connection=new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        connection.Open();
        var result = await connection.QuerySingleOrDefaultAsync<expression>(sqlery);
        return result;
    }

    public async Task<int> update(expression myExp)
    {
        var sqlery= @"UPDATE expressionstbl SET 
                    strexpression=@strexpression, 
                    nombre=@nombre, 
                    dominio=@dominio, 
                    data_type=@data_type, 
                    lastaccess=@lastaccess, 
                    description=@description 
                                            WHERE 
                                                expid=@expid";
        var connection=new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        connection.Open();
        var result=await connection.ExecuteAsync(sqlery,myExp);
        return result;
    }

    public async Task<int> add(expression myExp)
    {
        var sqlery=@"INSERT INTO expressionstbl
                    (expid,
                     strexpression,
                     nombre,
                     dominio,
                     data_type,
                     lastaccess,
                     description) VALUES 
                                        (@expid,
                                         @strexpression,
                                         @nombre,
                                         @dominio,
                                         @data_type,
                                         @lastaccess,
                                         @description)";

        var connection=new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        connection.Open();
        var result=await connection.ExecuteAsync(sqlery,myExp);
        return result;      
    }

    public async Task<int> delete(expression myExp)
    {
        var sqlery=$"DELETE FROM expressionsTbl WHERE expid='{myExp.expid}'";
        var connection=new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        connection.Open();
        var result=await connection.ExecuteAsync(sqlery,myExp);
        return result;
    }
}
