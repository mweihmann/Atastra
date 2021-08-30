// This is the service for the TNotes class.
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Atastra.Data
{
    
        public class TNotesService : ITNotesService
        {
            // Database connection
            private readonly SqlConnectionConfiguration _configuration;
            public TNotesService(SqlConnectionConfiguration configuration)
            {
                _configuration = configuration;
            }
            // Add (create) a TNotes table row (SQL Insert)
            // This only works if you're already created the stored procedure.
            public async Task<bool> TNotesInsert(TNotes tnotes)
            {
                using (var conn = new SqlConnection(_configuration.Value))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("Summary", tnotes.Summary, DbType.String);
                    parameters.Add("TNotePrio", tnotes.TNotePrio, DbType.String);
                    parameters.Add("Assignee", tnotes.Assignee, DbType.String);
                    parameters.Add("TNoteStatus", tnotes.TNoteStatus, DbType.String);

                    // Stored procedure method
                    await conn.ExecuteAsync("spTNotes_Insert", parameters, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            // Get a list of tnotes rows (SQL Select)
            // This only works if you're already created the stored procedure.
            public async Task<IEnumerable<TNotes>> TNotesGetAll()
            {
                IEnumerable<TNotes> tnotes;
                using (var conn = new SqlConnection(_configuration.Value))
                {
                    tnotes = await conn.QueryAsync<TNotes>("spTNotes_GetAll", commandType: CommandType.StoredProcedure);
                }
                return tnotes;
            }


            // Get one tnotes based on its TNotesID (SQL Select)
            // This only works if you're already created the stored procedure.
            public async Task<TNotes> TNotesGetOne(int @Id)
            {
                TNotes tnotes = new TNotes();
                var parameters = new DynamicParameters();
                parameters.Add("@Id", Id, DbType.Int32);
                using (var conn = new SqlConnection(_configuration.Value))
                {
                    tnotes = await conn.QueryFirstOrDefaultAsync<TNotes>("spTNotes_GetOne", parameters, commandType: CommandType.StoredProcedure);
                }
                return tnotes;
            }
            // Update one TNotes row based on its TNotesID (SQL Update)
            // This only works if you're already created the stored procedure.
            public async Task<bool> TNotesUpdate(TNotes tnotes)
            {
                using (var conn = new SqlConnection(_configuration.Value))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("Id", tnotes.Id, DbType.Int64);

                    parameters.Add("Summary", tnotes.Summary, DbType.String);
                    parameters.Add("TNotePrio", tnotes.TNotePrio, DbType.String);
                    parameters.Add("Assignee", tnotes.Assignee, DbType.String);
                    parameters.Add("TNoteStatus", tnotes.TNoteStatus, DbType.String);

                    await conn.ExecuteAsync("spTNotes_Update", parameters, commandType: CommandType.StoredProcedure);
                }
                return true;
            }

            // Physically delete one TNotes row based on its TNotesID (SQL Delete)
            // This only works if you're already created the stored procedure.
            public async Task<bool> TNotesDelete(int Id)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", Id, DbType.Int32);
                using (var conn = new SqlConnection(_configuration.Value))
                {
                    await conn.ExecuteAsync("spTNotes_Delete", parameters, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
        }
    
}
