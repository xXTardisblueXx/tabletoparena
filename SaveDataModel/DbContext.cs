using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDataModel
{
    public class SaveDataContext : DbContext
    {
        public DbSet<SaveGame> SaveGames { get; set; }
    }

    public class SaveGame
    {
        public SaveGame()
        {
            CreatedOn = DateTime.Now;
        }
        public Guid Id { get; set; }
        [Required]
        public String MapName { get; set; }
        [Required]
        public String MapString { get; set; }
        public int Columns { get; set; }
        public int Rows { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
