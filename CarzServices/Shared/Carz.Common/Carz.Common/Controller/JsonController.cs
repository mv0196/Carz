using Microsoft.AspNetCore.Mvc;

namespace Carz.Common.Controller
{
    public class JsonController<T> : ControllerBase where T : JsonController<T>
    {
        //protected IActionResult JsonResponse() { }
    }
}
