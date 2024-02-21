using CsvHelper.Configuration;
using TodoApi.Models;

namespace TodoApi.Mappers
{
    public class SPTransactionMap : ClassMap<SPTransaction>
    {
        public SPTransactionMap()
        {
            Map(m => m.Id).Name("Id");
            Map(m => m.TransactionType).Name("Transaction Type");
        }
    }
}