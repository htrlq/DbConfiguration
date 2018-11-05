using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;

namespace DbConfiguration
{
    public class DbOptions<TOptions> : IDbOptions<TOptions> where TOptions : class
    {
        private RemoteOptionsEntity Options { get; }
        private ApplicationSettingsContext Context { get; }
        public TOptions Value
        {
            get
            {
                var key = Options.GetKey<TOptions>();

                if (string.IsNullOrWhiteSpace(key))
                    return null;

                var firstOfDefault = Context.Settings.AsNoTracking().FirstOrDefault(item => item.Key == key);

                if (firstOfDefault == null)
                    return null;

                return JsonConvert.DeserializeObject<TOptions>(firstOfDefault.Value);
            }
        }

        public DbOptions(RemoteOptionsEntity options, ApplicationSettingsContext context)
        {
            Options = options;
            Context = context;
        }
    }
}
