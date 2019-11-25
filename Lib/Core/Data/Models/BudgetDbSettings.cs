using System;

namespace Core.Data.Models
{
    public class BudgetDbSettings : IBudgetDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IBudgetDbSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}