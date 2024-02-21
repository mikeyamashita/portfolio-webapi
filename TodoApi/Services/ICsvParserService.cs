using TodoApi.Models;

namespace TodoApi.Services
{
    public interface ICsvParserService
    {
        List<SPTransaction> ReadCsvFile(string path);
        // void WriteNewCsvFile(string path, List<SPTransaction> spTransactions);
    }
}