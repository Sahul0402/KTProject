using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.Model.AppSettings
{
    public class JwtSettings
    {
        public string secretKey { get; init; } = null!;
        public int ExpireMinutes { get; init; }
        public string validAudience { get; set; } = null!;
        public string validIssuer { get; set; } = null!;

        public const string SectionName = "JwtSettings";
        public int RefreshTokenExpDays { get; init; }

    }
}
