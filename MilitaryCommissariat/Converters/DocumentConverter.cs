using System;
using System.Data;
using MilitaryCommissariat.Domain;

namespace MilitaryCommissariat.Converters
{
    public class DocumentConverter : IConverter<Document, DataTable>
    {
        public Document Convert(DataTable source)
        {
            return null;
        }
    }
}