using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

public interface ICustomRegex
{
    bool Is_Regex(RegexPattern ConstPattern, string StringIn);
}

public enum RegexPattern
{
    PatternTelefonNumber,
    PatternEmailAddress,
    PatternFourDigits,
    PatternWord,
    PatternEuropeanVATNumber,
    PatternDimensionOneValue,
    PatternDimensionTwoValues,
    PatternZIPCodeNumerical,
    PatternZIPCodeAlpha
}

namespace PassForm.Tools.Validation
{
    public class CustomRegex : ICustomRegex
    {
        private string pattern;

        public CustomRegex()
        {
        }

        public bool Is_Regex(RegexPattern ConstPattern, string StringIn)
        {
            bool isValid = false;

            switch (ConstPattern)
            {
                case RegexPattern.PatternEmailAddress:
                    this.pattern = @"^[^@]+@([-\w]+\.)+[A-Za-z]{2,4}$";
                    break;

                case RegexPattern.PatternFourDigits:
                    this.pattern = @"^\d\d\d\d$";
                    break;

                case RegexPattern.PatternTelefonNumber:
                    this.pattern = @"^((\+[0-9]{2,4}([ -][0-9]+?[ -]| ?\([0-9]+?\) ?))|(\(0[0-9 ]+?\) ?)|(0[0-9]+? ?( |-|\/) ?))([0-9]+?[ \/-]?)+?[0-9]$";
                    break;

                case RegexPattern.PatternWord:
                    this.pattern = @"[0-9A-Za-zÖöÄäÜüß]+";
                    break;

                case RegexPattern.PatternEuropeanVATNumber:
                    var builder = new StringBuilder();
                    builder.Append("^(");
                    builder.Append("(AT)?U[0-9]{8}|");                              // Austria
                    builder.Append("(BE)?0[0-9]{9}|");                              // Belgium
                    builder.Append("(BG)?[0-9]{9,10}|");                            // Bulgaria
                    builder.Append("(CY)?[0-9]{8}L|");                              // Cyprus
                    builder.Append("(CZ)?[0-9]{8,10}|");                            // Czech Republic
                    builder.Append("(DE)?[0-9]{9}|");                               // Germany
                    builder.Append("(DK)?[0-9]{8}|");                               // Denmark
                    builder.Append("(EE)?[0-9]{9}|");                               // Estonia
                    builder.Append("(EL|GR)?[0-9]{9}|");                            // Greece
                    builder.Append("(ES)?[0-9A-Z][0-9]{7}[0-9A-Z]|");               // Spain
                    builder.Append("(FI)?[0-9]{8}|");                               // Finland
                    builder.Append("(FR)?[0-9A-Z]{2}[0-9]{9}|");                    // France
                    builder.Append("(GB)?([0-9]{9}([0-9]{3})?|[A-Z]{2}[0-9]{3})|"); // United Kingdom
                    builder.Append("(HU)?[0-9]{8}|");                               // Hungary
                    builder.Append("(IE)?[0-9]S[0-9]{5}L|");                        // Ireland
                    builder.Append("(IT)?[0-9]{11}|");                              // Italy
                    builder.Append("(LT)?([0-9]{9}|[0-9]{12})|");                   // Lithuania
                    builder.Append("(LU)?[0-9]{8}|");                               // Luxembourg
                    builder.Append("(LV)?[0-9]{11}|");                              // Latvia
                    builder.Append("(MT)?[0-9]{8}|");                               // Malta
                    builder.Append("(NL)?[0-9]{9}B[0-9]{2}|");                      // Netherlands
                    builder.Append("(PL)?[0-9]{10}|");                              // Poland
                    builder.Append("(PT)?[0-9]{9}|");                               // Portugal
                    builder.Append("(RO)?[0-9]{2,10}|");                            // Romania
                    builder.Append("(SE)?[0-9]{12}|");                              // Sweden
                    builder.Append("(SI)?[0-9]{8}|");                               // Slovenia
                    builder.Append("(SK)?[0-9]{10}");                               // Slovakia
                    builder.Append(")$");

                    this.pattern = builder.ToString();
                    break;

                case RegexPattern.PatternDimensionOneValue:
                    this.pattern = @"^\d+,*\d*$";                                   // Für Masse im entsprechenden Feld.
                    break;

                case RegexPattern.PatternDimensionTwoValues:
                    this.pattern = @"^\d+,*\d*\s*x\s*\d+,*\d*$";                    // Für Masse im entsprechenden Feld.
                    break;

                case RegexPattern.PatternZIPCodeNumerical:
                    this.pattern = @"^\d{4,7}";
                    break;

                case RegexPattern.PatternZIPCodeAlpha:
                    this.pattern = @"[A-Z]{5}";
                    break;
            }

            var regExp = new Regex(pattern);
            isValid = regExp.IsMatch(StringIn);
            return isValid;
        }
    }
   
}
