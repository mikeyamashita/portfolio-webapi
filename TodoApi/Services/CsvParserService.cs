using CsvHelper;
using TodoApi.Mappers;
using TodoApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper.Configuration;
using System.Globalization;

namespace TodoApi.Services
{
    public class CsvParserService : ICsvParserService
    {


        public List<SPTransaction> ExecuteService()
        {
            return ReadCsvFile("Assets/transactions_summary.csv");
        }

        public List<SPTransaction> ReadCsvFile(string path)
        {
            try
            {
                var SPTransaction = new List<SPTransaction>();

                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                };
                using (var reader = new StreamReader(path, Encoding.Default))
                {
                    using (var csv = new CsvReader(reader, config))
                    {
                        csv.Context.RegisterClassMap<SPTransactionMap>();
                        var records = csv.GetRecords<SPTransaction>().ToList();

                        return records;
                    }
                }
            }
            catch (UnauthorizedAccessException e)
            {
                throw new Exception(e.Message);
            }
            catch (FieldValidationException e)
            {
                throw new Exception(e.Message);
            }
            catch (CsvHelperException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        // public void WriteNewCsvFile(string path, List<SPTransaction> spTransactions)
        // {
        //     using (StreamWriter sw = new StreamWriter(path, false, new UTF8Encoding(true)))
        //     using (CsvWriter cw = new CsvWriter(sw))
        //     {
        //         cw.WriteHeader<SPTransaction>();
        //         cw.NextRecord();
        //         foreach (SPTransaction emp in spTransactions)
        //         {
        //             cw.WriteRecord<SPTransaction>(emp);
        //             cw.NextRecord();
        //         }
        //     }
        // }
    }
}