using System;
using System.Collections.Generic;
using System.Text;

namespace VaporStore
{
    public class GlobalConstants
    {
        // Purchase
        public const string ProductKeyValidation = @"[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}";

        // Card
        public const string CardValidation = @"[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}";
        public const string CvcValidation = @"[0-9]{3}";

        // User
        public const int UsernameMinLength = 3;
        public const int UsernameMaxLength = 20;
        public const string FullNameValidation = @"[A-Z][a-z]+ [A-Z][a-z]+";

        // Game
        public const string PriceMinValue = "0.0";
    }
}

