using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OppAdatbazis.Services
{
    internal interface ISqlStatements
    {
        List<object> GetAllRecords();

        object GetBookById(int id);

        object addNewRecord(object newBook);

        object deleteRecord(int id);

        object updateRecord(int id,object newBook);
    }
}
