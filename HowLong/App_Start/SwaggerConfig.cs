using System.Web.Http;
using WebActivatorEx;
using HowLong;
using Swashbuckle.Application;


namespace HowLong
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Swagger Sample");
                    c.IncludeXmlComments(GetXmlCommentsPath());
                })
                .EnableSwaggerUi(c =>
                {

                });
        }

        protected static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\HowLong.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
