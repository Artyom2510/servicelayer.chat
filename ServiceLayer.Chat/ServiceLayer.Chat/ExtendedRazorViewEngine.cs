using System.Linq;
using System.Web.Mvc;

namespace ServiceLayer.Chat
{
    internal class ExtendedRazorViewEngine : RazorViewEngine
    {
        private readonly string[] _newPartialViewFormats =
        {
            "~/Views/{1}/Partials/{0}.cshtml",
            "~/Views/Shared/Partials/{0}.cshtml",
            "~/Views/{1}/Chat/{0}.cshtml",
            "~/Views/Shared/Chat/{0}.cshtml"
        };


        public ExtendedRazorViewEngine()
        {
            //Remove this optimization to enable Visual Basic views
            FileExtensions = new[]
                                  {
                                      "cshtml"
                                  };

            PartialViewLocationFormats = PartialViewLocationFormats.Union(_newPartialViewFormats).ToArray();
        }
    }
}