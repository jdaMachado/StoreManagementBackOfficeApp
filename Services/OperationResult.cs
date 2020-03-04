using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class OperationResult
    {

        public Exception Exception { get; set; }

        protected bool _hasSucceededBeenChecked = false;

        private bool _hasSucceeded;
        public bool HasSucceeded
        {
            get
            {
                _hasSucceededBeenChecked = true;
                return _hasSucceeded;
            }
            set
            {
                _hasSucceeded = value;
            }
        }



        //Constructors
        public OperationResult() { }

        public OperationResult(bool hasSucceed)
        {
            HasSucceeded = true;
        }

        public OperationResult(Exception exception)
        {
            Exception = exception;
            HasSucceeded = false;
        }
    }





    public class OperationResult<T> : OperationResult
    {
        private T _result;

        public T Result
        {
            get
            {
                if (!_hasSucceededBeenChecked)
                    throw new UnauthorizedAccessException("Please Check if Operation has been succeeded!");

                return _result;
            }
            set
            {
                _result = value;
            }
        }


        //Constructors
        public OperationResult() { }

        public OperationResult(T dto)
        {
            Result = dto;
            HasSucceeded = true;
        }

        public OperationResult(Exception exception)
        {
            Exception = exception;
            HasSucceeded = false;
        }

    }
}
