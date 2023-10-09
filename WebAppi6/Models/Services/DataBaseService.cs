namespace WebAppi6.Models.Services
{
    public class DataBaseService
    {
        ApplicationContext context;
        readonly IServiceProvider service;
        public DataBaseService(IServiceProvider service, ApplicationContext context) 
        {
            this.service = service;
            this.context = context;
        }

    }
}
