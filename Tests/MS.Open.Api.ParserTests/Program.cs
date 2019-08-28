using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;
using System;
using System.Dynamic;
using System.IO;
using Majin.Vegeta.Build.Extensions;
using System.Text;
using System.Globalization;

namespace MS.Open.Api.ParserTests
{
    class Program
    {
        static void Main(string[] args)
        {
            DeserializeSwaggerDoc();
        }

        /// <summary>
        /// Deserialize a Swagger Doc for the Fun of IT!
        /// </summary>
        private static void DeserializeSwaggerDoc()
        {
            FileStream stream = File.OpenRead("../../../../../swagger.json");
            OpenApiDocument openApiDocument = new OpenApiStreamReader().Read(stream, out OpenApiDiagnostic diagnostic);

            foreach (var pathInfo in openApiDocument.Paths.Keys)
            {
                Console.WriteLine($"For path {pathInfo} the supported operations are:");
                OpenApiPathItem openPathInfo = openApiDocument.Paths[pathInfo];

                foreach (OperationType operation in openPathInfo.Operations.Keys)
                {
                    OpenApiOperation opInfo = openPathInfo.Operations[operation];
                    Console.WriteLine($"{operation} --> {opInfo}");
                    ParseOperation(operation, opInfo);
                }

                Console.WriteLine($"{Environment.NewLine}");
            }

        }

        private static void ParseOperation(OperationType operation, OpenApiOperation opInfo)
        {
            Console.WriteLine($"{Environment.NewLine}");

            if(operation == OperationType.Get)
            {
                var dynObj = new ExpandoObject();
                dynObj.AddProperty("What", "Salt");

                foreach(OpenApiParameter parameter in opInfo.Parameters)
                {

                }
            }

        }
    }
}
