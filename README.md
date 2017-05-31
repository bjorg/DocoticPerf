DocoticPerf
===========

Simple application to test Docotic.Pdf library.

Sample PDF files are located in the `pdfs` folder.

Before running tests, make sure to define `PDF_LICENSE_KEY` environment variable with the Docotic.Pdf license key.

To run test for PDFs causing errors:
`dotnet run pdfs/error*`

To Run test for PDFs that are slow:
`dotnet run pdfs/slow*`