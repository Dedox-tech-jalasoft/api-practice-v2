namespace Microsoft.Extensions.DependencyInjection
{
    public static class WebApplicationExtensions
    {
        public static void UseRestApiExtensions (this WebApplication webApplication)
        {
            if (webApplication.Environment.IsDevelopment())
            {
                webApplication.UseSwagger();
                webApplication.UseSwaggerUI();
            }

            webApplication.UseHttpsRedirection();
            webApplication.MapControllers();
        }
    }
}
