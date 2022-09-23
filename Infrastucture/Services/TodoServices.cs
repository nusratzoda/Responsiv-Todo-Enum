using Dapper;
using Domain.Entites;
using Domain.Wraper;
using Npgsql;
namespace Infrastucture.Services;
public class TodoServices
{
    private string _conectionString;
    public TodoServices()
    {
        _conectionString = " Server = 127.0.0.1; Port = 5432; Database = Tododb; User Id = postgres; Password = 882003421sb.";
    }
    public async Task<Response<List<Todo>>> GetTodo()
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            try
            {
                var response = await connection.QueryAsync<Todo>($"select * from Todo;");
                return new Response<List<Todo>>(response.ToList());
            }
            catch (Exception ex)
            {
                return new Response<List<Todo>>(System.Net.HttpStatusCode.InternalServerError, ex.Message);

            }
        }
    }
    public async Task<Response<Todo>> AddTodo(Todo todo)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            try
            {
                var sql = $"INSERT into Todo(title, Status)VALUES('{todo.Title}',{(int?)todo.Status})";
                var id = await connection.ExecuteScalarAsync<int>(sql);
                todo.Id = id;
                return new Response<Todo>(todo);
            }
            catch (Exception ex)
            {
                return new Response<Todo>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
    public async Task<Response<Todo>> UpdateTodo(Todo todo)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            string sql = $"UPDATE Todo SET Title = '{todo.Title}', status = {(int?)todo.Status}' WHERE Id = {todo.Id};";
            try
            {
                var response = await connection.ExecuteAsync(sql);
                return new Response<Todo>(System.Net.HttpStatusCode.OK, "Success");
            }
            catch (Exception ex)
            {
                return new Response<Todo>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
    public async Task<Response<int>> DeleteTodo(int id)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(_conectionString))
        {
            string sql = $"delete from Todo where Id = '{id}';";
            try
            {
                var response = await connection.ExecuteAsync(sql);
                return new Response<int>(System.Net.HttpStatusCode.OK, "Success");
            }
            catch (Exception ex)
            {
                return new Response<int>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}