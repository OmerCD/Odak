using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ListviewProje.Models.Entity;
using Excel = Microsoft.Office.Interop.Excel;

namespace ListviewProje.Classes
{
    class ExcelImport : IDisposable
    {
        readonly Excel.Application _xlApp = new Excel.Application();
        readonly Excel.Range _xlRange;
        private readonly Excel._Worksheet _xlWorksheet;
        private readonly Excel.Workbook _xlWorkbook;
        private readonly object[,] _valuesExcel;
        private const int ColCount = 11;
        private readonly List<PaymentDocument> _paymentDocuments;

        public ExcelImport()
        {
            _xlWorkbook = _xlApp.Workbooks.Open(@"C:\Users\OmerC\OneDrive\Masaüstü\Copy of tez(728).xls");
            _xlWorksheet = _xlWorkbook.Sheets[1];
            _xlRange = _xlWorksheet.UsedRange;
            _valuesExcel = _xlRange.get_Value();
            _paymentDocuments = DbFactory.PaymentDocumentCRUD.GetAll();
        }

        public async void Read()
        {

            var pDList = new List<PaymentDocument>(_xlRange.Rows.Count - 2);
            for (int i = 3; i <= _xlRange.Rows.Count; i++)
            {
                var test = AssignValues(i);
                if (test != null) pDList.Add(test);
            }
            await InsertToDatabase(pDList);
        }

        private async Task InsertToDatabase(List<PaymentDocument> pDList)
        {
            await Task.Run(() =>
            {
                foreach (var paymentDocument in pDList)
                {
                    InsertDoc(paymentDocument);
                }
            }
            );
        }

        private bool InsertDoc(PaymentDocument test)
        {
            foreach (PaymentDocument pDocument in _paymentDocuments)
            {
                if (pDocument.AccountCode == test.AccountCode && pDocument.DocumentDate == test.DocumentDate && pDocument.DocumentDate == test.DocumentDate && pDocument.Firm._id == test.Firm._id)
                {
                    return false;
                }
            }

            if (DbFactory.PaymentDocumentCRUD.Insert(test))
            {
                _paymentDocuments.Add(test);
                return true;
            }
            else
            {
                return false;
            }
        }

        private PaymentDocument AssignValues(int i)
        {

            var pD = new PaymentDocument
            {
                //Creator = MainPage.CurrentUser todo
            };

            if (_valuesExcel[i, 5] != null)
            {
                pD.DocumentNo = _valuesExcel[i, 5].ToString();

            }
            else
            {
                return null;
            }

            if (_valuesExcel[i, 1] != null)
            {
                pD.AccountCode = _valuesExcel[i, 1].ToString();
            }



            if (_valuesExcel[i, 4] != null)
            {
                var dateString = (_valuesExcel[i, 4].ToString());
                var testDate = DateTime.Parse(dateString);
                pD.DocumentDate = testDate;
            }


            if (_valuesExcel[i, 8] != null)
            {
                pD.Description = _valuesExcel[i, 8].ToString();
            }

            if (_valuesExcel[i, 9] != null)
            {
                pD.Debt = double.Parse(_valuesExcel[i, 9].ToString());
            }
            if (_valuesExcel[i, 10] != null)
            {
                pD.Credit = double.Parse(_valuesExcel[i, 10].ToString());
            }
            if (_valuesExcel[i, 11] != null)
            {
                pD.Balance = double.Parse(_valuesExcel[i, 11].ToString());
            }
            if (_valuesExcel[i, 2] != null)
            {
                var firmName = _valuesExcel[i, 2].ToString();
                var firm = DbFactory.CompanyCRUD.GetOne("Name", firmName);
                if (firm._id == null)
                {
                    firm = new Company { Name = firmName, AccountCode = pD.AccountCode };
                    DbFactory.CompanyCRUD.Insert(firm);
                }

                pD.Firm = firm;
            }
            return pD;
        }

        public void Dispose()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Marshal.ReleaseComObject(_xlRange);
            Marshal.ReleaseComObject(_xlWorksheet);

            _xlWorkbook.Close();
            Marshal.ReleaseComObject(_xlWorkbook);

            _xlApp.Quit();
            Marshal.ReleaseComObject(_xlApp);
        }
    }
}
