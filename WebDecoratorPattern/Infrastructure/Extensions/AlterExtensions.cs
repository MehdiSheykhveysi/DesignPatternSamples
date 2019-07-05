using Microsoft.AspNetCore.Mvc;

namespace WebDecoratorPattern.Infrastructure.Extensions
{
    public static class AlterExtensions
    {
        public static ActionResult WithSuccess(this ActionResult actionResult,string Key,string Message)
        {
            return new ActionResultDecorator(actionResult, Key, Message);
        }
    }
}
