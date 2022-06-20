using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FiboInfraStructure.Entity.FiboBilling
{
    public class Expense : BaseEntity
    {
        private readonly bool IsExpenseActive = true;
        private readonly bool IsOfficeInActive = false;

         public  bool IsActive()
        {
            return IsExpense == IsExpenseActive;
        }
        
        public bool IsInActive ()
        {
            return IsExpense == IsOfficeInActive;
        }

        public string Name { get; set; }
        public string Miti { get; set; }
        public DateTime? Date { get; set; }
        public decimal Amount { get; set; } 

        public bool IsExpense { get; set; }
       
    }
}
