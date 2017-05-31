DocoticPerf
===========

Simple application to test Docotic.Pdf library.

Sample PDF files are located in the `pdfs` folder.

Before running tests, make sure to set `PDF_LICENSE_KEY` environment variable to the Docotic.Pdf license key.

To run tests for PDFs that cause errors:
`dotnet run pdfs/error*`

To run tests for PDFs that are slow:
`dotnet run pdfs/slow*`
