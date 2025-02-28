﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftLabOne.Domain.Common
{
   public class Result
    {
        public Result(bool isSucces, Error error)
        {
            if (isSucces && error != Error.None)
                throw new InvalidOperationException();
            
            if (!isSucces && error == Error.None)
                throw new InvalidOperationException();

            Error = error;
            IsSuccess = isSucces;
        }

        public Error Error { get; }
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;

        public static Result Succes() => new(true, Error.None);

        public static implicit operator Result(Error error) => new(false, error);
    }

    public class Result<TValue> : Result
    {
        public Result(TValue value, bool isSuccess, Error error) 
                                                : base(isSuccess, error)
        {
            _value = value;
        }
        private readonly TValue _value;

        public TValue Value => IsSuccess
                      ? _value
                      : throw new InvalidOperationException("The value of a failure result can not be accessed");

        public static Result<TValue> Succes(TValue value) => new(value,true, Error.None);
        public static implicit operator Result<TValue>(Error error) => new(default!,false, error);
        public static implicit operator Result<TValue>(TValue value) => new(value,true, Error.None);
    }
}
