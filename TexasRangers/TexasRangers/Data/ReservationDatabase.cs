using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using TexasRangers.Model;

namespace TexasRangers.Data
{
    public class ReservationDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public ReservationDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Reservation>().Wait();
        }

        public Task<List<Reservation>> GetNotesAsync()
        {
            return _database.Table<Reservation>().ToListAsync();
        }

        public Task<Reservation> GetNoteAsync(int id)
        {
            return _database.Table<Reservation>()
                            .Where(i => i.Reservation_ID == id)
                            .FirstOrDefaultAsync();
        }
        public Task<int> SaveNoteAsync(Reservation note)
        {
            if (note.Reservation_ID != 0)
            {
                return _database.UpdateAsync(note);
            }
            else
            {
                return _database.InsertAsync(note);
            }
        }

        public Task<int> DeleteNoteAsync(Reservation note)
        {
            return _database.DeleteAsync(note);
        }
    }
}
