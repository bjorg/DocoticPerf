using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BitMiracle.Docotic.Pdf;

namespace DocoticPerf {
    public class Program {

        //--- Class Methods ---
        public static void Main(string[] args) {

            // check if arguments are missing
            if(args.Length == 0) {
                Console.WriteLine("ERROR: missing PDF file argument");
                return;
            }

            // check if pdf license key is present
            var pdflicense = System.Environment.GetEnvironmentVariable("PDF_LICENSE_KEY");
            if(pdflicense == null) {
                Console.WriteLine("ERROR: missing PDF_LICENSE_KEY environment variable");
                return;
            }
            BitMiracle.Docotic.LicenseManager.AddLicenseData(pdflicense);

            // iterate over all supplied files
            foreach(var filepath in args) {
                Console.WriteLine($"Analyzing '{filepath}'");
                try {
                    using(PdfDocument pdf = new PdfDocument(filepath)) {
                        var options = new PdfTextExtractionOptions {
                            WithFormatting = false,
                            SkipInvisibleText = true
                        };
                        var list = new List<int>(pdf.Pages.Count);
                        var stopwatch = Stopwatch.StartNew();
                        foreach(var page in pdf.Pages) {
                            var words = page.GetText().Split(' ');
                            list.Add(words.Length);
                        }
                        Console.WriteLine($"Time: {stopwatch.Elapsed.TotalSeconds:N3}s");
                        Console.WriteLine($"Words: {string.Join(", ", list.Select(c => c.ToString()))}");
                    }
                } catch(Exception e) {
                    Console.WriteLine($"ERROR: {e.Message}");
                }
            }
        }
    }
}
