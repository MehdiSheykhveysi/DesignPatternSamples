using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace WebDecoratorPattern.Infrastructure
{
    public class ActionResultDecorator : ActionResult
    {
        public ActionResult ActionResult { get; set; }
        public string Messsage { get; set; }
        public string Key { get; set; }
        public ActionResultDecorator(ActionResult actionResult, string key, string message)
        {
            ActionResult = actionResult;
            Key = key;
            Messsage = message;
        }

        public override void ExecuteResult(ActionContext context)
        {
            ViewDataDictionary factory = context.HttpContext.RequestServices.GetService(typeof(ViewDataDictionary)) as ViewDataDictionary;

            factory.Add(Key, Messsage);

            base.ExecuteResult(context);
        }
    }
}
