using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

enum RegexPattern
{
    PatternTelefonNumber,
    PatternEmailAddress,
    PatternFourDigits,
    PatternWord,
    PatternEuropeanVATNumber
}

namespace WindowsFormsApplication1
{
    class GRegex
    {
        private string pattern;

        public GRegex()
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

                    this.pattern = @"^(
                                        (AT)?U[0-9]{8} |                              # Austria
                                        (BE)?0[0-9]{9} |                              # Belgium
                                        (BG)?[0-9]{9,10} |                            # Bulgaria
                                        (CY)?[0-9]{8}L |                              # Cyprus
                                        (CZ)?[0-9]{8,10} |                            # Czech Republic
                                        (DE)?[0-9]{9} |                               # Germany
                                        (DK)?[0-9]{8} |                               # Denmark
                                        (EE)?[0-9]{9} |                               # Estonia
                                        (EL|GR)?[0-9]{9} |                            # Greece
                                        (ES)?[0-9A-Z][0-9]{7}[0-9A-Z] |               # Spain
                                        (FI)?[0-9]{8} |                               # Finland
                                        (FR)?[0-9A-Z]{2}[0-9]{9} |                    # France
                                        (GB)?([0-9]{9}([0-9]{3})?|[A-Z]{2}[0-9]{3}) | # United Kingdom
                                        (HU)?[0-9]{8} |                               # Hungary
                                        (IE)?[0-9]S[0-9]{5}L |                        # Ireland
                                        (IT)?[0-9]{11} |                              # Italy
                                        (LT)?([0-9]{9}|[0-9]{12}) |                   # Lithuania
                                        (LU)?[0-9]{8} |                               # Luxembourg
                                        (LV)?[0-9]{11} |                              # Latvia
                                        (MT)?[0-9]{8} |                               # Malta
                                        (NL)?[0-9]{9}B[0-9]{2} |                      # Netherlands
                                        (PL)?[0-9]{10} |                              # Poland
                                        (PT)?[0-9]{9} |                               # Portugal
                                        (RO)?[0-9]{2,10} |                            # Romania
                                        (SE)?[0-9]{12} |                              # Sweden
                                        (SI)?[0-9]{8} |                               # Slovenia
                                        (SK)?[0-9]{10}                                # Slovakia
                                        )$";
                    break;


            }

            Regex regExp = new Regex(pattern);
            isValid = regExp.IsMatch(StringIn);
            return isValid;
        }
    }
}
