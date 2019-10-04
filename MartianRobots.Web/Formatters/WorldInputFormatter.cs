namespace MartianRobots.Web
{
    using System;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using MartianRobots;
    using Microsoft.AspNetCore.Mvc.Formatters;
    using Microsoft.Net.Http.Headers;

    internal class WorldInputFormatter : TextInputFormatter
    {
        public WorldInputFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/plain"));
            this.SupportedEncodings.Add(UTF8EncodingWithoutBOM);
        }

        public override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            using (var reader = context.ReaderFactory(context.HttpContext.Request.Body, encoding))
            {
                var input = reader.ReadToEnd();
                var world = Parser.Parse(input);
                return InputFormatterResult.SuccessAsync(world);
            }

        }

        protected override bool CanReadType(Type type)
        {
            return typeof(World).IsAssignableFrom(type);
        }
    }
}