using System.Data.SqlClient;
using Kolokwium1.DTOs;
using Kolokwium1.Models;

namespace Kolokwium1.Repositories;

public class FireActionRepo : IFireActionRepo
{
    private IConfiguration _configuration;

    public FireActionRepo(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
     public async Task<Firefighter> GetFirefighterByIdAsync(int id)
    {
        using SqlConnection con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * FROM Firefighter " +
                          "WHERE IdFirefighter = @IdFirefighter";
        cmd.Parameters.AddWithValue("@IdFirefighter", id);

        using (var dr = await cmd.ExecuteReaderAsync())
        {
            while (await dr.ReadAsync())
            {
                return new Firefighter
                {
                    IdFirefight = Int32.Parse(dr["IdFirefighter"].ToString()),
                    FirstName = dr["FirstName"].ToString(),
                    LastName = dr["LastName"].ToString()
                };
            }
        }

        return null;
    }

    public async Task<IEnumerable<FireActionDTO>> GetActionsForFirefighter(int id)
    {
        using SqlConnection con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * FROM FireAction " +
                          "JOIN Firefighter_Action ON FireAction.IdFireAction = Firefighter_Action.IdFireAction " +
                          "WHERE Firefighter_Action.IdFirefighter = @IdFirefighter " +
                          "ORDER BY EndTime DESC";
        cmd.Parameters.AddWithValue("@IdFirefighter", id);

        var actionsList = new List<FireActionDTO>();

        using (var dr = await cmd.ExecuteReaderAsync())
        {
            while (await dr.ReadAsync())
            {
                int IdFireAction = Int32.Parse(dr["IdFireAction"].ToString());
                DateTime StartTime = DateTime.Parse(dr["StartTime"].ToString());

                actionsList.Add(new FireActionDTO
                (
                    IdFireAction, 
                    StartTime
                ));
            }
        }

        return actionsList;
    }

    public async Task<FireAction> GetFireActionByIdAsync(int id)
    {
        using SqlConnection con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * FROM FireAction " +
                          "WHERE IdFireAction = @IdFireAction";
        cmd.Parameters.AddWithValue("@IdFireAction", id);

        using (var dr = await cmd.ExecuteReaderAsync())
        {
            while (await dr.ReadAsync())
            {
                return new FireAction
                {
                    IdFireAction = Int32.Parse(dr["IdFireAction"].ToString()),
                    StartTime = DateTime.Parse(dr["StartTime"].ToString()),
                    EndTime = DateTime.Parse(dr["EndTime"].ToString()),
                    NeedSpecialEquipment = byte.Parse(dr["NeedSpecialEquipment"].ToString())
                };
            }
        }

        return null;
    }
}