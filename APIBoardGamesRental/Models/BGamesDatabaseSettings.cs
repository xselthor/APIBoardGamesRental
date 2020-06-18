using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBoardGamesRental.Models
{
    public class BGamesDatabaseSettings : IBGamesDatabaseSettings
    {
        public string BGamesCollectionName { get; set; }
        public string BBasketCollectionName { get; set; }
        public string BUnitCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IBGamesDatabaseSettings
    {
        string BGamesCollectionName { get; set; }
        string BBasketCollectionName { get; set; }
        string BUnitCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
