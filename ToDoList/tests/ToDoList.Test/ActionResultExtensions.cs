namespace ToDoList.Test;

using Microsoft.AspNetCore.Mvc;

public static class ActionResultExtensions
{
    public static T? GetValue<T>(this ActionResult<T> result) => result.Result is null
       ? result.Value
       : (T?)(result.Result as ObjectResult)?.Value;

    public static int? GetStatusCode<T>(this ActionResult<T> result)
    {
        if (result.Result == null)
            return null;

        switch (result.Result)
        {
            case ObjectResult objectResult:
                return objectResult.StatusCode;

            case StatusCodeResult statusCodeResult:
                return statusCodeResult.StatusCode;

            default:
                return null;
        }
    }

}
