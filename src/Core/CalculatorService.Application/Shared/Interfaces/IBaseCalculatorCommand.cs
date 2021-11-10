using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorService.Application.Shared.Interfaces
{
    public interface IBaseCalculatorCommand
    {
        string OperationName { get;}

        string GetOperation();

    }
}
