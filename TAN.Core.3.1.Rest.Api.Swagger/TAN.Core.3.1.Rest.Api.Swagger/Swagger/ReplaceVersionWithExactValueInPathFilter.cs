﻿using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TAN.Core._3._1.Rest.Api.Swagger.Swagger
{
    public class ReplaceVersionWithExactValueInPathFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var paths = new OpenApiPaths();
            foreach (var path in swaggerDoc.Paths)
            {
                paths.Add(path.Key.Replace("v{version}", swaggerDoc.Info.Version), path.Value);
            }
            swaggerDoc.Paths = paths;
        }
    }
}
