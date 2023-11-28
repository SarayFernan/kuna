using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace kuna.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connetionString;
        public RepositoryBase()
        {
            _connetionString = "Server =(local); Database=MVMLogingDb; Integrated Security=True;";
        }


    }
}
