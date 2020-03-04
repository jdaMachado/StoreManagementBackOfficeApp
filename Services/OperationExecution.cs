using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Services
{
    public class OperationExecution 
    {
        public TransactionScope CreateTransactionScope()
        {
            var transactionOptions = new TransactionOptions();
            transactionOptions.Timeout = TimeSpan.FromSeconds(30);
            transactionOptions.IsolationLevel = IsolationLevel.ReadCommitted;

            return new TransactionScope(TransactionScopeOption.Required, transactionOptions);
        }

        public OperationResult ExecuteOperation(Action action)
        {
            try
            {
                using (var transactionScope = CreateTransactionScope())
                {
                    action.Invoke();
                    transactionScope.Complete();
                    return new OperationResult(true);
                }
            }
            catch (Exception exception)
            {
                return new OperationResult(exception);
            }
        }

        public OperationResult<T> ExecuteOperation<T>(Func<T> func) where T : class
        {
            try
            {
                using (var transactionScope = CreateTransactionScope())
                {
                    var result = func.Invoke();
                    transactionScope.Complete();
                    return new OperationResult<T>(result);
                }

            }
            catch (Exception exception)
            {
                return new OperationResult<T>(exception);
            }

        }
    }
}
