using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListviewProje.Models.Entity
{
    public abstract class DbObject : IDisposable
    {
        // ReSharper disable once InconsistentNaming
        public string _id { get; set; }
        public DateTime CreationDate { get; protected set; }
        public byte IsDeleted { get; protected set; }
        protected DbObject()
        {
            _id = Guid.NewGuid().ToString();
            IsDeleted = 0;
            CreationDate = DateTime.Now;
        }
        public void Delete()
        {
            IsDeleted = 1;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
