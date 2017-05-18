using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BitMiracle.Docotic.Pdf;

namespace DocoticPerf {
    class Program {
        static void Main(string[] args) {
            if(args.Length != 1) {
                Console.WriteLine("ERROR: missing PDF file argument");
                return;
            }
            var pdflicense = System.Environment.GetEnvironmentVariable("PDF_LICENSE_KEY");
            if(pdflicense == null) {
                Console.WriteLine("ERROR: missing PDF_LICENSE_KEY environment variable");
                return;
            }
            BitMiracle.Docotic.LicenseManager.AddLicenseData(pdflicense);
            var filepath = args[0];
            Console.WriteLine($"Analyzing '{filepath}'");
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
        }
    }
}
