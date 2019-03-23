using System.Text;

namespace System.Web.Mvc
{
    public static class ExtensionController
    {
        public static JsonResult JsonNoLoop(this Controller controller, object data)
        {
            return controller.JsonNoLoop(data, (string)null, (Encoding)null, JsonRequestBehavior.DenyGet);
        }

        public static JsonResult JsonNoLoop(this Controller controller, object data, string contentType)
        {
            return controller.JsonNoLoop(data, contentType, (Encoding)null, JsonRequestBehavior.DenyGet);
        }

        public static JsonResult JsonNoLoop(this Controller controller, object data, string contentType, Encoding contentEncoding)
        {
            return controller.JsonNoLoop(data, contentType, contentEncoding, JsonRequestBehavior.DenyGet);
        }

        public static JsonResult JsonNoLoop(this Controller controller, object data, JsonRequestBehavior behavior)
        {
            return controller.JsonNoLoop(data, (string)null, (Encoding)null, behavior);
        }

        public static JsonResult JsonNoLoop(this Controller controller, object data, string contentType, JsonRequestBehavior behavior)
        {
            return controller.JsonNoLoop(data, contentType, (Encoding)null, behavior);
        }

        public static JsonResult JsonNoLoop(this Controller controller, object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new MoriahJsonResult()
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
        }


        
    }
}
