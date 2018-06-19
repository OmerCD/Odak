using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListviewProje.Classes
{
    public class CustomAttribute : Attribute
    {
        public int MinLength { get; set; }
        public string MinLengthMessage { get; set; }
        public int MaxLength { get; set; }
        public string MaxLengthMessage { get; set; }
        public string RegexPattern { get; set; }
        public string PlaceHolderText { get; set; }
        public string RegexPatternMessage { get; set; }
        public string FieldName { get; set; }
        public bool IsPassword { get; set; }
        public bool Nullable { get; set; }
        public bool Searchable { get; set; }
        public CustomAttribute()
        {
            IsPassword = false;
        }
        public void SetMessages()
        {
            MinLengthMessage = FieldName + " " + MinLength + " haneden kısa olamaz";
            MaxLengthMessage = FieldName + " " + MaxLength + " haneden uzun olamaz";
            RegexPatternMessage = "Hatalı veri girişi";
        }

    }
}
