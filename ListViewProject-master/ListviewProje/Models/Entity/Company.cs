using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListviewProje.Classes;

namespace ListviewProje.Models.Entity
{
    public class Company : DbObject
    {
        public Company(string name)
        {
            Name = name;
        }
        public Company()
        {

        }
        [Custom(FieldName = "Şirket Adı", MinLength = 3, MaxLength = 100, Searchable = true)]
        public string Name { get; set; }

        public PaymentDocument LastPaymentDocument { get; set; }
        [Custom(FieldName = "Hesap No", MinLength = 3, MaxLength = 100, Searchable = true)]
        public string AccountCode { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
