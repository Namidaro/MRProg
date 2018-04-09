using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRProg.Connection
{
    public class QueryReport
    {
        private int _failedQueriesCount;
        private int _successQueriesCount;
        private bool _isSuccess;
        private int _allQueriesCount;


        public bool IsSuccess
        {
            get { return _isSuccess; }
            set
            {
                _isSuccess = value;
                if (value)
                {
                    _successQueriesCount++;
                }
                else
                {
                    _failedQueriesCount++;
                }
                _allQueriesCount++;
            }
        }

        public int SuccessQueriesCount
        {
            get { return _successQueriesCount; }
        }

        public int FailedQueriesCount
        {
            get { return _failedQueriesCount; }
        }

        public int AllQueriesCount
        {
            get { return _allQueriesCount; }
        }
    }
}
