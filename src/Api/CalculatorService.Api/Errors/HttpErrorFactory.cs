using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace CalculatorService.Api.Errors
{
    public class HttpErrorFactory
    {
        public static HttpError CreateFrom(Exception exception)
        {
            var httpError = new HttpError();


            if (exception is ValidationException)
            {
                httpError.Code = StatusCodes.Status400BadRequest;
                httpError.ErrorCode = "ValidationError";
                httpError.ErrorMessage = GetValidationErrors(exception as ValidationException);
                httpError.ErrorStatus = StatusCodes.Status400BadRequest.ToString();
            }
            else
            {
                httpError.Code = StatusCodes.Status500InternalServerError;
                httpError.ErrorCode = "InternalServerError";
                httpError.ErrorMessage = "An unexpected error condition was triggered which made impossible to fulfill the request. Please try again or contact support.";
                httpError.ErrorStatus = StatusCodes.Status500InternalServerError.ToString();


            }

            return httpError;
        }

        private  static string GetValidationErrors(ValidationException exception)
        {
            string errors = string.Join(";",exception.Errors.Select(x => x.ErrorMessage));

            return $"An invalid request has been received: {errors}";
        }
    }
}
