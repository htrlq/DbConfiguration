using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbConfiguration
{
    [Table("ApplicationSettings")]
    public class ApplicationSetting
    {
        private string key;

        [Key]
        public string Key
        {
            get { return key; }
            set { key = value.ToLowerInvariant(); }
        }

        [Required]
        [MaxLength(512)]
        public string Value { get; set; }
    }
}
